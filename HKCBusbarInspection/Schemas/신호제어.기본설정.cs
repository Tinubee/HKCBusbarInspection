using ActUtlType64Lib;
using DevExpress.CodeParser;
using MvUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace HKCBusbarInspection.Schemas
{
    // PLC 통신
    [Description("MELSEC Q03UDV")]
    public partial class 신호제어
    {
        public event Global.BaseEvent 동작상태알림;
        public event Global.BaseEvent 통신상태알림;
        public event Global.BaseEvent 검사위치알림;
        public event Global.BaseEvent 입출변경알림;

        #region 기본상수 및 멤버
        private static String 로그영역 = "PLC";
        private const Int32 스테이션번호 = 2;
        private const Int32 입출체크간격 = 20;
        private DateTime 시작일시 = DateTime.Now;
        private Boolean 작업여부 = false;  // 동작 FLAG 
        private ActUtlType64 PLC = null;
        public Boolean 정상여부 = false;
        public DateTime 통신확인주기시간 = DateTime.Now;
        public Int32 통신확인주기 = 1;

        public enum 정보주소 : Int32
        {
            [Address("W0020")]
            트레이검사트리거,
            [Address("W0050")]
            하부01검사트리거,
            [Address("W0051")]
            하부02검사트리거,
            [Address("W0052")]
            하부03검사트리거,
            [Address("W0060")]
            셔틀01검사트리거,
            [Address("W0061")]
            셔틀02검사트리거,
            [Address("W0062")]
            셔틀03검사트리거,
            [Address("W0090")]
            셔틀01결과값요청,
            [Address("W0091")]
            셔틀02결과값요청,
            [Address("W0092")]
            셔틀03결과값요청,

            [Address("W0000")]
            모델번호,
            [Address("W0001")]
            원점복귀완료,

            [Address("W0070")]
            셔틀01촬영완료,
            [Address("W0071")]
            셔틀02촬영완료,
            [Address("W0072")]
            셔틀03촬영완료,

            [Address("W0100")]
            하부01인덱스,
            [Address("W0102")]
            하부02인덱스,
            [Address("W0104")]
            하부03인덱스,
            [Address("W0110")]
            셔틀01인덱스,
            [Address("W0112")]
            셔틀02인덱스,
            [Address("W0114")]
            셔틀03인덱스,

            [Address("W0021")]
            트레이결과,
            [Address("W0101")]
            하부01결과,
            [Address("W0103")]
            하부02결과,
            [Address("W0105")]
            하부03결과,
            [Address("W0111")]
            셔틀01결과,
            [Address("W0113")]
            셔틀02결과,
            [Address("W0115")]
            셔틀03결과,
            [Address("B1000")]
            통신확인전송,
            [Address("B1010")]
            통신확인수신,

            [Address("B1011")]
            수동모드,
            [Address("B1012")]
            자동대기,
            [Address("B1013")]
            자동운전,

            [Address("B1017")]
            마스터모드,
        }

        private 통신자료 입출자료 = new 통신자료();

        public static Int32 OK = 1;
        public static Int32 NG = 2;
        public static Boolean ToBool(Int32 val) { return val != 0; }
        public static Int32 ToInt(Boolean val) { return val ? 1 : 0; }
        public static Int32 ToIntResult(Boolean val) { return val ? 1 : 2; }
        public Int32 정보읽기(정보주소 구분) { return this.입출자료.Get(구분); }
        private Boolean 신호읽기(정보주소 구분) { return ToBool(this.입출자료.Get(구분)); }
        private void 정보쓰기(정보주소 구분, Int32 val) { this.입출자료.Set(구분, val); }
        private void 정보쓰기(정보주소 구분, Boolean val) { this.입출자료.Set(구분, ToInt(val)); }
        private void 결과쓰기(정보주소 구분, Boolean val) { this.입출자료.Set(구분, ToIntResult(val)); }



        #region 입출신호
        public Boolean 하부01검사트리거 { get => 신호읽기(정보주소.하부01검사트리거); set => 정보쓰기(정보주소.하부01검사트리거, value); }
        public Boolean 하부02검사트리거 { get => 신호읽기(정보주소.하부02검사트리거); set => 정보쓰기(정보주소.하부02검사트리거, value); }
        public Boolean 하부03검사트리거 { get => 신호읽기(정보주소.하부03검사트리거); set => 정보쓰기(정보주소.하부03검사트리거, value); }
        public Boolean 셔틀01검사트리거 { get => 신호읽기(정보주소.셔틀01검사트리거); set => 정보쓰기(정보주소.셔틀01검사트리거, value); }
        public Boolean 셔틀02검사트리거 { get => 신호읽기(정보주소.셔틀02검사트리거); set => 정보쓰기(정보주소.셔틀02검사트리거, value); }
        public Boolean 셔틀03검사트리거 { get => 신호읽기(정보주소.셔틀03검사트리거); set => 정보쓰기(정보주소.셔틀03검사트리거, value); }

        public Boolean 하부01결과신호초기화 { get => 신호읽기(정보주소.하부01결과); set => 정보쓰기(정보주소.하부01결과, value); }
        public Boolean 하부02결과신호초기화 { get => 신호읽기(정보주소.하부02결과); set => 정보쓰기(정보주소.하부02결과, value); }
        public Boolean 하부03결과신호초기화 { get => 신호읽기(정보주소.하부03결과); set => 정보쓰기(정보주소.하부03결과, value); }

        public Boolean 셔틀01결과신호초기화 { get => 신호읽기(정보주소.셔틀01결과); set => 정보쓰기(정보주소.셔틀01결과, value); }
        public Boolean 셔틀02결과신호초기화 { get => 신호읽기(정보주소.셔틀02결과); set => 정보쓰기(정보주소.셔틀02결과, value); }
        public Boolean 셔틀03결과신호초기화 { get => 신호읽기(정보주소.셔틀03결과); set => 정보쓰기(정보주소.셔틀03결과, value); }

        public Boolean 하부01결과신호 { get => 신호읽기(정보주소.하부01결과); set => 결과쓰기(정보주소.하부01결과, value); }
        public Boolean 하부02결과신호 { get => 신호읽기(정보주소.하부02결과); set => 결과쓰기(정보주소.하부02결과, value); }
        public Boolean 하부03결과신호 { get => 신호읽기(정보주소.하부03결과); set => 결과쓰기(정보주소.하부03결과, value); }

        public Boolean 셔틀01촬영완료신호 { get => 신호읽기(정보주소.셔틀01촬영완료); set => 정보쓰기(정보주소.셔틀01촬영완료, value); }
        public Boolean 셔틀02촬영완료신호 { get => 신호읽기(정보주소.셔틀02촬영완료); set => 정보쓰기(정보주소.셔틀02촬영완료, value); }
        public Boolean 셔틀03촬영완료신호 { get => 신호읽기(정보주소.셔틀03촬영완료); set => 정보쓰기(정보주소.셔틀03촬영완료, value); }

        public Boolean 셔틀01결과신호 { get => 신호읽기(정보주소.셔틀01결과); set => 결과쓰기(정보주소.셔틀01결과, value); }
        public Boolean 셔틀02결과신호 { get => 신호읽기(정보주소.셔틀02결과); set => 결과쓰기(정보주소.셔틀02결과, value); }
        public Boolean 셔틀03결과신호 { get => 신호읽기(정보주소.셔틀03결과); set => 결과쓰기(정보주소.셔틀03결과, value); }

        public Boolean 자동수동여부 { get => !신호읽기(정보주소.수동모드); }
        public Boolean 자동대기여부 { get => 신호읽기(정보주소.자동대기); }
        public Boolean 시작정지여부 { get => 신호읽기(정보주소.자동운전); }
        public Int32 하부01인덱스 => this.입출자료.Get(정보주소.하부01인덱스);
        public Int32 하부02인덱스 => this.입출자료.Get(정보주소.하부02인덱스);
        public Int32 하부03인덱스 => this.입출자료.Get(정보주소.하부03인덱스);

        public Int32 셔틀01인덱스 => this.입출자료.Get(정보주소.셔틀01인덱스);
        public Int32 셔틀02인덱스 => this.입출자료.Get(정보주소.셔틀02인덱스);
        public Int32 셔틀03인덱스 => this.입출자료.Get(정보주소.셔틀03인덱스);

        public Boolean 통신확인핑퐁 { get => 신호읽기(정보주소.통신확인수신); set => 정보쓰기(정보주소.통신확인전송, value); }
        #endregion

        private Dictionary<정보주소, Int32> 인덱스버퍼 = new Dictionary<정보주소, Int32>();
        #endregion

        #region 기본함수
        public void Init()
        {
            this.PLC = new ActUtlType64 { ActLogicalStationNumber = 스테이션번호 };
            if (Global.환경설정.동작구분 == 동작구분.Live)
                this.입출자료.Init(new Action<정보주소, Int32>((주소, 값) => 자료전송(주소, 값)));
            else 
                this.입출자료.Init(null);
        }
        public void Close() { this.Stop(); }

        public void Start()
        {
            if (this.작업여부) return;
            this.작업여부 = true;
            this.정상여부 = true;
            this.시작일시 = DateTime.Now;
            if (Global.환경설정.동작구분 == 동작구분.Live)
            {
                this.입출자료갱신();
                this.출력자료리셋();
                this.인덱스버퍼리셋();
                this.인덱스리셋확인();
                this.동작상태알림?.Invoke();
            }
            new Thread(장치통신작업) { Priority = ThreadPriority.Highest }.Start();
        }

        public void Stop() => this.작업여부 = false;
        public Boolean Open()
        {
            if (Global.환경설정.동작구분 != 동작구분.Live) return true;
            this.정상여부 = PLC.Open() == 0; return this.정상여부;
        }

        private void 연결종료()
        {
            try
            {
                if (this.PLC != null) PLC.Close();

                Global.정보로그(로그영역, "PLC 연결종료", $"서버에 연결을 종료하였습니다.", false);
            }
            catch (Exception ex)
            {
                Global.오류로그(로그영역, "PLC 연결종료", $"서버 연결을 종료하는 중 오류가 발생하였습니다.\r\n{ex.Message}", false);
            }
        }

        private void 자료전송(정보주소 주소, Int32 값)
        {
            SetDevice(입출자료.Address(주소), 값, out Int32 오류);
            통신오류알림(오류);
        }

        private void 장치통신작업()
        {
            Global.정보로그(로그영역, "PLC 통신", $"통신을 시작합니다.", false);
            while (this.작업여부)
            {
                try { 입출자료분석(); }
                catch (Exception ex) { Debug.WriteLine(ex.Message, 로그영역); }
                Thread.Sleep(입출체크간격);
            }
            Global.정보로그(로그영역, "PLC 통신", $"통신이 종료되었습니다.", false);
            this.연결종료();
        }

        private void 출력자료리셋()
        {
            this.하부01검사트리거 = false;
            this.하부02검사트리거 = false;
            this.하부03검사트리거 = false;
            this.셔틀01검사트리거 = false;
            this.셔틀02검사트리거 = false;
            this.셔틀03검사트리거 = false;
            this.셔틀01촬영완료신호 = false;
            this.셔틀02촬영완료신호 = false;
            this.셔틀03촬영완료신호 = false;
            this.하부01결과신호초기화 = false;
            this.하부02결과신호초기화 = false;
            this.하부03결과신호초기화 = false;
            this.셔틀01결과신호초기화 = false;
            this.셔틀02결과신호초기화 = false;
            this.셔틀03결과신호초기화 = false;
        }

        private void 인덱스버퍼리셋()
        {
            this.인덱스버퍼.Clear();
            this.인덱스버퍼.Add(정보주소.하부01검사트리거, 0);
            this.인덱스버퍼.Add(정보주소.하부02검사트리거, 0);
            this.인덱스버퍼.Add(정보주소.하부03검사트리거, 0);
            this.인덱스버퍼.Add(정보주소.셔틀01검사트리거, 0);
            this.인덱스버퍼.Add(정보주소.셔틀02검사트리거, 0);
            this.인덱스버퍼.Add(정보주소.셔틀03검사트리거, 0);
        }

        // 검사자료 로드 후 수행해야 함
        public void 인덱스리셋확인()
        {
            if (Global.검사자료?.Count < 1)
            {
                //Debug.WriteLine("인덱스 리셋");
                //this.검사번호리셋 = true;
            }
        }
        //public void 생산수량전송() => this.생산수량정보 = Global.모델자료.선택모델.전체갯수;
        #endregion

        #region Get / Set 함수
        private Int32[] ReadDeviceRandom(List<String> 주소, out Int32 오류코드) => ReadDeviceRandom(주소.ToArray(), out 오류코드);
        private Int32[] ReadDeviceRandom(String[] 주소, out Int32 오류코드)
        {
            Int32[] 자료 = new Int32[주소.Length];
            오류코드 = PLC.ReadDeviceRandom(String.Join("\n", 주소), 주소.Length, out 자료[0]);
            return 자료;
        }

        private Int32 GetDevice(String Address, out Int32 오류코드)
        {
            Int32 value;
            오류코드 = PLC.GetDevice(Address, out value);
            return value;
        }

        private Boolean SetDevice(String Address, Int32 Data, out Int32 오류코드)
        {
            오류코드 = PLC.SetDevice(Address, Data);
            //Debug.WriteLine($"{Data}, {오류코드}", Address);
            return 오류코드 == 0;
        }

        #endregion

        #region 기본 클래스 및 함수
        private static UInt16 ToUInt16(BitArray bits)
        {
            UInt16 res = 0;
            for (int i = 0; i < 16; i++)
                if (bits[i]) res |= (UInt16)(1 << i);
            return res;
        }
        private static BitArray FromUInt16(UInt16 val) => new BitArray(BitConverter.GetBytes(val));

        public class AddressAttribute : Attribute
        {
            public String Address = String.Empty;
            public Int32 Delay = 0;
            public AddressAttribute(String address) => this.Address = address;
            public AddressAttribute(String address, Int32 delay)
            {
                this.Address = address;
                this.Delay = delay;
            }
        }

        private class 통신정보
        {
            public 정보주소 구분;
            public Int32 순번 = 0;
            public Int32 정보 = 0;
            public String 주소 = String.Empty;
            public DateTime 시간 = DateTime.MinValue;
            public Int32 지연 = 0;
            public Boolean 변경 = false;

            public 통신정보(정보주소 구분)
            {
                this.구분 = 구분;
                this.순번 = (Int32)구분;
                AddressAttribute a = Utils.GetAttribute<AddressAttribute>(구분);
                this.주소 = a.Address;
                this.지연 = a.Delay;
            }

            public Boolean Passed()
            {
                if (this.지연 <= 0) return true;
                return (DateTime.Now - 시간).TotalMilliseconds >= this.지연;
            }

            public Boolean Set(Int32 val, Boolean force = false)
            {
                if (this.정보.Equals(val) || !force && !this.Passed())
                {
                    this.변경 = false;
                    return false;
                }

                this.정보 = val;
                this.시간 = DateTime.Now;
                this.변경 = true;
                return true;
            }
        }
        private class 통신자료 : Dictionary<정보주소, 통신정보>
        {
            private Action<정보주소, Int32> Transmit;
            public String[] 주소목록;
            public 통신자료()
            {
                List<String> 주소 = new List<String>();
                foreach (정보주소 구분 in typeof(정보주소).GetEnumValues())
                {
                    통신정보 정보 = new 통신정보(구분);
                    if (정보.순번 < 0) continue;
                    this.Add(구분, 정보);
                    주소.Add(정보.주소);
                }
                this.주소목록 = 주소.ToArray();
            }

            public void Init(Action<정보주소, Int32> transmit) => this.Transmit = transmit;

            public String Address(정보주소 구분)
            {
                if (!this.ContainsKey(구분)) return String.Empty;
                return this[구분].주소;
            }

            public Int32 Get(정보주소 구분)
            {
                if (!this.ContainsKey(구분)) return 0;
                return this[구분].정보;
            }

            public void Set(Int32[] 자료)
            {
                foreach (통신정보 정보 in this.Values)
                {
                    Int32 val = 자료[정보.순번];
                    Boolean 변경 = 정보.Set(val);
                }
            }

            // Return : Changed
            public Boolean Set(정보주소 구분, Int32 value)
            {
                if (!this[구분].Set(value, true)) return false;
                this.Transmit?.Invoke(구분, value);
                return true;
            }

            public void SetDelay(정보주소 구분, Int32 value, Int32 resetTime)
            {
                if (resetTime <= 0)
                {
                    if (!this[구분].Set(value, true)) return;
                    this.Transmit?.Invoke(구분, value);
                }
                Task.Run(() =>
                {
                    Task.Delay(resetTime).Wait();
                    if (this[구분].Set(value, true))
                        this.Transmit?.Invoke(구분, value);
                });
            }

            public Boolean Changed(정보주소 구분) => this[구분].변경;
            public Boolean Firing(정보주소 구분, Boolean 상태, out Boolean 현재, out Boolean 변경)
            {
                현재 = ToBool(this[구분].정보);
                변경 = this[구분].변경;
                return 변경 && 현재 == 상태;
            }

            public Dictionary<정보주소, Int32> Changes(정보주소 시작, 정보주소 종료) => this.Changes((Int32)시작, (Int32)종료);
            public Dictionary<정보주소, Int32> Changes(Int32 시작, Int32 종료)
            {
                Dictionary<정보주소, Int32> 변경 = new Dictionary<정보주소, Int32>();
                foreach (정보주소 구분 in typeof(정보주소).GetEnumValues())
                {
                    Int32 번호 = (Int32)구분;
                    if (번호 < 시작 || 번호 > 종료 || !this[구분].변경) continue;
                    변경.Add(구분, this[구분].정보);
                }
                return 변경;
            }
        }

        #endregion
    }
}