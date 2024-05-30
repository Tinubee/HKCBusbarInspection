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

                d상부캠.CustomButtonClick += 라이브보기;
                d측면캠.CustomButtonClick += 라이브보기;
                dLPoint캠.CustomButtonClick += 라이브보기;
                d하부캠.CustomButtonClick += 라이브보기;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void 라이브보기(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button == ((DockPanel)sender).CustomHeaderButtons[0])
            {
                LiveForm LiveForm = new LiveForm(e.Button.Properties.Caption);
                LiveForm.ShowDialog();
            }
        }
    }
}
