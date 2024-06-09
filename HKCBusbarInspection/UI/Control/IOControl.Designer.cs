namespace HKCBusbarInspection.UI.Control
{
    partial class IOControl
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
            this.g입출목록 = new DevExpress.XtraEditors.GroupControl();
            this.GridControl1 = new MvUtils.CustomGrid();
            this.입력신호Bind = new System.Windows.Forms.BindingSource(this.components);
            this.GridView1 = new MvUtils.CustomView();
            this.col구분 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col번호 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col주소 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col정보 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemToggleSwitch1 = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.repositoryItemToggleSwitch2 = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.g입출목록)).BeginInit();
            this.g입출목록.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.입력신호Bind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch2)).BeginInit();
            this.SuspendLayout();
            // 
            // g입출목록
            // 
            this.g입출목록.Controls.Add(this.GridControl1);
            this.g입출목록.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g입출목록.Location = new System.Drawing.Point(0, 0);
            this.g입출목록.Name = "g입출목록";
            this.g입출목록.Size = new System.Drawing.Size(819, 652);
            this.g입출목록.TabIndex = 3;
            this.g입출목록.Text = "Input";
            // 
            // GridControl1
            // 
            this.GridControl1.DataSource = this.입력신호Bind;
            this.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControl1.Location = new System.Drawing.Point(2, 27);
            this.GridControl1.MainView = this.GridView1;
            this.GridControl1.Name = "GridControl1";
            this.GridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemToggleSwitch1,
            this.repositoryItemToggleSwitch2});
            this.GridControl1.Size = new System.Drawing.Size(815, 623);
            this.GridControl1.TabIndex = 0;
            this.GridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            // 
            // 입력신호Bind
            // 
            this.입력신호Bind.DataSource = typeof(HKCBusbarInspection.UI.Control.IOControl.입력신호자료);
            // 
            // GridView1
            // 
            this.GridView1.AllowColumnMenu = true;
            this.GridView1.AllowCustomMenu = true;
            this.GridView1.AllowExport = true;
            this.GridView1.AllowPrint = true;
            this.GridView1.AllowSettingsMenu = false;
            this.GridView1.AllowSummaryMenu = true;
            this.GridView1.ApplyFocusedRow = true;
            this.GridView1.Caption = "";
            this.GridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col구분,
            this.col번호,
            this.col주소,
            this.col정보});
            this.GridView1.DetailHeight = 402;
            this.GridView1.FooterPanelHeight = 24;
            this.GridView1.GridControl = this.GridControl1;
            this.GridView1.GroupRowHeight = 24;
            this.GridView1.IndicatorWidth = 44;
            this.GridView1.MinColumnRowHeight = 24;
            this.GridView1.MinRowHeight = 1;
            this.GridView1.Name = "GridView1";
            this.GridView1.OptionsBehavior.Editable = false;
            this.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.GridView1.OptionsCustomization.AllowColumnMoving = false;
            this.GridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.GridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.GridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.GridView1.OptionsPrint.AutoWidth = false;
            this.GridView1.OptionsPrint.UsePrintStyles = false;
            this.GridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.GridView1.OptionsView.ShowGroupPanel = false;
            this.GridView1.OptionsView.ShowIndicator = false;
            this.GridView1.RowHeight = 22;
            // 
            // col구분
            // 
            this.col구분.AppearanceHeader.Options.UseTextOptions = true;
            this.col구분.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col구분.FieldName = "구분";
            this.col구분.Name = "col구분";
            this.col구분.Visible = true;
            this.col구분.VisibleIndex = 0;
            // 
            // col번호
            // 
            this.col번호.AppearanceHeader.Options.UseTextOptions = true;
            this.col번호.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col번호.FieldName = "번호";
            this.col번호.Name = "col번호";
            this.col번호.OptionsColumn.ReadOnly = true;
            this.col번호.Visible = true;
            this.col번호.VisibleIndex = 1;
            // 
            // col주소
            // 
            this.col주소.AppearanceHeader.Options.UseTextOptions = true;
            this.col주소.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col주소.FieldName = "주소";
            this.col주소.Name = "col주소";
            this.col주소.OptionsColumn.ReadOnly = true;
            this.col주소.Visible = true;
            this.col주소.VisibleIndex = 2;
            // 
            // col정보
            // 
            this.col정보.AppearanceHeader.Options.UseTextOptions = true;
            this.col정보.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col정보.FieldName = "정보";
            this.col정보.Name = "col정보";
            this.col정보.OptionsColumn.ReadOnly = true;
            this.col정보.Visible = true;
            this.col정보.VisibleIndex = 3;
            // 
            // repositoryItemToggleSwitch1
            // 
            this.repositoryItemToggleSwitch1.AutoHeight = false;
            this.repositoryItemToggleSwitch1.Name = "repositoryItemToggleSwitch1";
            this.repositoryItemToggleSwitch1.OffText = "Off";
            this.repositoryItemToggleSwitch1.OnText = "On";
            // 
            // repositoryItemToggleSwitch2
            // 
            this.repositoryItemToggleSwitch2.AutoHeight = false;
            this.repositoryItemToggleSwitch2.Name = "repositoryItemToggleSwitch2";
            this.repositoryItemToggleSwitch2.OffText = "Off";
            this.repositoryItemToggleSwitch2.OnText = "On";
            // 
            // IOControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.g입출목록);
            this.Name = "IOControl";
            this.Size = new System.Drawing.Size(819, 652);
            ((System.ComponentModel.ISupportInitialize)(this.g입출목록)).EndInit();
            this.g입출목록.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.입력신호Bind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl g입출목록;
        private MvUtils.CustomGrid GridControl1;
        private MvUtils.CustomView GridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repositoryItemToggleSwitch1;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repositoryItemToggleSwitch2;
        private System.Windows.Forms.BindingSource 입력신호Bind;
        private DevExpress.XtraGrid.Columns.GridColumn col구분;
        private DevExpress.XtraGrid.Columns.GridColumn col번호;
        private DevExpress.XtraGrid.Columns.GridColumn col주소;
        private DevExpress.XtraGrid.Columns.GridColumn col정보;
    }
}
