using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using HKCBusbarInspection.Schemas;
using HKCBusbarInspection.UI.Form;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HKCBusbarInspection.UI.Control
{
    public partial class CamViewers : XtraUserControl
    {
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

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void 상단메뉴클릭(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            try
            {
                Int32 번호 = Convert.ToInt32((sender as DockPanel).Tag);
                카메라구분 구분 = (카메라구분)번호;

                if (e.Button == ((DockPanel)sender).CustomHeaderButtons[0]) //조명켜기
                {
                    Boolean 상태 = Global.조명제어.GetItem(구분).켜짐;
                    Global.조명제어.TurnOnOff(구분, !상태);
                }
                else if (e.Button == ((DockPanel)sender).CustomHeaderButtons[1]) //라이브보기
                {
                    LiveForm LiveForm = new LiveForm(e.Button.Properties.Caption);
                    LiveForm.ShowDialog();
                }
                else if (e.Button == ((DockPanel)sender).CustomHeaderButtons[2]) // Master Image 검사? 1회 촬영후 검사?
                {
                    Global.그랩제어.GetItem(구분).SoftwareTrigger();
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
