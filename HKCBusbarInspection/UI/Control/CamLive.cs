using DevExpress.XtraEditors;
using HKCBusbarInspection.Schemas;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKCBusbarInspection.UI.Control
{
    public partial class CamLive : DevExpress.XtraEditors.XtraUserControl
    {
        private 카메라구분 카메라 = 카메라구분.None;

        public CamLive() => InitializeComponent();

        public void Init(카메라구분 구분)
        {
            this.카메라 = 구분;
            b라이브시작.Click += 라이브시작;
            b라이브종료.Click += 라이브종료;
            this.p카메라화면.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;

            Global.그랩제어.그랩완료보고 += 그랩완료보고;
        }

        private void 그랩완료보고(그랩장치 장치)
        {
            if (this.InvokeRequired) { this.BeginInvoke((Action)(() => 그랩완료보고(장치))); return; }

            if (장치.구분 == 카메라구분.Cam01)
                this.p카메라화면.Image = 장치.MatImageRotate().ToBitmap();
            else
                this.p카메라화면.Image = 장치.MatImage().ToBitmap();
        }

        private void 라이브종료(object sender, EventArgs e)
        {
            Global.그랩제어.GetItem(카메라).StopLive();
        }

        private void 라이브시작(object sender, EventArgs e)
        {
            Global.그랩제어.GetItem(카메라).StartLive();
        }
    }
}
