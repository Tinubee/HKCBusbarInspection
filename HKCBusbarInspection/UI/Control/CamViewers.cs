using DevExpress.XtraEditors;
using HKCBusbarInspection.Schemas;
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
    public partial class CamViewers : XtraUserControl
    {
        public CamViewers() => InitializeComponent();

        public void Init()
        {
            if (Global.VM제어.Count == 0) return;

            this.e상부캠.ModuleSource = Global.VM제어.GetItem(Flow구분.상부카메라).graphicsSetModuleTool;
            this.e측면캠.ModuleSource = Global.VM제어.GetItem(Flow구분.측면카메라).graphicsSetModuleTool;
            this.eLPoint캠.ModuleSource = Global.VM제어.GetItem(Flow구분.LPoint카메라).graphicsSetModuleTool;
            this.e하부캠.ModuleSource = Global.VM제어.GetItem(Flow구분.하부카메라).graphicsSetModuleTool;
            
        }
    }
}
