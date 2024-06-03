namespace HKCBusbarInspection.UI.Control
{
    partial class ResultInspection
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.e결과목록 = new HKCBusbarInspection.UI.Control.ResultGrid();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.e결과뷰어 = new HKCBusbarInspection.UI.Control.Viewport3D();
            this.e외관결과 = new DevExpress.XtraEditors.TextEdit();
            this.eCTQ결과 = new DevExpress.XtraEditors.TextEdit();
            this.e검사순번 = new DevExpress.XtraEditors.TextEdit();
            this.e측정결과 = new DevExpress.XtraEditors.LabelControl();
            this.e검사시간 = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.검사결과Bind = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e외관결과.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCTQ결과.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e검사순번.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e검사시간.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.검사결과Bind)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.DockingOptions.ShowCloseButton = false;
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("6883b6c3-9de6-41a2-8e51-aea01744beca");
            this.dockPanel1.Location = new System.Drawing.Point(1331, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(589, 200);
            this.dockPanel1.Size = new System.Drawing.Size(589, 900);
            this.dockPanel1.Text = "Inspection Results";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.e결과목록);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 30);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(582, 867);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // e결과목록
            // 
            this.e결과목록.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e결과목록.Location = new System.Drawing.Point(0, 0);
            this.e결과목록.Name = "e결과목록";
            this.e결과목록.Size = new System.Drawing.Size(582, 867);
            this.e결과목록.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.AutoScroll = false;
            this.layoutControl1.Controls.Add(this.e결과뷰어);
            this.layoutControl1.Controls.Add(this.e외관결과);
            this.layoutControl1.Controls.Add(this.eCTQ결과);
            this.layoutControl1.Controls.Add(this.e검사순번);
            this.layoutControl1.Controls.Add(this.e측정결과);
            this.layoutControl1.Controls.Add(this.e검사시간);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.AlwaysScrollActiveControlIntoView = false;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1331, 900);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // e결과뷰어
            // 
            this.e결과뷰어.Location = new System.Drawing.Point(6, 96);
            this.e결과뷰어.Name = "e결과뷰어";
            this.e결과뷰어.Size = new System.Drawing.Size(1319, 798);
            this.e결과뷰어.TabIndex = 10;
            // 
            // e외관결과
            // 
            this.e외관결과.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.검사결과Bind, "외관문구", true));
            this.e외관결과.EditValue = "-";
            this.e외관결과.EnterMoveNextControl = true;
            this.e외관결과.Location = new System.Drawing.Point(368, 54);
            this.e외관결과.Name = "e외관결과";
            this.e외관결과.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e외관결과.Properties.Appearance.Options.UseFont = true;
            this.e외관결과.Properties.Appearance.Options.UseTextOptions = true;
            this.e외관결과.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e외관결과.Properties.ReadOnly = true;
            this.e외관결과.Size = new System.Drawing.Size(174, 32);
            this.e외관결과.StyleController = this.layoutControl1;
            this.e외관결과.TabIndex = 9;
            // 
            // eCTQ결과
            // 
            this.eCTQ결과.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.검사결과Bind, "품질문구", true));
            this.eCTQ결과.EditValue = "-";
            this.eCTQ결과.EnterMoveNextControl = true;
            this.eCTQ결과.Location = new System.Drawing.Point(368, 10);
            this.eCTQ결과.Name = "eCTQ결과";
            this.eCTQ결과.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.eCTQ결과.Properties.Appearance.Options.UseFont = true;
            this.eCTQ결과.Properties.Appearance.Options.UseTextOptions = true;
            this.eCTQ결과.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.eCTQ결과.Properties.ReadOnly = true;
            this.eCTQ결과.Size = new System.Drawing.Size(174, 32);
            this.eCTQ결과.StyleController = this.layoutControl1;
            this.eCTQ결과.TabIndex = 8;
            // 
            // e검사순번
            // 
            this.e검사순번.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.검사결과Bind, "검사코드", true));
            this.e검사순번.EditValue = 0;
            this.e검사순번.EnterMoveNextControl = true;
            this.e검사순번.Location = new System.Drawing.Point(632, 54);
            this.e검사순번.Name = "e검사순번";
            this.e검사순번.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e검사순번.Properties.Appearance.Options.UseFont = true;
            this.e검사순번.Properties.Appearance.Options.UseTextOptions = true;
            this.e검사순번.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e검사순번.Properties.DisplayFormat.FormatString = "d4";
            this.e검사순번.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.e검사순번.Properties.EditFormat.FormatString = "d4";
            this.e검사순번.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.e검사순번.Properties.ReadOnly = true;
            this.e검사순번.Size = new System.Drawing.Size(201, 32);
            this.e검사순번.StyleController = this.layoutControl1;
            this.e검사순번.TabIndex = 1;
            // 
            // e측정결과
            // 
            this.e측정결과.Appearance.Font = new System.Drawing.Font("맑은 고딕", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e측정결과.Appearance.Options.UseFont = true;
            this.e측정결과.Appearance.Options.UseTextOptions = true;
            this.e측정결과.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e측정결과.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.e측정결과.Location = new System.Drawing.Point(6, 6);
            this.e측정결과.MinimumSize = new System.Drawing.Size(0, 50);
            this.e측정결과.Name = "e측정결과";
            this.e측정결과.Size = new System.Drawing.Size(276, 86);
            this.e측정결과.StyleController = this.layoutControl1;
            this.e측정결과.TabIndex = 2;
            this.e측정결과.Text = "Waiting";
            // 
            // e검사시간
            // 
            this.e검사시간.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.검사결과Bind, "검사일시", true));
            this.e검사시간.EnterMoveNextControl = true;
            this.e검사시간.Location = new System.Drawing.Point(923, 54);
            this.e검사시간.Name = "e검사시간";
            this.e검사시간.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e검사시간.Properties.Appearance.Options.UseFont = true;
            this.e검사시간.Properties.Appearance.Options.UseTextOptions = true;
            this.e검사시간.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e검사시간.Properties.DisplayFormat.FormatString = "{0:yyyy-MM-dd HH:mm:ss}";
            this.e검사시간.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.e검사시간.Properties.EditFormat.FormatString = "{0:yyyy-MM-dd HH:mm:ss}";
            this.e검사시간.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.e검사시간.Properties.ReadOnly = true;
            this.e검사시간.Size = new System.Drawing.Size(398, 32);
            this.e검사시간.StyleController = this.layoutControl1;
            this.e검사시간.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Root.AppearanceItemCaption.Options.UseFont = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.Root.Size = new System.Drawing.Size(1331, 900);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.e측정결과;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(280, 90);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(280, 90);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(280, 90);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.e검사순번;
            this.layoutControlItem4.Location = new System.Drawing.Point(544, 44);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem4.Size = new System.Drawing.Size(291, 46);
            this.layoutControlItem4.Text = "Index";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(66, 25);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.e검사시간;
            this.layoutControlItem2.Location = new System.Drawing.Point(835, 44);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem2.Size = new System.Drawing.Size(488, 46);
            this.layoutControlItem2.Text = "Time";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(66, 25);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Location = new System.Drawing.Point(544, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem5.Size = new System.Drawing.Size(779, 44);
            this.layoutControlItem5.Text = "Legibility";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.eCTQ결과;
            this.layoutControlItem6.Location = new System.Drawing.Point(280, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem6.Size = new System.Drawing.Size(264, 44);
            this.layoutControlItem6.Text = "CTQ";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(66, 25);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.e외관결과;
            this.layoutControlItem7.Location = new System.Drawing.Point(280, 44);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem7.Size = new System.Drawing.Size(264, 46);
            this.layoutControlItem7.Text = "Surface";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(66, 25);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.e결과뷰어;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 90);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1323, 802);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // 검사결과Bind
            // 
            this.검사결과Bind.DataSource = typeof(HKCBusbarInspection.Schemas.검사결과);
            // 
            // ResultInspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.dockPanel1);
            this.Name = "ResultInspection";
            this.Size = new System.Drawing.Size(1920, 900);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.e외관결과.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCTQ결과.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e검사순번.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e검사시간.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.검사결과Bind)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit e외관결과;
        private DevExpress.XtraEditors.TextEdit eCTQ결과;
        private DevExpress.XtraEditors.TextEdit e검사순번;
        private DevExpress.XtraEditors.LabelControl e측정결과;
        private DevExpress.XtraEditors.TextEdit e검사시간;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private Viewport3D e결과뷰어;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource 검사결과Bind;
        private ResultGrid e결과목록;
    }
}
