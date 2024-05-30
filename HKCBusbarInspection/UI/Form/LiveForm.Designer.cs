namespace HKCBusbarInspection.UI.Form
{
    partial class LiveForm
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
            this.e캠라이브 = new HKCBusbarInspection.UI.Control.CamLive();
            this.SuspendLayout();
            // 
            // e캠라이브
            // 
            this.e캠라이브.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e캠라이브.Location = new System.Drawing.Point(0, 0);
            this.e캠라이브.Name = "e캠라이브";
            this.e캠라이브.Size = new System.Drawing.Size(1000, 880);
            this.e캠라이브.TabIndex = 0;
            // 
            // LiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 880);
            this.Controls.Add(this.e캠라이브);
            this.Name = "LiveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LiveForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Control.CamLive e캠라이브;
    }
}