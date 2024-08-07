﻿using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using HKCBusbarInspection.Schemas;
using System;
using System.Windows.Media.Media3D;

namespace HKCBusbarInspection.UI.Control
{
    public partial class ResultInspection : XtraUserControl
    {
        private LocalizationResultInspection 번역 = new LocalizationResultInspection();
        public ResultInspection() => InitializeComponent();

        public enum ViewTypes { Auto, Manual }
        private ViewTypes RunType = ViewTypes.Manual;
        BUSBAR3D Busbar = null;
        public void Init(ViewTypes runType = ViewTypes.Manual)
        {
            RunType = runType;
            Busbar = new BUSBAR3D();
            {
                Busbar.CameraPosition = new Point3D(0.6, -2.6, 967);
                Busbar.CameraLookDirection = new Vector3D(0, 0, -967);
                Busbar.CameraUpDirection = new Vector3D(0, 1, 0);
            }

            this.d검사결과.Text = this.번역.검사결과;
            this.e결과뷰어.Init(Busbar);

            this.e결과목록.Init();

            if (this.RunType == ViewTypes.Auto)
            {
                Global.검사자료.검사완료알림 += 검사완료알림;
                Global.검사자료.수동검사알림 += 수동검사알림;

                검사완료알림(Global.검사자료.현재검사찾기());
            }
        }

        public void 모델변경적용()
        {
            if (this.InvokeRequired) { this.BeginInvoke(new Action(모델변경적용)); return; }

            Busbar = new BUSBAR3D();
            {
                Busbar.CameraPosition = new Point3D(0.6, -2.6, 967);
                Busbar.CameraLookDirection = new Vector3D(0, 0, -967);
                Busbar.CameraUpDirection = new Vector3D(0, 1, 0);
            }

            this.e결과뷰어.Init(Busbar);
            this.e결과뷰어.RefreshViewport();

        }

        public void Close() { }

        public void 검사완료알림(검사결과 결과)
        {
            if (this.InvokeRequired) { this.BeginInvoke(new Action(() => { 검사완료알림(결과); })); return; }
      
            if (결과 == null)
            {
                Common.DebugWriteLine("검사완료알림", 로그구분.오류, $"검사결과가 없습니다.");
                return;
            }
            this.e결과뷰어.SetResults(결과);
            this.e결과목록.SetResults(결과);
            this.e측정결과.Appearance.ForeColor = 환경설정.결과표현색상(결과.측정결과);
            this.eCTQ결과.Properties.Appearance.ForeColor = 환경설정.결과표현색상(결과.CTQ결과);
            this.e외관결과.Properties.Appearance.ForeColor = 환경설정.결과표현색상(결과.외관결과);
            this.검사결과Bind.DataSource = 결과;
            this.검사결과Bind.ResetBindings(false);
        }
        public void 수동검사알림(카메라구분 카메라, 검사결과 결과)
        {
            if (this.InvokeRequired) { this.BeginInvoke(new Action(() => { 수동검사알림(카메라,결과); })); return; }

            if (결과 == null)
            {
                Common.DebugWriteLine("수동검사알림", 로그구분.오류, $"검사결과가 없습니다.");
                return;
            }
            this.e결과뷰어.SetResults(결과);
            this.e결과목록.SetResults(결과);
            this.e측정결과.Appearance.ForeColor = 환경설정.결과표현색상(결과.측정결과);
            this.eCTQ결과.Properties.Appearance.ForeColor = 환경설정.결과표현색상(결과.CTQ결과);
            this.e외관결과.Properties.Appearance.ForeColor = 환경설정.결과표현색상(결과.외관결과);
            this.검사결과Bind.DataSource = 결과;
            this.검사결과Bind.ResetBindings(false);
        }
        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView view = sender as GridView;
            검사정보 정보 = view.GetRow(e.RowHandle) as 검사정보;
            if (정보 == null) return;
            정보.SetAppearance(e);
        }

        public class LocalizationResultInspection
        {
            private enum Items
            {
                [Translation("Inspection Results", "검사결과")]
                검사결과,
            }

            public String 검사결과 => Localization.GetString(Items.검사결과);
        }
    }
}
