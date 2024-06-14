using MvUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using static HKCBusbarInspection.Schemas.검사자료;

namespace HKCBusbarInspection.Schemas
{
    partial class 신호제어
    {
        private DateTime 오류알림시간 = DateTime.Today.AddDays(-1);
        private Int32 오류알림간격 = 30; // 초
        private String 셔틀번호변수이름 = "셔틀번호";

        private Single 치수검사Gain = 15;
        private Single 표면검사Gain = (Single)29.5;

        public enum 셔틀위치번호
        {
            [Description("0")]
            Shuttle01 = 0,
            [Description("1")]
            Shuttle02 = 1,
            [Description("2")]
            Shuttle03 = 2,
        }

        public void 통신오류알림(Int32 오류코드)
        {
            if (오류코드 == 0)
            {
                this.정상여부 = true;
                return;
            }
            if ((DateTime.Now - this.오류알림시간).TotalSeconds < this.오류알림간격) return;
            this.오류알림시간 = DateTime.Now;
            this.정상여부 = false;
            this.통신상태알림?.Invoke();
            Global.오류로그(로그영역, "Communication", $"[{오류코드.ToString("X8")}] Communication error.", false);
        }

        private Boolean 입출자료갱신()
        {
            DateTime 현재 = DateTime.Now;
            // 입출자료 갱신
            Int32[] 자료 = ReadDeviceRandom(입출자료.주소목록, out Int32 오류);
            if (오류 != 0)
            {
                통신오류알림(오류);
                //Common.DebugWriteLine("입출자료갱신", 로그구분.오류, $"PLC Error.");
                return false;
            }
            this.입출자료.Set(자료);
            //Debug.WriteLine("오류없음.");
            return true;
        }

        private Boolean 입출자료분석()
        {
            if (Global.환경설정.동작구분 == 동작구분.LocalTest) return 테스트수행();
            if (!입출자료갱신()) return false;
            입출변경확인();
            검사위치확인();
            제품검사수행();
            장치상태확인();
            원점복귀확인();
            통신핑퐁수행();
            return true;
        }
        private void 원점복귀확인()
        {
            if (this.입출자료.Changed(정보주소.원점복귀완료) && this.원점복귀완료)
            {
                this.출력자료리셋();
                this.원점복귀알림?.Invoke();
            }
        }

        private void 입출변경확인()
        {
            Dictionary<정보주소, Int32> 변경 = this.입출자료.Changes(정보주소.트레이검사트리거, 정보주소.마스터모드);
            if (변경.Count < 1) return;

            this.입출변경알림?.Invoke();
        }

        private void 장치상태확인()
        {
            if (this.입출자료.Changed(정보주소.수동모드) || this.입출자료.Changed(정보주소.자동운전))
                this.동작상태알림?.Invoke();
        }

        // 검사위치 변경 확인
        private void 검사위치확인()
        {
            Dictionary<정보주소, Int32> 변경 = this.입출자료.Changes(정보주소.트레이검사트리거, 정보주소.셔틀03표면검사트리거);
            if (변경.Count < 1) return;

            this.검사위치알림?.Invoke();
        }

        private void 제품검사수행()
        {
            영상촬영수행();
            잉크마킹수행();
            검사결과전송();
        }

        // 카메라 별 현재 검사 위치의 검사번호를 요청
        public Int32 촬영위치번호(카메라구분 구분, Int32 순서, Boolean 표면검사)
        {
            if (구분 == 카메라구분.Cam01 || 구분 == 카메라구분.Cam02 || 구분 == 카메라구분.Cam03)
            {
                if (표면검사)
                {
                    if (순서 == 1) return this.인덱스버퍼[정보주소.셔틀01표면검사트리거];
                    if (순서 == 2) return this.인덱스버퍼[정보주소.셔틀02표면검사트리거];
                    if (순서 == 3) return this.인덱스버퍼[정보주소.셔틀03표면검사트리거];
                }
                else 
                {
                    if (순서 == 1) return this.인덱스버퍼[정보주소.셔틀01치수검사트리거];
                    if (순서 == 2) return this.인덱스버퍼[정보주소.셔틀02치수검사트리거];
                    if (순서 == 3) return this.인덱스버퍼[정보주소.셔틀03치수검사트리거];
                }
            }
            if (구분 == 카메라구분.Cam04)
            {
                if (순서 == 1) return this.인덱스버퍼[정보주소.하부01검사트리거];
                if (순서 == 2) return this.인덱스버퍼[정보주소.하부02검사트리거];
                if (순서 == 3) return this.인덱스버퍼[정보주소.하부03검사트리거];
            }

            return 0;
        }

        // 트리거 입력 시 현재 인덱스를 버퍼에 입력하고 검사 수행 시 해당 버퍼의 인덱스를 기준으로 검사
        private Int32 검사위치번호(정보주소 구분)
        {
            if (!this.입출자료.Firing(구분, true, out Boolean 현재, out Boolean 변경))
            {
                return -1;
            }

            Int32 index = 0;

            if (구분 == 정보주소.하부01검사트리거) index = this.하부01인덱스; 
            if (구분 == 정보주소.하부02검사트리거) index = this.하부02인덱스;
            if (구분 == 정보주소.하부03검사트리거) index = this.하부03인덱스;

            if (구분 == 정보주소.셔틀01치수검사트리거) index = this.셔틀01인덱스;
            if (구분 == 정보주소.셔틀02치수검사트리거) index = this.셔틀02인덱스;
            if (구분 == 정보주소.셔틀03치수검사트리거) index = this.셔틀03인덱스;

            if (구분 == 정보주소.셔틀01표면검사트리거) index = this.셔틀01인덱스;
            if (구분 == 정보주소.셔틀02표면검사트리거) index = this.셔틀02인덱스;
            if (구분 == 정보주소.셔틀03표면검사트리거) index = this.셔틀03인덱스;

            if (구분 == 정보주소.셔틀01결과값요청) index = this.셔틀01인덱스;
            if (구분 == 정보주소.셔틀02결과값요청) index = this.셔틀02인덱스;
            if (구분 == 정보주소.셔틀03결과값요청) index = this.셔틀03인덱스;

            this.인덱스버퍼[구분] = index;

            if (index == 0) Global.경고로그(로그영역, 구분.ToString(), $"해당 위치에 검사할 제품의 Index가 없습니다.", false);
            else Common.DebugWriteLine("검사위치번호", 로그구분.정보, $"{구분} => 인덱스[ {index} ]");

            return index;
        }

        public List<Int32> 검사중인항목()
        {
            List<Int32> 대상 = new List<Int32>();
            Int32 시작 = (Int32)정보주소.셔틀03인덱스;
            Int32 종료 = (Int32)정보주소.하부01인덱스;
            for (Int32 i = 종료; i >= 시작; i--)
            {
                정보주소 구분 = (정보주소)i;
                if (this.입출자료[구분].정보 <= 0) continue;
                대상.Add(this.입출자료[구분].정보);
            }
            return 대상;
        }

        private void 카메라이미지초기화()
        {
            Global.그랩제어.GetItem(카메라구분.Cam01).MatImageList.Clear();
            Global.그랩제어.GetItem(카메라구분.Cam02).MatImageList.Clear();
            Global.그랩제어.GetItem(카메라구분.Cam03).MatImageList.Clear();
        }

        private void 셔틀검사중설정()
        {
            Global.그랩제어.GetItem(카메라구분.Cam01).검사중 = true;
            Global.그랩제어.GetItem(카메라구분.Cam02).검사중 = true;
            Global.그랩제어.GetItem(카메라구분.Cam03).검사중 = true;
        }

        private void 셔틀카메라활성화()
        {
            Global.그랩제어.GetItem(카메라구분.Cam01).Active();
            Global.그랩제어.GetItem(카메라구분.Cam02).Active();
            Global.그랩제어.GetItem(카메라구분.Cam03).Active();
        }

        private void 셔틀전체카메라촬영()
        {
            Global.그랩제어.GetItem(카메라구분.Cam01).SoftwareTrigger();
            Global.그랩제어.GetItem(카메라구분.Cam02).SoftwareTrigger();
            Global.그랩제어.GetItem(카메라구분.Cam03).SoftwareTrigger();
        }

        private void 상부치수검사수행()
        {
            Int32 셔틀01검사번호 = this.검사위치번호(정보주소.셔틀01치수검사트리거);
            Int32 셔틀02검사번호 = this.검사위치번호(정보주소.셔틀02치수검사트리거);
            Int32 셔틀03검사번호 = this.검사위치번호(정보주소.셔틀03치수검사트리거);

            if (셔틀01검사번호 > 0)
            {
                Global.VM제어.글로벌변수제어.SetValue(셔틀번호변수이름, Utils.GetDescription(셔틀위치번호.Shuttle01));
                new Thread(() =>
                {
                    Common.DebugWriteLine("상부01치수트리거", 로그구분.정보, $"상부01치수트리거 들어옴");
                    Global.그랩제어.GetItem(카메라구분.Cam01).표면검사중 = false;
                    카메라이미지초기화();
                    Global.그랩제어.GetItem(카메라구분.Cam01).대비적용(this.치수검사Gain);
                    Global.조명제어.TurnOff(사용구분.상부표면검사);
                    Global.조명제어.TurnOn(사용구분.상부치수검사);
                    셔틀검사중설정();
                    셔틀전체카메라촬영();
                })
                { Priority = ThreadPriority.Highest }.Start();
            }
            if (셔틀02검사번호 > 0)
            {
                Global.VM제어.글로벌변수제어.SetValue(셔틀번호변수이름, Utils.GetDescription(셔틀위치번호.Shuttle02));
                new Thread(() =>
                {
                    Common.DebugWriteLine("상부02치수트리거", 로그구분.정보, $"상부02치수트리거 들어옴");
                    Global.그랩제어.GetItem(카메라구분.Cam01).표면검사중 = false;
                    Global.그랩제어.GetItem(카메라구분.Cam01).대비적용(this.치수검사Gain);
                    Global.조명제어.TurnOff(사용구분.상부표면검사);
                    Global.조명제어.TurnOn(사용구분.상부치수검사);
                    셔틀검사중설정();
                    셔틀전체카메라촬영();
                })
                { Priority = ThreadPriority.Highest }.Start();
            }
            if (셔틀03검사번호 > 0)
            {
                Global.VM제어.글로벌변수제어.SetValue(셔틀번호변수이름, Utils.GetDescription(셔틀위치번호.Shuttle03));
                new Thread(() =>
                {
                    Common.DebugWriteLine("상부03치수트리거", 로그구분.정보, $"상부03치수트리거 들어옴");
                    Global.그랩제어.GetItem(카메라구분.Cam01).표면검사중 = false;
                    Global.그랩제어.GetItem(카메라구분.Cam01).대비적용(this.치수검사Gain);
                    Global.조명제어.TurnOff(사용구분.상부표면검사);
                    Global.조명제어.TurnOn(사용구분.상부치수검사);
                    셔틀검사중설정();
                    셔틀전체카메라촬영();
                })
                { Priority = ThreadPriority.Highest }.Start();
            }
        }
        private void 상부표면검사수행()
        {
            Int32 셔틀01검사번호 = this.검사위치번호(정보주소.셔틀01표면검사트리거);
            Int32 셔틀02검사번호 = this.검사위치번호(정보주소.셔틀02표면검사트리거);
            Int32 셔틀03검사번호 = this.검사위치번호(정보주소.셔틀03표면검사트리거);

            if (셔틀01검사번호 > 0)
            {
                Common.DebugWriteLine("상부01표면트리거", 로그구분.정보, $"상부01표면트리거 들어옴");
                Global.그랩제어.GetItem(카메라구분.Cam01).표면검사중 = true;
                Global.그랩제어.GetItem(카메라구분.Cam01).대비적용(this.표면검사Gain);
                Global.조명제어.TurnOff(사용구분.상부치수검사);
                Global.조명제어.TurnOn(사용구분.상부표면검사);
                new Thread(() =>
                {
                    Global.그랩제어.GetItem(카메라구분.Cam01).SoftwareTrigger();
                })
                { Priority = ThreadPriority.Highest }.Start();
            }
            if (셔틀02검사번호 > 0)
            {
                Common.DebugWriteLine("상부02표면트리거", 로그구분.정보, $"상부02표면트리거 들어옴");
                Global.그랩제어.GetItem(카메라구분.Cam01).표면검사중 = true;
                Global.그랩제어.GetItem(카메라구분.Cam01).대비적용(this.표면검사Gain);
                Global.조명제어.TurnOff(사용구분.상부치수검사);
                Global.조명제어.TurnOn(사용구분.상부표면검사);
                new Thread(() =>
                {
                    Global.그랩제어.GetItem(카메라구분.Cam01).SoftwareTrigger();
                })
                { Priority = ThreadPriority.Highest }.Start();
            }
            if (셔틀03검사번호 > 0)
            {
                Common.DebugWriteLine("상부03표면트리거", 로그구분.정보, $"상부03표면트리거 들어옴");
                Global.그랩제어.GetItem(카메라구분.Cam01).대비적용(this.표면검사Gain);
                Global.조명제어.TurnOff(사용구분.상부치수검사);
                Global.조명제어.TurnOn(사용구분.상부표면검사);
                Global.그랩제어.GetItem(카메라구분.Cam01).표면검사중 = true;
                new Thread(() =>
                {
                    Global.그랩제어.GetItem(카메라구분.Cam01).SoftwareTrigger();
                })
                { Priority = ThreadPriority.Highest }.Start();
            }
        }
        private void 하부표면검사수행()
        {
            Int32 하부01검사번호 = this.검사위치번호(정보주소.하부01검사트리거);
            Int32 하부02검사번호 = this.검사위치번호(정보주소.하부02검사트리거);
            Int32 하부03검사번호 = this.검사위치번호(정보주소.하부03검사트리거);

            if (하부01검사번호 > 0)
            {
                new Thread(() =>
                {
                    this.하부01검사트리거 = false;
                    Common.DebugWriteLine("하부01트리거", 로그구분.정보, $"하부01트리거 들어옴");
                    Global.조명제어.TurnOn(사용구분.하부표면검사);//Global.조명제어.TurnOn(카메라구분.Cam04);
                    Global.그랩제어.GetItem(카메라구분.Cam04).MatImageList.Clear();
                    Global.모델자료.선택모델.검사시작(하부01검사번호);
                    Global.검사자료.검사시작(하부01검사번호, true);
                })
                { Priority = ThreadPriority.Highest }.Start();
            }
            if (하부02검사번호 > 0)
            {
                new Thread(() =>
                {
                    this.하부02검사트리거 = false;
                    Common.DebugWriteLine("하부02트리거", 로그구분.정보, $"하부02트리거 들어옴");
                    Global.모델자료.선택모델.검사시작(하부02검사번호);
                    Global.검사자료.검사시작(하부02검사번호, true);
                })
                { Priority = ThreadPriority.Highest }.Start();
            }
            if (하부03검사번호 > 0)
            {
                new Thread(() =>
                {
                    this.하부03검사트리거 = false;
                    Common.DebugWriteLine("하부03트리거", 로그구분.정보, $"하부03트리거 들어옴");
                    Global.모델자료.선택모델.검사시작(하부03검사번호);
                    Global.검사자료.검사시작(하부03검사번호, true);
                }).Start();
            }
        }

        private void 잉크마킹수행()
        {
            if (this.입출자료.Changed(정보주소.잉크젯마킹신호트리거) && this.잉크젯마킹신호트리거)
            {
                
            }
        }
        
        private void 영상촬영수행()
        {
            하부표면검사수행();
            상부치수검사수행();
            상부표면검사수행();
        }

        public Boolean 검사결과(Int32 검사번호)
        {
            if (검사번호 <= 0) return false;

            Global.모델자료.선택모델.검사종료(검사번호);
            검사결과 검사 = Global.검사자료.검사결과계산(검사번호, true);

            // 강제배출
            if (Global.환경설정.강제배출)
            {
                if (Global.환경설정.랜덤배출)
                {
                    String[] 조건 = { "NG", "OK" };
                    Random 랜덤 = new Random();

                    String 선택결과 = 조건[랜덤.Next(조건.Length)];
                    Common.DebugWriteLine("랜덤결과", 로그구분.정보, $"랜덤결과 : {선택결과}");

                    Global.검사자료.검사완료알림함수(검사);
                    if (선택결과 == "OK") return true;
                    else return false;
                }
                else
                {
                    Global.검사자료.검사완료알림함수(검사);
                    Common.DebugWriteLine("검사결과[강제배출]", 로그구분.정보, $"Index [{검사번호}] => {Global.환경설정.양품불량}");
                    return Global.환경설정.양품불량;
                }
            }
            if (검사 == null)
            {
                Global.검사자료.검사완료알림함수(검사);
                Common.DebugWriteLine("검사결과[강제배출]", 로그구분.정보, $"Index [{검사번호}] => false");
                return false;
            }
            // 배출 수행
            Global.검사자료.검사완료알림함수(검사);
            Common.DebugWriteLine("검사결과", 로그구분.정보, $"Index [{검사번호}] => {검사.측정결과 == 결과구분.OK}");
            return 검사.측정결과 == 결과구분.OK;
        }

        // 최종 검사 결과 보고
        private void 검사결과전송()
        {
            Int32 셔틀01검사번호 = this.검사위치번호(정보주소.셔틀01결과값요청);
            Int32 셔틀02검사번호 = this.검사위치번호(정보주소.셔틀02결과값요청);
            Int32 셔틀03검사번호 = this.검사위치번호(정보주소.셔틀03결과값요청);

            if (셔틀01검사번호 > 0)
            {
                if (셔틀01검사번호 <= 0) return;

                Common.DebugWriteLine("검사결과요청", 로그구분.정보, $"인덱스[ {셔틀01검사번호} ] 결과값 요청신호 들어옴");

                this.셔틀01치수검사트리거 = false;
                this.셔틀01표면검사트리거 = false;
                this.셔틀01결과값요청신호 = false;

                this.셔틀01결과신호 = 검사결과(셔틀01검사번호);
            }
            if (셔틀02검사번호 > 0)
            {
                if (셔틀02검사번호 <= 0) return;

                Common.DebugWriteLine("검사결과요청", 로그구분.정보, $"인덱스[ {셔틀02검사번호} ] 결과값 요청신호 들어옴");

                this.셔틀02치수검사트리거 = false;
                this.셔틀02표면검사트리거 = false;
                this.셔틀02결과값요청신호 = false;

                this.셔틀02결과신호 = 검사결과(셔틀02검사번호);
            }
            if (셔틀03검사번호 > 0)
            {
                if (셔틀03검사번호 <= 0) return;

                Common.DebugWriteLine("검사결과요청", 로그구분.정보, $"인덱스[ {셔틀03검사번호} ] 결과값 요청신호 들어옴");

                this.셔틀03치수검사트리거 = false;
                this.셔틀03표면검사트리거 = false;
                this.셔틀03결과값요청신호 = false;

                this.셔틀03결과신호 = 검사결과(셔틀03검사번호);
            }
        }

        // 핑퐁
        private void 통신핑퐁수행()
        {
            if (!this.입출자료[정보주소.통신확인전송].Passed()) return;
            if (this.시작일시.Day != DateTime.Today.Day)
            {
                this.시작일시 = DateTime.Now;
                //this.검사번호리셋 = true;
                Global.모델자료.선택모델.날짜변경();
            }

            this.통신확인핑퐁 = !this.통신확인핑퐁;
            //Debug.WriteLine($"통신확인핑퐁 : {this.통신확인핑퐁}");
            this.통신상태알림?.Invoke();
            this.입출변경알림?.Invoke();
            //Boolean 연결신호확인 = 신호읽기(정보주소.통신확인전송);
            //정보쓰기(정보주소.통신확인전송, !연결신호확인);
            //if (this.입출자료.Changed(정보주소.통신확인수신))
            //{
            //    this.통신확인핑퐁 = !this.통신확인핑퐁;
            //    this.통신상태알림?.Invoke();
            //}
        }
        private Boolean 테스트수행()
        {
            통신핑퐁수행();
            return true;
        }
    }
}
