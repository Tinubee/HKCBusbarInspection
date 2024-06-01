using DevExpress.XtraEditors;
using HKCBusbarInspection.Schemas;
using OpenCvSharp.Extensions;
using System;
using System.Diagnostics;

namespace HKCBusbarInspection.UI.Control
{
    public partial class CamLive : XtraUserControl
    {
        private 카메라구분 카메라 = 카메라구분.None;

        public CamLive() => InitializeComponent();

        public void Init(카메라구분 구분)
        {
            this.카메라 = 구분;
            b라이브시작.Click += 라이브시작;
            b라이브종료.Click += 라이브종료;
            this.eLive.ModuleSource = Global.VM제어.GetItem(Flow구분.Live).graphicsSetModuleTool;
            Global.그랩제어.그랩완료보고 += 그랩완료보고;
            버튼상태표시();
        }

        private void 버튼상태표시()
        {
            if (this.InvokeRequired) { this.BeginInvoke(new Action(버튼상태표시)); return; }

            b라이브시작.Enabled = !Global.그랩제어.GetItem(this.카메라).라이브;
            b라이브종료.Enabled = Global.그랩제어.GetItem(this.카메라).라이브;
        }

        private void 그랩완료보고(그랩장치 장치)
        {
            if (this.InvokeRequired) { this.BeginInvoke((Action)(() => 그랩완료보고(장치))); return; }

            if (장치.구분 == 카메라구분.Cam01)
            {
                Global.VM제어.GetItem(Flow구분.Live).Run(장치.MatImageRotate(), null, null);
            }
            else
                Global.VM제어.GetItem(Flow구분.Live).Run(장치.MatImage(), null, null);
        }

        private void 라이브종료(object sender, EventArgs e)
        {
            Global.그랩제어.GetItem(카메라).라이브 = false;
            버튼상태표시();
        }

        private void 라이브시작(object sender, EventArgs e)
        {
            Global.그랩제어.GetItem(카메라).라이브 = true;
            Global.그랩제어.GetItem(카메라).StartLive();
            버튼상태표시();
        }
    }
}
