using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKCBusbarInspection.UI.Form
{
    public partial class Teaching : XtraForm
    {
        public Teaching()
        {
            InitializeComponent();
            this.Shown += Teaching_Shown;
            this.FormClosed += Teaching_FormClosed;
        }

        private void Teaching_Shown(object sender, EventArgs e)
        {
            
        }

        private void Teaching_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.VM제어.글로벌변수제어.Init();
            //Global.MainForm.e변수설정.UpdateGridView();
        }
    }
}