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
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.e모델선택 = new DevExpress.XtraEditors.LookUpEdit();
            this.모델자료Bind = new System.Windows.Forms.BindingSource(this.components);
            this.b동작구분 = new DevExpress.XtraEditors.LabelControl();
            this.e장치상태 = new HKCBusbarInspection.UI.Control.DeviceLamp();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.e양품수율 = new HKCBusbarInspection.UI.Control.CountViewer();
            this.e전체수량 = new HKCBusbarInspection.UI.Control.CountViewer();
            this.e불량수량 = new HKCBusbarInspection.UI.Control.CountViewer();
            this.e양품수량 = new HKCBusbarInspection.UI.Control.CountViewer();
            this.b수량리셋 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.e저장용량 = new DevExpress.XtraEditors.ProgressBarControl();
            this.ciView1 = new HKCBusbarInspection.UI.Control.CiView();
            this.titleView1 = new HKCBusbarInspection.UI.Control.TitleView();
            this.BindLocalization = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e모델선택.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.모델자료Bind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e저장용량.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindLocalization)).BeginInit();
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
            this.panelControl2.Controls.Add(this.e장치상태);
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
            this.e모델선택.Properties.DataSource = this.모델자료Bind;
            this.e모델선택.Properties.DisplayMember = "모델구분";
            this.e모델선택.Properties.NullText = "[Model]";
            this.e모델선택.Properties.ValueMember = "모델구분";
            this.e모델선택.Size = new System.Drawing.Size(424, 95);
            this.e모델선택.TabIndex = 16;
            // 
            // 모델자료Bind
            // 
            this.모델자료Bind.DataSource = typeof(HKCBusbarInspection.Schemas.모델자료);
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
            // e장치상태
            // 
            this.e장치상태.Dock = System.Windows.Forms.DockStyle.Left;
            this.e장치상태.Location = new System.Drawing.Point(3, 3);
            this.e장치상태.Name = "e장치상태";
            this.e장치상태.Size = new System.Drawing.Size(200, 95);
            this.e장치상태.TabIndex = 14;
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F)});
            this.tablePanel1.Controls.Add(this.e양품수율);
            this.tablePanel1.Controls.Add(this.e전체수량);
            this.tablePanel1.Controls.Add(this.e불량수량);
            this.tablePanel1.Controls.Add(this.e양품수량);
            this.tablePanel1.Controls.Add(this.b수량리셋);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tablePanel1.Location = new System.Drawing.Point(843, 3);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(500, 95);
            this.tablePanel1.TabIndex = 3;
            // 
            // e양품수율
            // 
            this.e양품수율.BaseColor = System.Drawing.Color.Empty;
            this.e양품수율.Caption = "Yield";
            this.e양품수율.CaptionFont = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tablePanel1.SetColumn(this.e양품수율, 3);
            this.e양품수율.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e양품수율.Location = new System.Drawing.Point(303, 3);
            this.e양품수율.Name = "e양품수율";
            this.tablePanel1.SetRow(this.e양품수율, 0);
            this.e양품수율.Size = new System.Drawing.Size(94, 89);
            this.e양품수율.TabIndex = 16;
            this.e양품수율.TextFont = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e양품수율.ValueText = "100.0";
            // 
            // e전체수량
            // 
            this.e전체수량.BaseColor = System.Drawing.Color.Empty;
            this.e전체수량.Caption = "Total";
            this.e전체수량.CaptionFont = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tablePanel1.SetColumn(this.e전체수량, 2);
            this.e전체수량.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e전체수량.Location = new System.Drawing.Point(203, 3);
            this.e전체수량.Name = "e전체수량";
            this.tablePanel1.SetRow(this.e전체수량, 0);
            this.e전체수량.Size = new System.Drawing.Size(94, 89);
            this.e전체수량.TabIndex = 15;
            this.e전체수량.TextFont = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e전체수량.ValueText = "100.0";
            // 
            // e불량수량
            // 
            this.e불량수량.BaseColor = System.Drawing.Color.Empty;
            this.e불량수량.Caption = "NG";
            this.e불량수량.CaptionFont = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tablePanel1.SetColumn(this.e불량수량, 1);
            this.e불량수량.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e불량수량.Location = new System.Drawing.Point(103, 3);
            this.e불량수량.Name = "e불량수량";
            this.tablePanel1.SetRow(this.e불량수량, 0);
            this.e불량수량.Size = new System.Drawing.Size(94, 89);
            this.e불량수량.TabIndex = 14;
            this.e불량수량.TextFont = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e불량수량.ValueText = "100.0";
            // 
            // e양품수량
            // 
            this.e양품수량.BaseColor = System.Drawing.Color.Empty;
            this.e양품수량.Caption = "OK";
            this.e양품수량.CaptionFont = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tablePanel1.SetColumn(this.e양품수량, 0);
            this.e양품수량.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e양품수량.Location = new System.Drawing.Point(3, 3);
            this.e양품수량.Name = "e양품수량";
            this.tablePanel1.SetRow(this.e양품수량, 0);
            this.e양품수량.Size = new System.Drawing.Size(94, 89);
            this.e양품수량.TabIndex = 1;
            this.e양품수량.TextFont = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e양품수량.ValueText = "100.0";
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
            ((System.ComponentModel.ISupportInitialize)(this.모델자료Bind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.e저장용량.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindLocalization)).EndInit();
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
        private CountViewer e양품수율;
        private CountViewer e전체수량;
        private CountViewer e불량수량;
        private CountViewer e양품수량;
        private DevExpress.XtraEditors.LookUpEdit e모델선택;
        private DevExpress.XtraEditors.LabelControl b동작구분;
        private DeviceLamp e장치상태;
        private System.Windows.Forms.BindingSource 모델자료Bind;
        private System.Windows.Forms.BindingSource BindLocalization;
    }
}
