namespace HKCBusbarInspection
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabFormControl1 = new DevExpress.XtraBars.TabFormControl();
            this.타이틀 = new DevExpress.XtraBars.BarStaticItem();
            this.skinPaletteDropDownButtonItem1 = new DevExpress.XtraBars.SkinPaletteDropDownButtonItem();
            this.e프로젝트 = new DevExpress.XtraBars.BarStaticItem();
            this.tabFormDefaultManager1 = new DevExpress.XtraBars.TabFormDefaultManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.p결과뷰어 = new DevExpress.XtraBars.TabFormPage();
            this.tabFormContentContainer1 = new DevExpress.XtraBars.TabFormContentContainer();
            this.e결과뷰어 = new HKCBusbarInspection.UI.Control.ResultInspection();
            this.e상태뷰어 = new HKCBusbarInspection.UI.Control.State();
            this.p검사도구 = new DevExpress.XtraBars.TabFormPage();
            this.tabFormContentContainer2 = new DevExpress.XtraBars.TabFormContentContainer();
            this.e카메라뷰어 = new HKCBusbarInspection.UI.Control.CamViewers();
            this.p검사내역 = new DevExpress.XtraBars.TabFormPage();
            this.tabFormContentContainer3 = new DevExpress.XtraBars.TabFormContentContainer();
            this.e검사내역 = new HKCBusbarInspection.UI.Control.Results();
            this.p환경설정 = new DevExpress.XtraBars.TabFormPage();
            this.tabFormContentContainer4 = new DevExpress.XtraBars.TabFormContentContainer();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.t검사설정 = new DevExpress.XtraTab.XtraTabPage();
            this.e검사설정 = new HKCBusbarInspection.UI.Control.SetInspection();
            this.t장치설정 = new DevExpress.XtraTab.XtraTabPage();
            this.e장치설정 = new HKCBusbarInspection.UI.Control.DeviceSettings();
            this.t변수설정 = new DevExpress.XtraTab.XtraTabPage();
            this.p로그내역 = new DevExpress.XtraBars.TabFormPage();
            this.tabFormContentContainer5 = new DevExpress.XtraBars.TabFormContentContainer();
            this.e로그내역 = new HKCBusbarInspection.UI.Control.LogViewer();
            this.e변수설정 = new HKCBusbarInspection.UI.Control.SetVariables();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormDefaultManager1)).BeginInit();
            this.tabFormContentContainer1.SuspendLayout();
            this.tabFormContentContainer2.SuspendLayout();
            this.tabFormContentContainer3.SuspendLayout();
            this.tabFormContentContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.t검사설정.SuspendLayout();
            this.t장치설정.SuspendLayout();
            this.t변수설정.SuspendLayout();
            this.tabFormContentContainer5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFormControl1
            // 
            this.tabFormControl1.AllowMoveTabs = false;
            this.tabFormControl1.AllowMoveTabsToOuterForm = false;
            this.tabFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.타이틀,
            this.skinPaletteDropDownButtonItem1,
            this.e프로젝트});
            this.tabFormControl1.Location = new System.Drawing.Point(0, 0);
            this.tabFormControl1.Manager = this.tabFormDefaultManager1;
            this.tabFormControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabFormControl1.Name = "tabFormControl1";
            this.tabFormControl1.Pages.Add(this.p결과뷰어);
            this.tabFormControl1.Pages.Add(this.p검사도구);
            this.tabFormControl1.Pages.Add(this.p검사내역);
            this.tabFormControl1.Pages.Add(this.p환경설정);
            this.tabFormControl1.Pages.Add(this.p로그내역);
            this.tabFormControl1.SelectedPage = this.p환경설정;
            this.tabFormControl1.ShowAddPageButton = false;
            this.tabFormControl1.ShowTabCloseButtons = false;
            this.tabFormControl1.ShowTabsInTitleBar = DevExpress.XtraBars.ShowTabsInTitleBar.True;
            this.tabFormControl1.Size = new System.Drawing.Size(1920, 30);
            this.tabFormControl1.TabForm = this;
            this.tabFormControl1.TabIndex = 0;
            this.tabFormControl1.TabLeftItemLinks.Add(this.타이틀);
            this.tabFormControl1.TabRightItemLinks.Add(this.e프로젝트);
            this.tabFormControl1.TabRightItemLinks.Add(this.skinPaletteDropDownButtonItem1);
            this.tabFormControl1.TabStop = false;
            // 
            // 타이틀
            // 
            this.타이틀.Caption = "HKC Busbar Vision Inspection System";
            this.타이틀.Id = 0;
            this.타이틀.ImageOptions.SvgImage = global::HKCBusbarInspection.Properties.Resources.vision;
            this.타이틀.Name = "타이틀";
            this.타이틀.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // skinPaletteDropDownButtonItem1
            // 
            this.skinPaletteDropDownButtonItem1.Id = 1;
            this.skinPaletteDropDownButtonItem1.Name = "skinPaletteDropDownButtonItem1";
            // 
            // e프로젝트
            // 
            this.e프로젝트.Caption = "IVM : 24-0272-003";
            this.e프로젝트.Id = 2;
            this.e프로젝트.Name = "e프로젝트";
            this.e프로젝트.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // tabFormDefaultManager1
            // 
            this.tabFormDefaultManager1.DockControls.Add(this.barDockControlTop);
            this.tabFormDefaultManager1.DockControls.Add(this.barDockControlBottom);
            this.tabFormDefaultManager1.DockControls.Add(this.barDockControlLeft);
            this.tabFormDefaultManager1.DockControls.Add(this.barDockControlRight);
            this.tabFormDefaultManager1.DockingEnabled = false;
            this.tabFormDefaultManager1.Form = this;
            this.tabFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.타이틀,
            this.skinPaletteDropDownButtonItem1,
            this.e프로젝트});
            this.tabFormDefaultManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 30);
            this.barDockControlTop.Manager = null;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlTop.Size = new System.Drawing.Size(1920, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1040);
            this.barDockControlBottom.Manager = null;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlBottom.Size = new System.Drawing.Size(1920, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = null;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1010);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1920, 30);
            this.barDockControlRight.Manager = null;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1010);
            // 
            // p결과뷰어
            // 
            this.p결과뷰어.ContentContainer = this.tabFormContentContainer1;
            this.p결과뷰어.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("p결과뷰어.ImageOptions.SvgImage")));
            this.p결과뷰어.Name = "p결과뷰어";
            this.p결과뷰어.Text = "Inspection";
            // 
            // tabFormContentContainer1
            // 
            this.tabFormContentContainer1.Controls.Add(this.e결과뷰어);
            this.tabFormContentContainer1.Controls.Add(this.e상태뷰어);
            this.tabFormContentContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer1.Location = new System.Drawing.Point(0, 30);
            this.tabFormContentContainer1.Name = "tabFormContentContainer1";
            this.tabFormContentContainer1.Size = new System.Drawing.Size(1920, 1010);
            this.tabFormContentContainer1.TabIndex = 1;
            // 
            // e결과뷰어
            // 
            this.e결과뷰어.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e결과뷰어.Location = new System.Drawing.Point(0, 105);
            this.e결과뷰어.Name = "e결과뷰어";
            this.e결과뷰어.Size = new System.Drawing.Size(1920, 905);
            this.e결과뷰어.TabIndex = 2;
            // 
            // e상태뷰어
            // 
            this.e상태뷰어.Dock = System.Windows.Forms.DockStyle.Top;
            this.e상태뷰어.Location = new System.Drawing.Point(0, 0);
            this.e상태뷰어.Name = "e상태뷰어";
            this.e상태뷰어.Size = new System.Drawing.Size(1920, 105);
            this.e상태뷰어.TabIndex = 1;
            // 
            // p검사도구
            // 
            this.p검사도구.ContentContainer = this.tabFormContentContainer2;
            this.p검사도구.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("p검사도구.ImageOptions.SvgImage")));
            this.p검사도구.Name = "p검사도구";
            this.p검사도구.Text = "Cameras";
            // 
            // tabFormContentContainer2
            // 
            this.tabFormContentContainer2.Controls.Add(this.e카메라뷰어);
            this.tabFormContentContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer2.Location = new System.Drawing.Point(0, 30);
            this.tabFormContentContainer2.Name = "tabFormContentContainer2";
            this.tabFormContentContainer2.Size = new System.Drawing.Size(1920, 1010);
            this.tabFormContentContainer2.TabIndex = 4;
            // 
            // e카메라뷰어
            // 
            this.e카메라뷰어.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e카메라뷰어.Location = new System.Drawing.Point(0, 0);
            this.e카메라뷰어.Name = "e카메라뷰어";
            this.e카메라뷰어.Size = new System.Drawing.Size(1920, 1010);
            this.e카메라뷰어.TabIndex = 0;
            // 
            // p검사내역
            // 
            this.p검사내역.ContentContainer = this.tabFormContentContainer3;
            this.p검사내역.ImageOptions.SvgImage = global::HKCBusbarInspection.Properties.Resources.bo_list;
            this.p검사내역.Name = "p검사내역";
            this.p검사내역.Text = "History";
            // 
            // tabFormContentContainer3
            // 
            this.tabFormContentContainer3.Controls.Add(this.e검사내역);
            this.tabFormContentContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer3.Location = new System.Drawing.Point(0, 30);
            this.tabFormContentContainer3.Name = "tabFormContentContainer3";
            this.tabFormContentContainer3.Size = new System.Drawing.Size(1920, 1010);
            this.tabFormContentContainer3.TabIndex = 5;
            // 
            // e검사내역
            // 
            this.e검사내역.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e검사내역.Location = new System.Drawing.Point(0, 0);
            this.e검사내역.Name = "e검사내역";
            this.e검사내역.Size = new System.Drawing.Size(1920, 1010);
            this.e검사내역.TabIndex = 0;
            // 
            // p환경설정
            // 
            this.p환경설정.ContentContainer = this.tabFormContentContainer4;
            this.p환경설정.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("p환경설정.ImageOptions.SvgImage")));
            this.p환경설정.Name = "p환경설정";
            this.p환경설정.Text = "Preferences";
            // 
            // tabFormContentContainer4
            // 
            this.tabFormContentContainer4.Controls.Add(this.xtraTabControl1);
            this.tabFormContentContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer4.Location = new System.Drawing.Point(0, 30);
            this.tabFormContentContainer4.Name = "tabFormContentContainer4";
            this.tabFormContentContainer4.Size = new System.Drawing.Size(1920, 1010);
            this.tabFormContentContainer4.TabIndex = 6;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.t검사설정;
            this.xtraTabControl1.Size = new System.Drawing.Size(1920, 1010);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.t검사설정,
            this.t장치설정,
            this.t변수설정});
            // 
            // t검사설정
            // 
            this.t검사설정.Controls.Add(this.e검사설정);
            this.t검사설정.Name = "t검사설정";
            this.t검사설정.Size = new System.Drawing.Size(1918, 979);
            this.t검사설정.Text = "검사설정";
            // 
            // e검사설정
            // 
            this.e검사설정.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e검사설정.Location = new System.Drawing.Point(0, 0);
            this.e검사설정.Name = "e검사설정";
            this.e검사설정.Size = new System.Drawing.Size(1918, 979);
            this.e검사설정.TabIndex = 0;
            // 
            // t장치설정
            // 
            this.t장치설정.Controls.Add(this.e장치설정);
            this.t장치설정.Name = "t장치설정";
            this.t장치설정.Size = new System.Drawing.Size(1918, 979);
            this.t장치설정.Text = "장치설정";
            // 
            // e장치설정
            // 
            this.e장치설정.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e장치설정.Location = new System.Drawing.Point(0, 0);
            this.e장치설정.Name = "e장치설정";
            this.e장치설정.Size = new System.Drawing.Size(1918, 979);
            this.e장치설정.TabIndex = 0;
            // 
            // t변수설정
            // 
            this.t변수설정.Controls.Add(this.e변수설정);
            this.t변수설정.Name = "t변수설정";
            this.t변수설정.Size = new System.Drawing.Size(1918, 979);
            this.t변수설정.Text = "변수설정";
            // 
            // p로그내역
            // 
            this.p로그내역.ContentContainer = this.tabFormContentContainer5;
            this.p로그내역.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("p로그내역.ImageOptions.SvgImage")));
            this.p로그내역.Name = "p로그내역";
            this.p로그내역.Text = "Logs";
            // 
            // tabFormContentContainer5
            // 
            this.tabFormContentContainer5.Controls.Add(this.e로그내역);
            this.tabFormContentContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer5.Location = new System.Drawing.Point(0, 30);
            this.tabFormContentContainer5.Name = "tabFormContentContainer5";
            this.tabFormContentContainer5.Size = new System.Drawing.Size(1920, 1010);
            this.tabFormContentContainer5.TabIndex = 7;
            // 
            // e로그내역
            // 
            this.e로그내역.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e로그내역.Location = new System.Drawing.Point(0, 0);
            this.e로그내역.Name = "e로그내역";
            this.e로그내역.Size = new System.Drawing.Size(1920, 1010);
            this.e로그내역.TabIndex = 0;
            // 
            // e변수설정
            // 
            this.e변수설정.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e변수설정.Location = new System.Drawing.Point(0, 0);
            this.e변수설정.Name = "e변수설정";
            this.e변수설정.Size = new System.Drawing.Size(1918, 979);
            this.e변수설정.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1040);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.tabFormContentContainer4);
            this.Controls.Add(this.tabFormControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TabFormControl = this.tabFormControl1;
            this.Text = "Busbar Vision Inspection";
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormDefaultManager1)).EndInit();
            this.tabFormContentContainer1.ResumeLayout(false);
            this.tabFormContentContainer2.ResumeLayout(false);
            this.tabFormContentContainer3.ResumeLayout(false);
            this.tabFormContentContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.t검사설정.ResumeLayout(false);
            this.t장치설정.ResumeLayout(false);
            this.t변수설정.ResumeLayout(false);
            this.tabFormContentContainer5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.TabFormControl tabFormControl1;
        private DevExpress.XtraBars.TabFormDefaultManager tabFormDefaultManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer1;
        private DevExpress.XtraBars.TabFormPage p결과뷰어;
        private DevExpress.XtraBars.TabFormPage p검사도구;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer2;
        private DevExpress.XtraBars.TabFormPage p검사내역;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer3;
        private DevExpress.XtraBars.BarStaticItem 타이틀;
        private DevExpress.XtraBars.TabFormPage p환경설정;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer4;
        private UI.Control.State e상태뷰어;
        private UI.Control.CamViewers e카메라뷰어;
        private DevExpress.XtraBars.SkinPaletteDropDownButtonItem skinPaletteDropDownButtonItem1;
        private DevExpress.XtraBars.BarStaticItem e프로젝트;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage t검사설정;
        private DevExpress.XtraTab.XtraTabPage t장치설정;
        private UI.Control.SetInspection e검사설정;
        private UI.Control.DeviceSettings e장치설정;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer5;
        private DevExpress.XtraBars.TabFormPage p로그내역;
        private UI.Control.LogViewer e로그내역;
        private UI.Control.Results e검사내역;
        public UI.Control.ResultInspection e결과뷰어;
        private DevExpress.XtraTab.XtraTabPage t변수설정;
        private UI.Control.SetVariables e변수설정;
    }
}

