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
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.d하부캠 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.d상부캠 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.d측면캠 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dLPoint캠 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel4_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.e하부캠 = new VMControls.Winform.Release.VmRenderControl();
            this.e상부캠 = new VMControls.Winform.Release.VmRenderControl();
            this.eLPoint캠 = new VMControls.Winform.Release.VmRenderControl();
            this.e측면캠 = new VMControls.Winform.Release.VmRenderControl();
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
            this.d하부캠,
            this.d상부캠,
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
            this.d하부캠.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.d하부캠.ID = new System.Guid("823061fc-b810-4841-ab32-dccc049db34a");
            this.d하부캠.Location = new System.Drawing.Point(0, 0);
            this.d하부캠.Name = "d하부캠";
            this.d하부캠.OriginalSize = new System.Drawing.Size(611, 200);
            this.d하부캠.Size = new System.Drawing.Size(611, 1195);
            this.d하부캠.Text = "Bottom";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.e하부캠);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 30);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(604, 1162);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // d상부캠
            // 
            this.d상부캠.Controls.Add(this.dockPanel2_Container);
            this.d상부캠.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.d상부캠.ID = new System.Guid("edb1e750-a378-442c-886b-50ecc9cd9abf");
            this.d상부캠.Location = new System.Drawing.Point(611, 0);
            this.d상부캠.Name = "d상부캠";
            this.d상부캠.OriginalSize = new System.Drawing.Size(810, 200);
            this.d상부캠.Size = new System.Drawing.Size(810, 1195);
            this.d상부캠.Text = "Top";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.e상부캠);
            this.dockPanel2_Container.Location = new System.Drawing.Point(3, 30);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(803, 1162);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // d측면캠
            // 
            this.d측면캠.Controls.Add(this.dockPanel3_Container);
            this.d측면캠.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.d측면캠.ID = new System.Guid("846ae92e-b2d3-4f04-a9dd-3bbe6d0bd736");
            this.d측면캠.Location = new System.Drawing.Point(1421, 0);
            this.d측면캠.Name = "d측면캠";
            this.d측면캠.OriginalSize = new System.Drawing.Size(200, 555);
            this.d측면캠.Size = new System.Drawing.Size(595, 555);
            this.d측면캠.Text = "Side";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.e측면캠);
            this.dockPanel3_Container.Location = new System.Drawing.Point(3, 30);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(589, 521);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // dLPoint캠
            // 
            this.dLPoint캠.Controls.Add(this.dockPanel4_Container);
            this.dLPoint캠.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dLPoint캠.ID = new System.Guid("be9aaecf-0c60-4a6f-a88c-5c8a6466b842");
            this.dLPoint캠.Location = new System.Drawing.Point(1421, 555);
            this.dLPoint캠.Name = "dLPoint캠";
            this.dLPoint캠.OriginalSize = new System.Drawing.Size(595, 200);
            this.dLPoint캠.Size = new System.Drawing.Size(595, 640);
            this.dLPoint캠.Text = "LPoint";
            // 
            // dockPanel4_Container
            // 
            this.dockPanel4_Container.Controls.Add(this.eLPoint캠);
            this.dockPanel4_Container.Location = new System.Drawing.Point(3, 30);
            this.dockPanel4_Container.Name = "dockPanel4_Container";
            this.dockPanel4_Container.Size = new System.Drawing.Size(589, 607);
            this.dockPanel4_Container.TabIndex = 0;
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
            this.e하부캠.Size = new System.Drawing.Size(604, 1162);
            this.e하부캠.TabIndex = 0;
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
            this.e상부캠.Size = new System.Drawing.Size(803, 1162);
            this.e상부캠.TabIndex = 4;
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
            this.eLPoint캠.Size = new System.Drawing.Size(589, 607);
            this.eLPoint캠.TabIndex = 4;
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
            this.e측면캠.Size = new System.Drawing.Size(589, 521);
            this.e측면캠.TabIndex = 5;
            // 
            // CamViewers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dLPoint캠);
            this.Controls.Add(this.d측면캠);
            this.Controls.Add(this.d상부캠);
            this.Controls.Add(this.d하부캠);
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
