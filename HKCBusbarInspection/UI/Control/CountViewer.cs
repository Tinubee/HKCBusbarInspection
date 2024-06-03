using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Drawing;

namespace HKCBusbarInspection.UI.Control
{
    public partial class CountViewer : XtraUserControl
    {
        public CountViewer()
        {
            InitializeComponent();
        }

        [Bindable(true)]
        public string ValueText
        {
            get { return this.e현재값.Text; }
            set { this.e현재값.Text = value; }
        }

        [Bindable(true)]
        public string Caption
        {
            get { return this.e타이틀.Text; }
            set { this.e타이틀.Text = value; }
        }

        [Bindable(true)]
        public Font CaptionFont
        {
            get { return this.e타이틀.AppearanceCaption.Font; }
            set { this.e타이틀.AppearanceCaption.Font = value; }
        }

        [Bindable(true)]
        public Font TextFont
        {
            get { return this.e현재값.Appearance.Font; }
            set { this.e현재값.Appearance.Font = value; }
        }

        public Color BaseColor
        {
            get { return this.e현재값.Appearance.ForeColor; }
            set
            {
                this.e현재값.Appearance.ForeColor = value;
                this.e현재값.Appearance.BackColor = Color.FromArgb(32, value);
            }
        }
    }
}
