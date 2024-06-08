using DevExpress.XtraEditors;
using HKCBusbarInspection.Schemas;
using System.Collections.Generic;
using System;
using static HKCBusbarInspection.Schemas.신호제어;

namespace HKCBusbarInspection.UI.Control
{
    public partial class IOControl : XtraUserControl
    {
        public IOControl() => InitializeComponent();

        public void Init()
        {
            this.GridControl1.DataSource = new 입력신호자료();
             this.입출변경알림();
            Global.신호제어.입출변경알림 += 입출변경알림;
        }
        private void 입출변경알림()
        {
            if (this.InvokeRequired) { this.Invoke(new Action(입출변경알림)); return; }
            GridView1.RefreshData();
        }

        private class 입력신호자료 : List<입력신호정보>
        {
            public 입력신호자료()
            {
                foreach (신호제어.정보주소 번호 in typeof(신호제어.정보주소).GetEnumValues())
                    this.Add(new 입력신호정보() { 구분 = 번호 });
            }
        } 

        private class 입력신호정보
        {
            public 신호제어.정보주소 구분 { get; set; }
            public Int32 번호 { get { return (Int32)구분; } }
            public String 주소 { get { return MvUtils.Utils.GetAttribute<AddressAttribute>(구분).Address; } }
            public String 정보 { get { return Global.신호제어.정보읽기(구분).ToString(); } }
        }
    }
}
