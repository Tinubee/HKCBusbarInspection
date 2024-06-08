namespace HKCBusbarInspection.UI.Form
{
    partial class ResultViewer
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
            this.e결과뷰어 = new HKCBusbarInspection.UI.Control.ResultInspection();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.t최종결과 = new DevExpress.XtraTab.XtraTabPage();
            this.t카메라결과 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.t최종결과.SuspendLayout();
            this.SuspendLayout();
            // 
            // e결과뷰어
            // 
            this.e결과뷰어.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e결과뷰어.Location = new System.Drawing.Point(0, 0);
            this.e결과뷰어.Name = "e결과뷰어";
            this.e결과뷰어.Size = new System.Drawing.Size(1918, 979);
            this.e결과뷰어.TabIndex = 0;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.t최종결과;
            this.xtraTabControl1.Size = new System.Drawing.Size(1920, 1010);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.t최종결과,
            this.t카메라결과});
            // 
            // t최종결과
            // 
            this.t최종결과.Controls.Add(this.e결과뷰어);
            this.t최종결과.Name = "t최종결과";
            this.t최종결과.Size = new System.Drawing.Size(1918, 979);
            this.t최종결과.Text = "Main";
            // 
            // t카메라결과
            // 
            this.t카메라결과.Name = "t카메라결과";
            this.t카메라결과.Size = new System.Drawing.Size(1918, 979);
            this.t카메라결과.Text = "VM";
            // 
            // ResultViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1010);
            this.Controls.Add(this.xtraTabControl1);
            this.IconOptions.SvgImage = global::HKCBusbarInspection.Properties.Resources.vision;
            this.Name = "ResultViewer";
            this.Text = "ResultViewer";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.t최종결과.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Control.ResultInspection e결과뷰어;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage t최종결과;
        private DevExpress.XtraTab.XtraTabPage t카메라결과;
    }
}