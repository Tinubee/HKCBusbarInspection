using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using HKCBusbarInspection.Schemas;
using HKCBusbarInspection.UI.Form;
using MvUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HKCBusbarInspection.Schemas.신호제어;

namespace HKCBusbarInspection.UI.Control
{
    public partial class SetInspection : XtraUserControl
    {
        public delegate void 검사항목선택(모델정보 모델, 검사정보 설정);
        public event 검사항목선택 검사항목변경;
        private LocalizationInspection 번역 = new LocalizationInspection();
        private PopupMenu popupMenu;
        private String 로그영역 = "검사설정";

        public SetInspection() => InitializeComponent();

        public void Init()
        {
            this.SetLocalization();
            this.GridView1.Init(this.barManager1);
            this.GridView1.OptionsBehavior.Editable = true;
            this.GridView1.OptionsSelection.MultiSelect = true;
            this.GridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            this.GridView1.AddEditSelectionMenuItem();
            this.GridView1.AddSelectPopMenuItems();
            this.GridView1.CustomDrawCell += GridView1_CustomDrawCell;
            this.GridView1.CellValueChanged += GridView1_CellValueChanged;
            this.col최소값.DisplayFormat.FormatString = Global.환경설정.결과표현;
            this.col최대값.DisplayFormat.FormatString = Global.환경설정.결과표현;
            this.col기준값.DisplayFormat.FormatString = Global.환경설정.결과표현;
            this.col보정값.DisplayFormat.FormatString = Global.환경설정.결과표현;
            this.col실측값.DisplayFormat.FormatString = Global.환경설정.결과표현;

            popupMenu = new PopupMenu(this.barManager1);

            BarButtonItem Grab = new BarButtonItem(this.barManager1, "Grab Image");
            BarButtonItem Master = new BarButtonItem(this.barManager1, "Master Image");

            Grab.ImageOptions.SvgImage = MvUtils.Resources.검색;
            Master.ImageOptions.SvgImage = MvUtils.Resources.보기;

            popupMenu.AddItem(Grab);
            popupMenu.AddItem(Master);

            Grab.ItemClick += 이미지그랩후검사;
            Master.ItemClick += 마스터이미지검사;

            this.e모델선택.EditValueChanged += 모델선택;
            this.e모델선택.Properties.DataSource = Global.모델자료;
            this.e모델선택.EditValue = Global.환경설정.선택모델;
            this.e모델선택.CustomDisplayText += 선택모델표현;
            this.b도구설정.Click += 도구설정;
            this.b설정저장.Click += 설정저장;
            this.b수동검사.Click += 수동검사;
            this.b셔틀위치.ButtonClick += 보정값계산;
            this.b캘리브레이션.Click += 캘리브레이션;

            EnumToList 셔틀위치 = new EnumToList(그랩제어.대상셔틀.ToArray());
            셔틀위치.SetLookUpEdit(this.b셔틀위치);
            this.b셔틀위치.EditValue = 그랩제어.대상셔틀.First();
            this.b셔틀위치.EditValueChanged += 셔틀위치변경;

            Global.검사자료.수동검사알림 += 수동검사알림;
            this.ｅ교정계산.ButtonClick += 교정계산;

            Localization.SetColumnCaption(this.e모델선택, typeof(모델정보));
            Localization.SetColumnCaption(this.GridView1, typeof(검사정보));
            this.모델선택(this.e모델선택, EventArgs.Empty);
        }

        private void 셔틀위치변경(object sender, EventArgs e) => Global.환경설정.수동검사셔틀위치 = (셔틀위치번호)this.b셔틀위치.EditValue;

        private void 캘리브레이션(object sender, EventArgs e)
        {
            CalibrationForm f = new CalibrationForm();
            f.Show(Global.MainForm);
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != this.col보정값.FieldName || e.Column.FieldName != this.col검사여부.FieldName) return;

        }

        private void 보정값계산(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.b셔틀위치.EditValue == null) return;

            if (e.Button.Index == 1) 교정값전체계산();
            if (e.Button.Index == 3) 교정값전체초기화();

        }
        public void 교정값전체초기화()
        {
            if (!Utils.Confirm(this.FindForm(), $"{this.b셔틀위치.EditValue}  {번역.전체캘초기화}")) return;

            Int32 셔틀위치 = (Int32)this.b셔틀위치.EditValue - 1;
            for (int lop = 0; lop < this.검사설정.Count; lop++)
            {
                검사정보 정보 = this.검사설정[lop] as 검사정보;

                정보.교정값 = 1;
                //정보.실측값 = 0;

                if (정보.측정단위 == 단위구분.mm)
                    Global.VM제어.글로벌변수제어.교정값적용하기(정보.검사항목, 셔틀위치, 정보.교정값);
            }

            Global.정보로그(로그영역, "초기화", $"[{this.b셔틀위치.EditValue}] 교정값 및 실측값 전체 초기화.", true);
            this.GridView1.RefreshData();
        }

        public void 교정값전체계산()
        {
            if (!Utils.Confirm(this.FindForm(), $"{this.b셔틀위치.EditValue} {번역.전체캘작업실행}")) return;
            //전체 보정값계산로직 추가
            Int32 셔틀위치 = (Int32)this.b셔틀위치.EditValue - 1;
            for (int lop = 0; lop < this.검사설정.Count; lop++)
            {
                검사정보 정보 = this.검사설정[lop] as 검사정보;

                Decimal 적용할교정값 = 정보.교정계산();

                if (정보.측정단위 == 단위구분.mm)
                    Global.VM제어.글로벌변수제어.교정값적용하기(정보.검사항목, 셔틀위치, 적용할교정값);
            }

            Global.정보로그(로그영역, "초기화", $"[{this.b셔틀위치.EditValue}] 전체항목 캘리브레이션 완료.", true);
            this.GridView1.RefreshData();
        }

        private void 마스터이미지검사(object sender, ItemClickEventArgs e)
        {
            foreach (카메라구분 구분 in typeof(카메라구분).GetValues())
            {
                if (구분 == 카메라구분.None || 구분 == 카메라구분.Cam05) continue;

                Global.모델자료.GetItem(Global.환경설정.선택모델).카메라구분 = 구분;
                String filePath = Global.모델자료.GetItem(Global.환경설정.선택모델).모델사진;

                비전마스터플로우 플로우 = Global.VM제어.GetItem(구분);

                플로우.Run(null, null, filePath, Global.검사자료.수동검사);
            }

            검사결과 검사 = Global.검사자료.검사결과계산(Global.검사자료.수동검사.검사코드,false);

            foreach (카메라구분 구분 in typeof(카메라구분).GetValues())
            {
                Global.검사자료.수동검사결과(구분, 검사);
            }
        }

        private void 이미지그랩후검사(object sender, ItemClickEventArgs e)
        {
            if (Global.장치상태.자동수동) { Utils.WarningMsg($"{this.번역.자동모드사용불가}"); return; }

            new Thread(() =>
            {
                Global.조명제어.TurnOn(카메라구분.Cam01);
                Global.조명제어.TurnOn(카메라구분.Cam02);
                Global.조명제어.TurnOn(카메라구분.Cam03);

                Global.그랩제어.GetItem(카메라구분.Cam01).SoftwareTrigger();
                Global.그랩제어.GetItem(카메라구분.Cam02).SoftwareTrigger();
                Global.그랩제어.GetItem(카메라구분.Cam03).SoftwareTrigger();
            })
            { Priority = ThreadPriority.Highest }.Start();
        }

        private void 수동검사(object sender, EventArgs e)
        {
            System.Drawing.Point btnLocation = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            popupMenu.ShowPopup(btnLocation);
        }

        public void Close() { }

        private 모델구분 선택모델 { get { return (모델구분)this.e모델선택.EditValue; } }
        public 검사설정 검사설정 { get { return Global.모델자료.GetItem(this.선택모델)?.검사설정; } }

        private void 모델선택(object sender, EventArgs e)
        {
            try
            {
                this.GridControl1.DataSource = this.검사설정;
                if (this.검사설정 != null && this.검사설정.Count > 0)
                {
                    Task.Run(() =>
                    {
                        Task.Delay(500).Wait();
                        this.GridView1.MoveFirst();
                        this.검사항목변경?.Invoke(Global.모델자료.GetItem(this.선택모델), this.GetItem(this.GridView1, this.GridView1.FocusedRowHandle));
                    });
                }
            }
            catch (Exception ex)
            {
                Global.오류로그(검사설정.로그영역.GetString(), 번역.모델선택, $"{번역.모델선택}\r\n{ex.Message}", true);
                this.GridControl1.DataSource = null;
            }
        }

        private void 선택모델표현(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            try
            {
                모델구분 모델 = (모델구분)e.Value;
                e.DisplayText = $"{((Int32)모델).ToString("d2")}. {Utils.GetDescription(모델)}";
            }
            catch { e.DisplayText = String.Empty; }
        }

        private void 도구설정(object sender, EventArgs e)
        {
            System.Windows.Forms.Form opFrm = Application.OpenForms["Teaching"];

            if (opFrm != null) return;

            Teaching form = new Teaching();
            form.Show(Global.MainForm);
        }

        private 검사정보 GetItem(GridView view, Int32 RowHandle)
        {
            if (view == null) return null;
            return view.GetRow(RowHandle) as 검사정보;
        }

        private void 설정저장(object sender, EventArgs e)
        {
            검사설정 설정 = this.검사설정;
            if (설정 == null) return;
            if (!Utils.Confirm(this.FindForm(), 번역.저장확인)) return;

            Global.VM제어.Save();
            Global.검사자료.수동검사.Reset(DateTime.Now);

            if (설정.Save()) Global.정보로그(검사설정.로그영역.GetString(), 번역.설정저장, 번역.저장완료, true);

            Global.MainForm.e결과뷰어.e결과목록.RefreshData();
            Global.MainForm.e변수설정.UpdateGridView();
        }

        private void 검사설정변경()
        {
            if (this.InvokeRequired) { this.BeginInvoke(new Action(검사설정변경)); return; }
            this.GridView1.RefreshData();
        }

        private void 수동검사알림(카메라구분 카메라, 검사결과 결과)
        {
            if (this.InvokeRequired) { this.BeginInvoke(new Action(() => 수동검사알림(카메라, 결과))); return; }
            foreach (검사정보 설정 in 검사설정)
            {
                if (설정.검사장치 != (장치구분)카메라) continue;
                검사정보 검사 = 결과.검사내역.Where(e => e.검사항목 == 설정.검사항목).FirstOrDefault();

                if (검사 == null || 검사.측정결과 <= 결과구분.ER) continue;
                설정.측정값 = 검사.측정값;
                설정.결과값 = 검사.결과값;
            }
            this.GridView1.RefreshData();
        }

        private void 교정계산(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) //개별항목에 대한 보정.
        {
            검사정보 정보 = this.GridView1.GetFocusedRow() as 검사정보;
            if (정보 == null) return;
            if (정보.실측값 <= 0) { Utils.WarningMsg($"{번역.실측값없음}"); return; }
            if (!정보.검사항목.ToString().Contains("위치도"))
            {
                if (정보.측정값 <= 0) { Utils.WarningMsg($"{번역.측정값없음}"); return; }
            }
           
            if (정보.측정단위 != 단위구분.mm) { Utils.WarningMsg($"{정보.검사명칭} {번역.캘작업불가능}"); return; }
            if (!Utils.Confirm(this.FindForm(), $"{this.b셔틀위치.EditValue} {정보.검사명칭} {번역.캘작업실행}")) return;

            Int32 셔틀위치 = (Int32)this.b셔틀위치.EditValue - 1;
            Decimal 적용할교정값 = 정보.교정계산();

            Debug.WriteLine($"셔틀위치 : {셔틀위치}, 검사항목 : {정보.검사항목} ,교정값 : {적용할교정값}");

            Global.VM제어.글로벌변수제어.교정값적용하기(정보.검사항목, 셔틀위치, 적용할교정값);;

            this.GridView1.RefreshRow(this.GridView1.FocusedRowHandle);
        }

        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView view = sender as GridView;
            검사정보 정보 = view.GetRow(e.RowHandle) as 검사정보;
            if (정보 == null) return;
            정보.SetAppearance(e);
        }

        private void SetLocalization()
        {
            this.b설정저장.Text = 번역.설정저장;
            this.b도구설정.Text = this.번역.도구설정;
            this.b수동검사.Text = this.번역.수동검사;
            this.b셔틀위치.Properties.Buttons[1].ToolTip = this.번역.교정값계산;
            this.b셔틀위치.Properties.Buttons[3].ToolTip = this.번역.교정값초기화;
            this.b캘리브레이션.Text = this.번역.캘리브레이션;
        }

        private class LocalizationInspection
        {
            private enum Items
            {
                [Translation("VM", "VM설정")]
                도구설정,
                [Translation("Manual Inspection", "수동검사")]
                수동검사,

                [Translation("Calibration Calculation", "교정값 계산")]
                교정값계산,
                [Translation("Calibration Initialize", "교정값 초기화")]
                교정값초기화,
                [Translation("Calibration", "캘리브레이션")]
                캘리브레이션,

                [Translation("Save", "설정저장")]
                설정저장,
                [Translation("It's saved.", "저장되었습니다.")]
                저장완료,
                [Translation("Save the inspection settings?", "검사 설정을 저장하시겠습니까?")]
                저장확인,
                [Translation("Delete this selected item?", "선택 항목을 삭제하시겠습니까?")]
                삭제확인,

                [Translation("Select Model", "모델선택")]
                모델선택,
                [Translation("No models selected.", "선택한 모델이 없습니다.")]
                모델없음,
                [Translation("FlipXY", "위치회전")]
                위치회전,
                [Translation("Do you want to rotate Viewer position?", "뷰어 위치를 회전하시겠습니까?")]
                회전확인,

                [Translation("Enter the measured value and run it.", "실측값을 입력 후 실행하세요.")]
                실측값없음,
                [Translation("Perform a scan and run it.", "검사를 수행 후 실행하세요.")]
                측정값없음,
                [Translation("This is can't calibration item.", "항목은 캘리브레이션 작업을 수행 할 수 없는 항목입니다.")]
                캘작업불가능,
                [Translation("Do you want to run calibration?", "캘리브레이션을 수행하시겠습니까?")]
                캘작업실행,
                [Translation("Do you want to run calibration all items?", "전체항목 캘리브레이션을 수행하시겠습니까?")]
                전체캘작업실행,
                [Translation("Do you want to run initialize calibration all items?", "전체항목 교정값 및 실측값을 초기화 하시겠습니까?")]
                전체캘초기화,
                [Translation("It can't use when it is in Auto Mode.", "자동모드 일때는 사용할 수 없습니다.")]
                자동모드사용불가,
            }

            public String 설정저장 { get => Localization.GetString(Items.설정저장); }
            public String 저장완료 { get => Localization.GetString(Items.저장완료); }
            public String 저장확인 { get => Localization.GetString(Items.저장확인); }
            public String 삭제확인 { get => Localization.GetString(Items.삭제확인); }
            public String 모델선택 { get => Localization.GetString(Items.모델선택); }
            public String 모델없음 { get => Localization.GetString(Items.모델없음); }
            public String 위치회전 { get => Localization.GetString(Items.위치회전); }
            public String 회전확인 { get => Localization.GetString(Items.회전확인); }
            public String 도구설정 { get => Localization.GetString(Items.도구설정); }
            public String 수동검사 { get => Localization.GetString(Items.수동검사); }
            public String 교정값계산 { get => Localization.GetString(Items.교정값계산); }
            public String 교정값초기화 { get => Localization.GetString(Items.교정값초기화); }
            public String 실측값없음 { get => Localization.GetString(Items.실측값없음); }
            public String 측정값없음 { get => Localization.GetString(Items.측정값없음); }
            public String 캘작업불가능 { get => Localization.GetString(Items.캘작업불가능); }
            public String 캘작업실행 { get => Localization.GetString(Items.캘작업실행); }
            public String 전체캘작업실행 { get => Localization.GetString(Items.전체캘작업실행); }
            public String 전체캘초기화 { get => Localization.GetString(Items.전체캘초기화); }
            public String 자동모드사용불가 { get => Localization.GetString(Items.자동모드사용불가); }
            public String 캘리브레이션 { get => Localization.GetString(Items.캘리브레이션); }
        }
    }
}
