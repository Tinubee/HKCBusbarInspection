namespace HKCBusbarInspection.UI.Control
{
    partial class CamViewers
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
            DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions customHeaderButtonImageOptions3 = new DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CamViewers));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions customHeaderButtonImageOptions4 = new DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions customHeaderButtonImageOptions2 = new DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions customHeaderButtonImageOptions1 = new DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.d하부캠 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.e하부캠 = new VMControls.Winform.Release.VmRenderControl();
            this.d상부캠 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.e상부캠 = new VMControls.Winform.Release.VmRenderControl();
            this.d측면캠 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.e측면캠 = new VMControls.Winform.Release.VmRenderControl();
            this.dLPoint캠 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel4_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.eLPoint캠 = new VMControls.Winform.Release.VmRenderControl();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.d하부캠.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.d상부캠.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            this.d측면캠.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            this.dLPoint캠.SuspendLayout();
            this.dockPanel4_Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.d상부캠,
            this.d하부캠,
            this.d측면캠,
            this.dLPoint캠});
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
            // d하부캠
            // 
            this.d하부캠.Controls.Add(this.dockPanel1_Container);
            customHeaderButtonImageOptions3.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("customHeaderButtonImageOptions3.SvgImage")));
            customHeaderButtonImageOptions3.SvgImageSize = new System.Drawing.Size(25, 25);
            this.d하부캠.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("4", false, customHeaderButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, serializableAppearanceObject3, null, -1)});
            this.d하부캠.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.d하부캠.ID = new System.Guid("823061fc-b810-4841-ab32-dccc049db34a");
            this.d하부캠.Location = new System.Drawing.Point(943, 0);
            this.d하부캠.Name = "d하부캠";
            this.d하부캠.OriginalSize = new System.Drawing.Size(611, 596);
            this.d하부캠.Size = new System.Drawing.Size(1073, 596);
            this.d하부캠.Text = "Bottom";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.e하부캠);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 45);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1067, 547);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // e하부캠
            // 
            this.e하부캠.BackColor = System.Drawing.Color.Black;
            this.e하부캠.CoordinateInfoVisible = true;
            this.e하부캠.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e하부캠.ImageSource = null;
            this.e하부캠.IsShowCustomROIMenu = false;
            this.e하부캠.Location = new System.Drawing.Point(0, 0);
            this.e하부캠.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.e하부캠.ModuleSource = null;
            this.e하부캠.Name = "e하부캠";
            this.e하부캠.Size = new System.Drawing.Size(1067, 547);
            this.e하부캠.TabIndex = 0;
            // 
            // d상부캠
            // 
            this.d상부캠.Controls.Add(this.dockPanel2_Container);
            customHeaderButtonImageOptions4.SvgImage = global::HKCBusbarInspection.Properties.Resources.electronics_photo2;
            customHeaderButtonImageOptions4.SvgImageSize = new System.Drawing.Size(25, 25);
            this.d상부캠.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("1", false, customHeaderButtonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, serializableAppearanceObject4, null, -1)});
            this.d상부캠.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.d상부캠.ID = new System.Guid("edb1e750-a378-442c-886b-50ecc9cd9abf");
            this.d상부캠.Location = new System.Drawing.Point(0, 0);
            this.d상부캠.Name = "d상부캠";
            this.d상부캠.OriginalSize = new System.Drawing.Size(943, 200);
            this.d상부캠.Size = new System.Drawing.Size(943, 1195);
            this.d상부캠.Text = "Top";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.e상부캠);
            this.dockPanel2_Container.Location = new System.Drawing.Point(3, 45);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(936, 1147);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // e상부캠
            // 
            this.e상부캠.BackColor = System.Drawing.Color.Black;
            this.e상부캠.CoordinateInfoVisible = true;
            this.e상부캠.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e상부캠.ImageSource = null;
            this.e상부캠.IsShowCustomROIMenu = false;
            this.e상부캠.Location = new System.Drawing.Point(0, 0);
            this.e상부캠.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.e상부캠.ModuleSource = null;
            this.e상부캠.Name = "e상부캠";
            this.e상부캠.Size = new System.Drawing.Size(936, 1147);
            this.e상부캠.TabIndex = 4;
            // 
            // d측면캠
            // 
            this.d측면캠.Controls.Add(this.dockPanel3_Container);
            customHeaderButtonImageOptions2.SvgImage = global::HKCBusbarInspection.Properties.Resources.electronics_photo3;
            customHeaderButtonImageOptions2.SvgImageSize = new System.Drawing.Size(25, 25);
            this.d측면캠.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("2", false, customHeaderButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, serializableAppearanceObject2, null, -1)});
            this.d측면캠.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.d측면캠.FloatVertical = true;
            this.d측면캠.ID = new System.Guid("846ae92e-b2d3-4f04-a9dd-3bbe6d0bd736");
            this.d측면캠.Location = new System.Drawing.Point(943, 596);
            this.d측면캠.Name = "d측면캠";
            this.d측면캠.OriginalSize = new System.Drawing.Size(557, 555);
            this.d측면캠.Size = new System.Drawing.Size(557, 599);
            this.d측면캠.Text = "Side";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.e측면캠);
            this.dockPanel3_Container.Location = new System.Drawing.Point(3, 45);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(550, 551);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // e측면캠
            // 
            this.e측면캠.BackColor = System.Drawing.Color.Black;
            this.e측면캠.CoordinateInfoVisible = true;
            this.e측면캠.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e측면캠.ImageSource = null;
            this.e측면캠.IsShowCustomROIMenu = false;
            this.e측면캠.Location = new System.Drawing.Point(0, 0);
            this.e측면캠.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.e측면캠.ModuleSource = null;
            this.e측면캠.Name = "e측면캠";
            this.e측면캠.Size = new System.Drawing.Size(550, 551);
            this.e측면캠.TabIndex = 5;
            // 
            // dLPoint캠
            // 
            this.dLPoint캠.Controls.Add(this.dockPanel4_Container);
            customHeaderButtonImageOptions1.SvgImage = global::HKCBusbarInspection.Properties.Resources.electronics_photo4;
            customHeaderButtonImageOptions1.SvgImageSize = new System.Drawing.Size(25, 25);
            this.dLPoint캠.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("3", false, customHeaderButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, serializableAppearanceObject1, null, -1)});
            this.dLPoint캠.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dLPoint캠.ID = new System.Guid("be9aaecf-0c60-4a6f-a88c-5c8a6466b842");
            this.dLPoint캠.Location = new System.Drawing.Point(1500, 596);
            this.dLPoint캠.Name = "dLPoint캠";
            this.dLPoint캠.OriginalSize = new System.Drawing.Size(516, 200);
            this.dLPoint캠.Size = new System.Drawing.Size(516, 599);
            this.dLPoint캠.Text = "LPoint";
            // 
            // dockPanel4_Container
            // 
            this.dockPanel4_Container.Controls.Add(this.eLPoint캠);
            this.dockPanel4_Container.Location = new System.Drawing.Point(3, 45);
            this.dockPanel4_Container.Name = "dockPanel4_Container";
            this.dockPanel4_Container.Size = new System.Drawing.Size(510, 551);
            this.dockPanel4_Container.TabIndex = 0;
            // 
            // eLPoint캠
            // 
            this.eLPoint캠.BackColor = System.Drawing.Color.Black;
            this.eLPoint캠.CoordinateInfoVisible = true;
            this.eLPoint캠.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eLPoint캠.ImageSource = null;
            this.eLPoint캠.IsShowCustomROIMenu = false;
            this.eLPoint캠.Location = new System.Drawing.Point(0, 0);
            this.eLPoint캠.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.eLPoint캠.ModuleSource = null;
            this.eLPoint캠.Name = "eLPoint캠";
            this.eLPoint캠.Size = new System.Drawing.Size(510, 551);
            this.eLPoint캠.TabIndex = 4;
            // 
            // CamViewers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dLPoint캠);
            this.Controls.Add(this.d측면캠);
            this.Controls.Add(this.d하부캠);
            this.Controls.Add(this.d상부캠);
            this.Name = "CamViewers";
            this.Size = new System.Drawing.Size(2016, 1195);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.d하부캠.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.d상부캠.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            this.d측면캠.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            this.dLPoint캠.ResumeLayout(false);
            this.dockPanel4_Container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dLPoint캠;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel4_Container;
        private DevExpress.XtraBars.Docking.DockPanel d측면캠;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Docking.DockPanel d상부캠;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel d하부캠;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private VMControls.Winform.Release.VmRenderControl eLPoint캠;
        private VMControls.Winform.Release.VmRenderControl e측면캠;
        private VMControls.Winform.Release.VmRenderControl e상부캠;
        private VMControls.Winform.Release.VmRenderControl e하부캠;
    }
}
