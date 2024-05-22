using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCBusbarInspection.Schemas
{
    public class 유저정보
    {
        public enum 유저권한구분
        {
            [Description("Nothing"), Translation("Nothing", "없음")]
            없음 = 0,
            [Description("Worker"), Translation("Worker", "작업자")]
            작업자 = 3,
            [Description("Manager"), Translation("Manager", "관리자")]
            관리자 = 5,
            [Description("Admin"), Translation("Admin", "시스템")]
            시스템 = 9,
        }
    }
}
