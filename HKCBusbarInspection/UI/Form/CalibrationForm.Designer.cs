namespace HKCBusbarInspection.UI.Form
{
    partial class CalibrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.e캘리브레이션 = new HKCBusbarInspection.UI.Control.Calibration();
            this.SuspendLayout();
            // 
            // e캘리브레이션
            // 
            this.e캘리브레이션.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e캘리브레이션.Location = new System.Drawing.Point(0, 0);
            this.e캘리브레이션.Name = "e캘리브레이션";
            this.e캘리브레이션.Size = new System.Drawing.Size(1419, 905);
            this.e캘리브레이션.TabIndex = 0;
            // 
            // CalibrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 905);
            this.Controls.Add(this.e캘리브레이션);
            this.IconOptions.SvgImage = global::HKCBusbarInspection.Properties.Resources.inserttableofcaptions1;
            this.Name = "CalibrationForm";
            this.Text = "CalibrationForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Control.Calibration e캘리브레이션;
    }
}