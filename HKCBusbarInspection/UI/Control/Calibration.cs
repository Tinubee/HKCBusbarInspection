using DevExpress.XtraEditors;
using MvUtils;
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
    public partial class Calibration : XtraUserControl
    {
        public Calibration()
        {
            InitializeComponent();
        }

        public void Init()
        {
            e시작.DateTime = DateTime.Today;
            e종료.DateTime = DateTime.Today;
            b검색.ImageOptions.SvgImage = Resources.GetSvgImage(SvgImageType.검색);
            this.b검색.Click += B검색_Click;

            this.GridView1.Init(this.barManager1);
            this.GridView1.OptionsBehavior.Editable = true;
            this.GridView1.OptionsView.ColumnAutoWidth = false;
            this.GridControl1.DataSource =this.검사설정Bind;
        }
        private void B검색_Click(object sender, EventArgs e) 
        {
        
        }
    }
}
