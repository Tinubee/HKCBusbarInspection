namespace HKCBusbarInspection.UI.Control
{
    partial class Results
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Results));
            this.GridView2 = new MvUtils.CustomView();
            this.GridControl1 = new MvUtils.CustomGrid();
            this.검사자료Bind = new System.Windows.Forms.BindingSource(this.components);
            this.GridView1 = new MvUtils.CustomView();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.b그래프보기 = new DevExpress.XtraEditors.SimpleButton();
            this.e종료일자 = new DevExpress.XtraEditors.DateEdit();
            this.b엑셀파일 = new DevExpress.XtraEditors.SimpleButton();
            this.b자료조회 = new DevExpress.XtraEditors.SimpleButton();
            this.e시작일자 = new DevExpress.XtraEditors.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.BindLocalization = new System.Windows.Forms.BindingSource(this.components);
            this.col검사일시 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col모델구분 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col검사코드 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col측정결과 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCTQ결과 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col외관결과 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col불량정보 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.검사자료Bind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e종료일자.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e종료일자.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e시작일자.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e시작일자.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindLocalization)).BeginInit();
            this.SuspendLayout();
            // 
            // GridView2
            // 
            this.GridView2.AllowColumnMenu = true;
            this.GridView2.AllowCustomMenu = true;
            this.GridView2.AllowExport = true;
            this.GridView2.AllowPrint = true;
            this.GridView2.AllowSettingsMenu = false;
            this.GridView2.AllowSummaryMenu = true;
            this.GridView2.ApplyFocusedRow = true;
            this.GridView2.Caption = "표시내역";
            this.GridView2.DetailHeight = 375;
            this.GridView2.FooterPanelHeight = 22;
            this.GridView2.GridControl = this.GridControl1;
            this.GridView2.GroupRowHeight = 22;
            this.GridView2.IndicatorWidth = 44;
            this.GridView2.MinColumnRowHeight = 24;
            this.GridView2.MinRowHeight = 16;
            this.GridView2.Name = "GridView2";
            this.GridView2.OptionsBehavior.Editable = false;
            this.GridView2.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.GridView2.OptionsCustomization.AllowGroup = false;
            this.GridView2.OptionsCustomization.AllowSort = false;
            this.GridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.GridView2.OptionsMenu.EnableColumnMenu = false;
            this.GridView2.OptionsMenu.EnableFooterMenu = false;
            this.GridView2.OptionsMenu.EnableGroupPanelMenu = false;
            this.GridView2.OptionsNavigation.EnterMoveNextColumn = true;
            this.GridView2.OptionsPrint.AutoWidth = false;
            this.GridView2.OptionsPrint.UsePrintStyles = false;
            this.GridView2.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False;
            this.GridView2.OptionsView.ShowGroupPanel = false;
            this.GridView2.OptionsView.ShowIndicator = false;
            this.GridView2.RowHeight = 21;
            this.GridView2.ViewCaption = "표시내역";
            // 
            // GridControl1
            // 
            this.GridControl1.DataSource = this.검사자료Bind;
            this.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.GridView2;
            gridLevelNode1.RelationName = "검사내역";
            this.GridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.GridControl1.Location = new System.Drawing.Point(0, 41);
            this.GridControl1.MainView = this.GridView1;
            this.GridControl1.Name = "GridControl1";
            this.GridControl1.Size = new System.Drawing.Size(1591, 814);
            this.GridControl1.TabIndex = 18;
            this.GridControl1.UseDirectXPaint = DevExpress.Utils.DefaultBoolean.True;
            this.GridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1,
            this.GridView2});
            // 
            // 검사자료Bind
            // 
            this.검사자료Bind.DataSource = typeof(HKCBusbarInspection.Schemas.검사자료);
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
            this.col검사일시,
            this.col모델구분,
            this.col검사코드,
            this.col측정결과,
            this.colCTQ결과,
            this.col외관결과,
            this.col불량정보});
            this.GridView1.DetailHeight = 375;
            this.GridView1.FooterPanelHeight = 22;
            this.GridView1.GridControl = this.GridControl1;
            this.GridView1.GroupRowHeight = 22;
            this.GridView1.IndicatorWidth = 60;
            this.GridView1.MinColumnRowHeight = 20;
            this.GridView1.MinRowHeight = 16;
            this.GridView1.Name = "GridView1";
            this.GridView1.OptionsBehavior.Editable = false;
            this.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.GridView1.OptionsCustomization.AllowColumnMoving = false;
            this.GridView1.OptionsCustomization.AllowGroup = false;
            this.GridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.GridView1.OptionsDetail.AllowExpandEmptyDetails = true;
            this.GridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.GridView1.OptionsMenu.EnableFooterMenu = false;
            this.GridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.GridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.GridView1.OptionsPrint.AutoWidth = false;
            this.GridView1.OptionsPrint.UsePrintStyles = false;
            this.GridView1.OptionsSelection.MultiSelect = true;
            this.GridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.GridView1.OptionsView.ShowGroupPanel = false;
            this.GridView1.RowHeight = 21;
            // 
            // layoutControl1
            // 
            this.layoutControl1.AutoScroll = false;
            this.layoutControl1.Controls.Add(this.b그래프보기);
            this.layoutControl1.Controls.Add(this.e종료일자);
            this.layoutControl1.Controls.Add(this.b엑셀파일);
            this.layoutControl1.Controls.Add(this.b자료조회);
            this.layoutControl1.Controls.Add(this.e시작일자);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1591, 41);
            this.layoutControl1.TabIndex = 17;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // b그래프보기
            // 
            this.b그래프보기.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.b그래프보기.Appearance.Options.UseFont = true;
            this.b그래프보기.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.b그래프보기.Location = new System.Drawing.Point(793, 10);
            this.b그래프보기.Name = "b그래프보기";
            this.b그래프보기.Size = new System.Drawing.Size(174, 22);
            this.b그래프보기.StyleController = this.layoutControl1;
            this.b그래프보기.TabIndex = 5;
            this.b그래프보기.Text = "그래프 보기";
            // 
            // e종료일자
            // 
            this.e종료일자.EditValue = null;
            this.e종료일자.Location = new System.Drawing.Point(210, 9);
            this.e종료일자.Name = "e종료일자";
            this.e종료일자.Properties.Appearance.Options.UseTextOptions = true;
            this.e종료일자.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e종료일자.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e종료일자.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e종료일자.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.e종료일자.Size = new System.Drawing.Size(119, 22);
            this.e종료일자.StyleController = this.layoutControl1;
            this.e종료일자.TabIndex = 2;
            // 
            // b엑셀파일
            // 
            this.b엑셀파일.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b엑셀파일.ImageOptions.SvgImage")));
            this.b엑셀파일.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.b엑셀파일.Location = new System.Drawing.Point(540, 9);
            this.b엑셀파일.Name = "b엑셀파일";
            this.b엑셀파일.Size = new System.Drawing.Size(174, 24);
            this.b엑셀파일.StyleController = this.layoutControl1;
            this.b엑셀파일.TabIndex = 4;
            this.b엑셀파일.Text = "Export to Excel";
            // 
            // b자료조회
            // 
            this.b자료조회.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b자료조회.ImageOptions.SvgImage")));
            this.b자료조회.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.b자료조회.Location = new System.Drawing.Point(337, 9);
            this.b자료조회.Name = "b자료조회";
            this.b자료조회.Size = new System.Drawing.Size(112, 24);
            this.b자료조회.StyleController = this.layoutControl1;
            this.b자료조회.TabIndex = 3;
            this.b자료조회.Text = "Search";
            // 
            // e시작일자
            // 
            this.e시작일자.EditValue = null;
            this.e시작일자.Location = new System.Drawing.Point(46, 9);
            this.e시작일자.Name = "e시작일자";
            this.e시작일자.Properties.Appearance.Options.UseTextOptions = true;
            this.e시작일자.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e시작일자.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e시작일자.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e시작일자.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.e시작일자.Size = new System.Drawing.Size(119, 22);
            this.e시작일자.StyleController = this.layoutControl1;
            this.e시작일자.TabIndex = 0;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.emptySpaceItem3});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.Root.Size = new System.Drawing.Size(1591, 42);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.e시작일자;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(164, 28);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(164, 28);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem1.Size = new System.Drawing.Size(164, 32);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Start";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(25, 15);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.b자료조회;
            this.layoutControlItem3.Location = new System.Drawing.Point(328, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(120, 32);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(120, 32);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem3.Size = new System.Drawing.Size(120, 32);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.b엑셀파일;
            this.layoutControlItem2.Location = new System.Drawing.Point(531, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(182, 32);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(182, 32);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem2.Size = new System.Drawing.Size(182, 32);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(448, 0);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(83, 0);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(83, 11);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(83, 32);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.e종료일자;
            this.layoutControlItem5.Location = new System.Drawing.Point(164, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(164, 32);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(164, 32);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem5.Size = new System.Drawing.Size(164, 32);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "End";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(25, 15);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem4.Control = this.b그래프보기;
            this.layoutControlItem4.Location = new System.Drawing.Point(786, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(26, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(178, 32);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(964, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(617, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(713, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(73, 32);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1591, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 855);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1591, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 855);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1591, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 855);
            // 
            // col검사일시
            // 
            this.col검사일시.AppearanceHeader.Options.UseTextOptions = true;
            this.col검사일시.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col검사일시.FieldName = "검사일시";
            this.col검사일시.Name = "col검사일시";
            this.col검사일시.Visible = true;
            this.col검사일시.VisibleIndex = 0;
            // 
            // col모델구분
            // 
            this.col모델구분.AppearanceHeader.Options.UseTextOptions = true;
            this.col모델구분.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col모델구분.FieldName = "모델구분";
            this.col모델구분.Name = "col모델구분";
            this.col모델구분.Visible = true;
            this.col모델구분.VisibleIndex = 1;
            // 
            // col검사코드
            // 
            this.col검사코드.AppearanceHeader.Options.UseTextOptions = true;
            this.col검사코드.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col검사코드.FieldName = "검사코드";
            this.col검사코드.Name = "col검사코드";
            this.col검사코드.Visible = true;
            this.col검사코드.VisibleIndex = 2;
            // 
            // col측정결과
            // 
            this.col측정결과.AppearanceHeader.Options.UseTextOptions = true;
            this.col측정결과.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col측정결과.FieldName = "측정결과";
            this.col측정결과.Name = "col측정결과";
            this.col측정결과.Visible = true;
            this.col측정결과.VisibleIndex = 3;
            // 
            // colCTQ결과
            // 
            this.colCTQ결과.AppearanceHeader.Options.UseTextOptions = true;
            this.colCTQ결과.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCTQ결과.FieldName = "CTQ결과";
            this.colCTQ결과.Name = "colCTQ결과";
            this.colCTQ결과.Visible = true;
            this.colCTQ결과.VisibleIndex = 4;
            // 
            // col외관결과
            // 
            this.col외관결과.AppearanceHeader.Options.UseTextOptions = true;
            this.col외관결과.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col외관결과.FieldName = "외관결과";
            this.col외관결과.Name = "col외관결과";
            this.col외관결과.Visible = true;
            this.col외관결과.VisibleIndex = 5;
            // 
            // col불량정보
            // 
            this.col불량정보.AppearanceHeader.Options.UseTextOptions = true;
            this.col불량정보.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col불량정보.FieldName = "불량정보";
            this.col불량정보.Name = "col불량정보";
            this.col불량정보.Visible = true;
            this.col불량정보.VisibleIndex = 6;
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridControl1);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Results";
            this.Size = new System.Drawing.Size(1591, 855);
            ((System.ComponentModel.ISupportInitialize)(this.GridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.검사자료Bind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.e종료일자.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e종료일자.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e시작일자.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e시작일자.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindLocalization)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MvUtils.CustomGrid GridControl1;
        private MvUtils.CustomView GridView2;
        private MvUtils.CustomView GridView1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton b그래프보기;
        private DevExpress.XtraEditors.DateEdit e종료일자;
        private DevExpress.XtraEditors.SimpleButton b엑셀파일;
        private DevExpress.XtraEditors.SimpleButton b자료조회;
        private DevExpress.XtraEditors.DateEdit e시작일자;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private System.Windows.Forms.BindingSource 검사자료Bind;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource BindLocalization;
        private DevExpress.XtraGrid.Columns.GridColumn col검사일시;
        private DevExpress.XtraGrid.Columns.GridColumn col모델구분;
        private DevExpress.XtraGrid.Columns.GridColumn col검사코드;
        private DevExpress.XtraGrid.Columns.GridColumn col측정결과;
        private DevExpress.XtraGrid.Columns.GridColumn colCTQ결과;
        private DevExpress.XtraGrid.Columns.GridColumn col외관결과;
        private DevExpress.XtraGrid.Columns.GridColumn col불량정보;
    }
}
