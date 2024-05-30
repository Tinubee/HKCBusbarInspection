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

namespace HKCBusbarInspection.UI.Form
{
    public partial class LiveForm : XtraForm
    {
        private 카메라구분 구분 = 카메라구분.None;
        public LiveForm(String Caption)
        {
            InitializeComponent();
            Int32 Num = Convert.ToInt32(Caption);
            this.구분 = Global.그랩제어.GetItem((카메라구분)Num).구분;
            this.Text =$"LiveForm {this.구분}";
            this.e캠라이브.Init(this.구분);
        }
    }
}