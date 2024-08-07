﻿using MVSol.Enc852;
using MVSol.IO.Ports;
using Newtonsoft.Json;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Navigation;
using static HKCBusbarInspection.Schemas.신호제어;

namespace HKCBusbarInspection.Schemas
{
    public class 트리거보드제어
    {
        public event Global.BaseEvent 트리거보드상태알림;
        public event Global.BaseEvent 트리거보드연결알림;
        public delegate void 엔코더위치변경(Int32 현재위치, Int32 위치);
        public delegate void 트리거횟수변경(Decimal 현재횟수, Int32 위치);

        public event 엔코더위치변경 엔코더위치알림;
        public event 트리거횟수변경 트리거카운트변경알림;

        private Boolean 작업여부 = false;
        public Boolean 정상여부 = false;
        private const Int32 상태체크간격 = 10;

        public enum 트리거번호
        {
            Trigger0,
            Trigger1,
            Trigger2,
            Trigger3,
        }
        public enum 엔코더번호
        {
            Encoder0,
            Encoder1,
        }

        [JsonProperty("TriggerBoard"), Translation("TriggerBoard", "트리거보드")]
        public MVEnc852v3Comm 트리거보드 { get; set; }
        [JsonProperty("Port"), Translation("Port", "포트")]
        public 직렬포트 포트 { get; set; } = 직렬포트.COM2;
        [JsonProperty("FirmWareVersion"), Translation("FirmWareVersion", "펌웨어버전")]
        public String 펌웨어버전 { get; set; }
        [JsonProperty("LogicVersion"), Translation("LogicVersion", "로직버전")]
        public String 로직버전 { get; set; }
        [JsonIgnore]
        public List<엔코더정보> 엔코더들 { get; set; }
        [JsonIgnore]
        public List<트리거정보> 트리거들 { get; set; }

        [JsonIgnore]
        public const String 로그영역 = "트리거보드장치";

        public void Init()
        {
            if (포트 == 직렬포트.None) return;

            this.포트 = 직렬포트.COM2;
            this.트리거보드 = new MVEnc852v3Comm(this.포트.ToString());
            try
            {
                if (!this.트리거보드.IsOpen)
                {
                    this.트리거보드.Open();
                    this.Load();
                    this.트리거보드연결알림?.Invoke();
                    Global.정보로그(로그영역, "초기화", $"트리거보드 연결 완료. [ {this.트리거보드.PortName} ]", false);
                }
            }
            catch (Exception ex)
            {
                this.트리거보드 = null;
                Global.오류로그(로그영역, "연결오류", $"트리거보드 연결 실패. [ {ex.Message} ]", true);
            }
        }

        public bool Open()
        {
            if (this.트리거보드 == null)
            {
                Global.오류로그(로그영역, "Open", "트리거보드 Open 실패.", true);
                return false;
            }

            return this.트리거보드.Open();
        }

        public void Load()
        {
            this.펌웨어버전 = this.트리거보드.GetFirmVersion();
            this.로직버전 = this.트리거보드.GetLogicVersion();

            this.트리거들 = new List<트리거정보>();
            this.엔코더들 = new List<엔코더정보>();

            this.트리거들.Add(new 트리거정보((Int32)트리거번호.Trigger0));
            this.트리거들.Add(new 트리거정보((Int32)트리거번호.Trigger1));
            this.트리거들.Add(new 트리거정보((Int32)트리거번호.Trigger2));
            this.트리거들.Add(new 트리거정보((Int32)트리거번호.Trigger3));

            this.엔코더들.Add(new 엔코더정보((Int32)엔코더번호.Encoder0));
            this.엔코더들.Add(new 엔코더정보((Int32)엔코더번호.Encoder1));

            foreach (트리거정보 트리거 in 트리거들)
                트리거.횟수 = this.ReadTriggerCount((트리거번호)트리거.번호);

            foreach (엔코더정보 엔코더 in 엔코더들)
                엔코더.현재위치 = this.ReadPosition((엔코더번호)엔코더.번호);
        }

        public void Close()
        {
            this.트리거보드?.Close();
            this.트리거보드?.Dispose();
            this.트리거보드 = null;
            //this.트리거보드상태알림?.Invoke();
        }

        public void ClearAll()
        {
            this.트리거보드?.ClearTriggerCountAll();
            this.트리거보드?.ClearEncoderPositionAll();
        }

        public void ClearAllPosition() => this.트리거보드.ClearEncoderPositionAll();
        public void ClearAllTrigger() => this.트리거보드.ClearTriggerCountAll();
        public Int32 ReadPosition(엔코더번호 번호) => this.트리거보드.GetEncoderPosition((Int32)번호);
        public Decimal ReadTriggerCount(트리거번호 번호) => this.트리거보드.GetTriggerCount((Int32)번호);
        public Int32 ReadStartPosition(트리거번호 번호) => this.트리거보드.GetTriggerPositionStart((Int32)번호);
        public Int32 ReadEndPosition(트리거번호 번호) => this.트리거보드.GetTriggerPositionEnd((Int32)번호);
        public void SetStartPosition(트리거번호 번호, Int32 value) => this.트리거보드.SetTriggerPositionStart((Int32)번호, value);
        public void SetEndPosition(트리거번호 번호, Int32 value) => this.트리거보드.SetTriggerPositionEnd((Int32)번호, value);

        public class 트리거정보
        {
            public Int32 번호 { get; set; }
            public Decimal 횟수 { get; set; } = 0;
            public Int32 시작점 { get; set; } = 0;
            public Int32 종료점 { get; set; } = 0;

            public 트리거정보(Int32 번호)
            {
                this.번호 = 번호;
            }
        }
        public class 엔코더정보
        {
            public Int32 번호 { get; set; }
            public Int32 현재위치 { get; set; } = 0;

            public 엔코더정보(Int32 번호)
            {
                this.번호 = 번호;
            }
        }
    }
}
