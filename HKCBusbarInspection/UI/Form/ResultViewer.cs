using DevExpress.XtraEditors;
using HKCBusbarInspection.Schemas;
using System;
using System.Windows.Forms;

namespace HKCBusbarInspection.UI.Form
{
    public partial class ResultViewer : XtraForm
    {
        public 검사결과 결과 { get; set; } = null;
        public ResultViewer() => InitializeComponent();

        public ResultViewer(검사결과 결과)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.결과 = 결과;
            this.e결과뷰어.Init(Control.ResultInspection.ViewTypes.Manual);
            this.e카메라뷰어.Init(Control.ResultInspection.ViewTypes.Manual);
            this.Shown += FormShown;
        }


        private void FormShown(object sender, EventArgs e)
        {
            if (this.결과 == null) return;
            this.e결과뷰어.검사완료알림(this.결과);
        }
    }
}