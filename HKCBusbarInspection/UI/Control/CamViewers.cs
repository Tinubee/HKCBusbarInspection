using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using HKCBusbarInspection.Schemas;
using HKCBusbarInspection.UI.Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKCBusbarInspection.UI.Control
{
    public partial class CamViewers : XtraUserControl
    {
        public CamViewers() => InitializeComponent();

        public void Init()
        {
            try
            {
                if (Global.VM제어.Count == 0) return;

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
            if (e.Button == ((DockPanel)sender).CustomHeaderButtons[0]) //조명켜기
            {
                카메라구분 구분 =(카메라구분)Convert.ToInt32(e.Button.Properties.Caption);
                Global.조명제어.GetItem(구분).OnOff();
            }
            else if (e.Button == ((DockPanel)sender).CustomHeaderButtons[1]) //라이브보기
            {
                LiveForm LiveForm = new LiveForm(e.Button.Properties.Caption);
                LiveForm.ShowDialog();
            }
            else if (e.Button == ((DockPanel)sender).CustomHeaderButtons[2]) //1회촬영 후 검사
            {
                //LiveForm LiveForm = new LiveForm(e.Button.Properties.Caption);
                //LiveForm.ShowDialog();
            }
        }
    }
}
