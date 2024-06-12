using HKCBusbarInspection.Schemas;
using HKCBusbarInspection;
using Newtonsoft.Json;
using System;

namespace HKCBusbarInspection.Schemas
{
    public partial class 조명제어
    {
        [JsonIgnore]
        private LCP24_150U 조명컨트롤러;

        [JsonIgnore]
        public Boolean 정상여부 => 조명컨트롤러.IsOpen();

        public void Init()
        {
            this.조명컨트롤러 = new LCP24_150U() { 포트 = 직렬포트.COM3, 통신속도 = 9600 };

            this.조명컨트롤러.Init();

            //상부치수검사시 : 4면조명끄고 다키기

            //상부카메라 조명
            this.Add(new 조명정보(카메라구분.Cam01, 조명컨트롤러) { 채널 = 조명채널.CH08, 밝기 = 100, 사용구분 = 사용구분.상부치수검사 }); //BackLight
            this.Add(new 조명정보(카메라구분.Cam01, 조명컨트롤러) { 채널 = 조명채널.CH09, 밝기 = 100, 사용구분 = 사용구분.상부표면검사 }); //4면조명
            this.Add(new 조명정보(카메라구분.Cam01, 조명컨트롤러) { 채널 = 조명채널.CH10, 밝기 = 100, 사용구분 = 사용구분.상부표면검사 }); //4면조명

            //측면카메라 조명
            this.Add(new 조명정보(카메라구분.Cam02, 조명컨트롤러) { 채널 = 조명채널.CH03, 밝기 = 100, 사용구분 = 사용구분.상부치수검사 });
            this.Add(new 조명정보(카메라구분.Cam02, 조명컨트롤러) { 채널 = 조명채널.CH04, 밝기 = 100, 사용구분 = 사용구분.상부치수검사 });
            this.Add(new 조명정보(카메라구분.Cam02, 조명컨트롤러) { 채널 = 조명채널.CH05, 밝기 = 100, 사용구분 = 사용구분.상부치수검사 });
            this.Add(new 조명정보(카메라구분.Cam02, 조명컨트롤러) { 채널 = 조명채널.CH06, 밝기 = 100, 사용구분 = 사용구분.상부치수검사 }); //BackLight
            this.Add(new 조명정보(카메라구분.Cam02, 조명컨트롤러) { 채널 = 조명채널.CH11, 밝기 = 100, 사용구분 = 사용구분.상부치수검사 }); //4면조명
            this.Add(new 조명정보(카메라구분.Cam02, 조명컨트롤러) { 채널 = 조명채널.CH12, 밝기 = 100, 사용구분 = 사용구분.상부치수검사 }); //4면조명

            //LPoint카메라 조명
            this.Add(new 조명정보(카메라구분.Cam03, 조명컨트롤러) { 채널 = 조명채널.CH07, 밝기 = 100, 사용구분 = 사용구분.상부치수검사 });

            //하부카메라조명
            this.Add(new 조명정보(카메라구분.Cam04, 조명컨트롤러) { 채널 = 조명채널.CH01, 밝기 = 100, 사용구분 = 사용구분.하부표면검사 }); 
            this.Add(new 조명정보(카메라구분.Cam04, 조명컨트롤러) { 채널 = 조명채널.CH02, 밝기 = 100, 사용구분 = 사용구분.하부표면검사 });

            this.Load();
            if (Global.환경설정.동작구분 != 동작구분.Live) return;
            this.Open();
            this.Set();
        }
    }
}
