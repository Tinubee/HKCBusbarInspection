using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HKCBusbarInspection
{
    public partial class MainForm : DevExpress.XtraBars.TabForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        void OnOuterFormCreating(object sender, OuterFormCreatingEventArgs e)
        {
            MainForm form = new MainForm();
            form.TabFormControl.Pages.Clear();
            e.Form = form;
            OpenFormCount++;
        }
        static int OpenFormCount = 1;
    }
}
