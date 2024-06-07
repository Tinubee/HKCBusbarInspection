using DevExpress.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using HKCBusbarInspection.Schemas;
using HKCBusbarInspection.UI.Form;
using MvUtils;
using OpenCvSharp;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static DevExpress.Skins.SolidColorHelper;
using static DevExpress.XtraEditors.RoundedSkinPanel;

namespace HKCBusbarInspection.UI.Control
{
    public partial class CamViewers : XtraUserControl
    {
        private Boolean 촬영모드 { get; set; }
        private PopupMenu popupMenu;
        private 카메라구분 구분 { get; set; }
        public CamViewers() => InitializeComponent();

        public void Init()
        {
            try
            {
                if (Global.VM제어?.Count == 0) return;

                this.e상부캠.ModuleSource = Global.VM제어.GetItem(Flow구분.상부카메라).graphicsSetModuleTool;
                this.e측면캠.ModuleSource = Global.VM제어.GetItem(Flow구분.측면카메라).graphicsSetModuleTool;
                this.eLPoint캠.ModuleSource = Global.VM제어.GetItem(Flow구분.LPoint카메라).graphicsSetModuleTool;
                this.e하부캠.ModuleSource = Global.VM제어.GetItem(Flow구분.하부카메라).graphicsSetModuleTool;

                d상부캠.CustomButtonClick += 상단메뉴클릭;
                d측면캠.CustomButtonClick += 상단메뉴클릭;
                dLPoint캠.CustomButtonClick += 상단메뉴클릭;
                d하부캠.CustomButtonClick += 상단메뉴클릭;

                popupMenu = new PopupMenu(this.barManager1);

                BarButtonItem Grab = new BarButtonItem(this.barManager1, "Grab Image");
                BarButtonItem Master = new BarButtonItem(this.barManager1, "Master Image");

                Grab.ImageOptions.SvgImage = MvUtils.Resources.검색;
                Master.ImageOptions.SvgImage = MvUtils.Resources.보기;

                popupMenu.AddItem(Grab);
                popupMenu.AddItem(Master);

                Grab.ItemClick += 이미지그랩후검사;
                Master.ItemClick += 마스터이미지검사;

                //Global.신호제어.동작상태알림 += 동작상태알림;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        //private void 동작상태알림()
        //{
        //    if (this.InvokeRequired) { this.BeginInvoke(new Action(동작상태알림)); return; }

        //    //this.e
        //}
        private void 마스터이미지검사(object sender, ItemClickEventArgs e)
        {
            String filePath = Global.모델자료.GetItem(Global.환경설정.선택모델).모델사진;
            비전마스터플로우 플로우 = Global.VM제어.GetItem(this.구분);

            //Mat image = Cv2.ImRead(filePath, ImreadModes.Color);

            플로우.Run(null, null, filePath, Global.검사자료.수동검사);
            검사결과 검사 = Global.검사자료.검사결과계산(Global.검사자료.수동검사.검사코드);
            Global.검사자료.수동검사결과(this.구분, 검사);
        }

        private void 이미지그랩후검사(object sender, ItemClickEventArgs e)
        {
            if (Global.장치상태.자동수동) { Utils.WarningMsg("자동모드 일때는 사용할 수 없습니다."); return; }

            Global.그랩제어.GetItem(this.구분).SoftwareTrigger();
        }

        private void 상단메뉴클릭(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            try
            {
                Int32 번호 = Convert.ToInt32((sender as DockPanel).Tag);
                this.구분 = (카메라구분)번호;
                Global.모델자료.GetItem(Global.환경설정.선택모델).카메라구분 = this.구분;

                if (e.Button == ((DockPanel)sender).CustomHeaderButtons[0]) //조명켜기
                {
                    Boolean 상태 = Global.조명제어.GetItem(this.구분).켜짐;
                    Global.조명제어.TurnOnOff(this.구분, !상태);
                }
                else if (e.Button == ((DockPanel)sender).CustomHeaderButtons[1]) //라이브보기
                {
                    LiveForm LiveForm = new LiveForm(e.Button.Properties.Caption);
                    LiveForm.ShowDialog();
                }
                else if (e.Button == ((DockPanel)sender).CustomHeaderButtons[2]) // Master Image 검사? 1회 촬영후 검사?
                {
                    System.Drawing.Point btnLocation = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
                    popupMenu.ShowPopup(btnLocation);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
