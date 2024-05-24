namespace HKCBusbarInspection.UI.Control
{
    partial class State
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.e모델선택 = new DevExpress.XtraEditors.LookUpEdit();
            this.b동작구분 = new DevExpress.XtraEditors.LabelControl();
            this.deviceLamp1 = new HKCBusbarInspection.UI.Control.DeviceLamp();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.countViewer4 = new HKCBusbarInspection.UI.Control.CountViewer();
            this.countViewer3 = new HKCBusbarInspection.UI.Control.CountViewer();
            this.countViewer2 = new HKCBusbarInspection.UI.Control.CountViewer();
            this.countViewer1 = new HKCBusbarInspection.UI.Control.CountViewer();
            this.b수량리셋 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.e저장용량 = new DevExpress.XtraEditors.ProgressBarControl();
            this.ciView1 = new HKCBusbarInspection.UI.Control.CiView();
            this.titleView1 = new HKCBusbarInspection.UI.Control.TitleView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e모델선택.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e저장용량.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.titleView1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1920, 105);
            this.panelControl1.TabIndex = 2;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.e모델선택);
            this.panelControl2.Controls.Add(this.b동작구분);
            this.panelControl2.Controls.Add(this.deviceLamp1);
            this.panelControl2.Controls.Add(this.tablePanel1);
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Controls.Add(this.ciView1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(222, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(3);
            this.panelControl2.Size = new System.Drawing.Size(1696, 101);
            this.panelControl2.TabIndex = 8;
            // 
            // e모델선택
            // 
            this.e모델선택.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e모델선택.Location = new System.Drawing.Point(419, 3);
            this.e모델선택.Name = "e모델선택";
            this.e모델선택.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e모델선택.Properties.Appearance.Options.UseFont = true;
            this.e모델선택.Properties.Appearance.Options.UseTextOptions = true;
            this.e모델선택.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e모델선택.Properties.AppearanceDropDown.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e모델선택.Properties.AppearanceDropDown.Options.UseFont = true;
            this.e모델선택.Properties.AutoHeight = false;
            this.e모델선택.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e모델선택.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("모델구분", "구분", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("모델설명", "설명", 240, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.e모델선택.Properties.NullText = "[Model]";
            this.e모델선택.Size = new System.Drawing.Size(424, 95);
            this.e모델선택.TabIndex = 16;
            // 
            // b동작구분
            // 
            this.b동작구분.Appearance.Font = new System.Drawing.Font("맑은 고딕", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.b동작구분.Appearance.Options.UseFont = true;
            this.b동작구분.Appearance.Options.UseTextOptions = true;
            this.b동작구분.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.b동작구분.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.b동작구분.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.b동작구분.Dock = System.Windows.Forms.DockStyle.Left;
            this.b동작구분.Location = new System.Drawing.Point(203, 3);
            this.b동작구분.Name = "b동작구분";
            this.b동작구분.Size = new System.Drawing.Size(216, 95);
            this.b동작구분.TabIndex = 15;
            this.b동작구분.Text = "Manual";
            // 
            // deviceLamp1
            // 
            this.deviceLamp1.Dock = System.Windows.Forms.DockStyle.Left;
            this.deviceLamp1.Location = new System.Drawing.Point(3, 3);
            this.deviceLamp1.Name = "deviceLamp1";
            this.deviceLamp1.Size = new System.Drawing.Size(200, 95);
            this.deviceLamp1.TabIndex = 14;
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F)});
            this.tablePanel1.Controls.Add(this.countViewer4);
            this.tablePanel1.Controls.Add(this.countViewer3);
            this.tablePanel1.Controls.Add(this.countViewer2);
            this.tablePanel1.Controls.Add(this.countViewer1);
            this.tablePanel1.Controls.Add(this.b수량리셋);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tablePanel1.Location = new System.Drawing.Point(843, 3);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(500, 95);
            this.tablePanel1.TabIndex = 3;
            // 
            // countViewer4
            // 
            this.tablePanel1.SetColumn(this.countViewer4, 3);
            this.countViewer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.countViewer4.Location = new System.Drawing.Point(303, 3);
            this.countViewer4.Name = "countViewer4";
            this.tablePanel1.SetRow(this.countViewer4, 0);
            this.countViewer4.Size = new System.Drawing.Size(94, 89);
            this.countViewer4.TabIndex = 16;
            // 
            // countViewer3
            // 
            this.tablePanel1.SetColumn(this.countViewer3, 2);
            this.countViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.countViewer3.Location = new System.Drawing.Point(203, 3);
            this.countViewer3.Name = "countViewer3";
            this.tablePanel1.SetRow(this.countViewer3, 0);
            this.countViewer3.Size = new System.Drawing.Size(94, 89);
            this.countViewer3.TabIndex = 15;
            // 
            // countViewer2
            // 
            this.tablePanel1.SetColumn(this.countViewer2, 1);
            this.countViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.countViewer2.Location = new System.Drawing.Point(103, 3);
            this.countViewer2.Name = "countViewer2";
            this.tablePanel1.SetRow(this.countViewer2, 0);
            this.countViewer2.Size = new System.Drawing.Size(94, 89);
            this.countViewer2.TabIndex = 14;
            // 
            // countViewer1
            // 
            this.tablePanel1.SetColumn(this.countViewer1, 0);
            this.countViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.countViewer1.Location = new System.Drawing.Point(3, 3);
            this.countViewer1.Name = "countViewer1";
            this.tablePanel1.SetRow(this.countViewer1, 0);
            this.countViewer1.Size = new System.Drawing.Size(94, 89);
            this.countViewer1.TabIndex = 1;
            // 
            // b수량리셋
            // 
            this.b수량리셋.Appearance.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.b수량리셋.Appearance.Options.UseFont = true;
            this.b수량리셋.Dock = System.Windows.Forms.DockStyle.Fill;
            this.b수량리셋.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.b수량리셋.Location = new System.Drawing.Point(403, 3);
            this.b수량리셋.Name = "b수량리셋";
            this.b수량리셋.Size = new System.Drawing.Size(94, 89);
            this.b수량리셋.TabIndex = 0;
            this.b수량리셋.Text = "Count\r\nReset";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.e저장용량);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl1.Location = new System.Drawing.Point(1343, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl1.Size = new System.Drawing.Size(150, 95);
            this.groupControl1.TabIndex = 13;
            this.groupControl1.Text = "Disk Usage";
            // 
            // e저장용량
            // 
            this.e저장용량.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e저장용량.EditValue = 50;
            this.e저장용량.Location = new System.Drawing.Point(7, 32);
            this.e저장용량.Name = "e저장용량";
            this.e저장용량.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e저장용량.Properties.ShowTitle = true;
            this.e저장용량.Size = new System.Drawing.Size(136, 56);
            this.e저장용량.TabIndex = 0;
            // 
            // ciView1
            // 
            this.ciView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.ciView1.Location = new System.Drawing.Point(1493, 3);
            this.ciView1.Name = "ciView1";
            this.ciView1.Size = new System.Drawing.Size(200, 95);
            this.ciView1.TabIndex = 12;
            // 
            // titleView1
            // 
            this.titleView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.titleView1.Location = new System.Drawing.Point(2, 2);
            this.titleView1.Name = "titleView1";
            this.titleView1.Size = new System.Drawing.Size(220, 101);
            this.titleView1.TabIndex = 0;
            // 
            // State
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "State";
            this.Size = new System.Drawing.Size(1920, 105);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.e모델선택.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.e저장용량.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private TitleView titleView1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private CiView ciView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ProgressBarControl e저장용량;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.SimpleButton b수량리셋;
        private CountViewer countViewer4;
        private CountViewer countViewer3;
        private CountViewer countViewer2;
        private CountViewer countViewer1;
        private DevExpress.XtraEditors.LookUpEdit e모델선택;
        private DevExpress.XtraEditors.LabelControl b동작구분;
        private DeviceLamp deviceLamp1;
    }
}
