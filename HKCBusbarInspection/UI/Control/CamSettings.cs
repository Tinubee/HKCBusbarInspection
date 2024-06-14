using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using HKCBusbarInspection.Schemas;
using MvUtils;
using System;

namespace HKCBusbarInspection.UI.Control
{
    public partial class CamSettings : XtraUserControl
    {
        private LocalizationCamSetting 번역 = new LocalizationCamSetting();
        public CamSettings() => InitializeComponent();

        public void Init()
        {
            this.GridView1.Init();
            this.GridView1.OptionsBehavior.Editable = true;
            this.GridView1.OptionsView.ShowAutoFilterRow = false;
            this.GridView1.OptionsView.ShowFooter = false;
            this.GridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            this.GridControl1.DataSource = Global.그랩제어.Values;

            this.GridView2.Init();
            this.GridView2.OptionsBehavior.Editable = true;
            this.GridView2.OptionsView.ShowAutoFilterRow = false;
            this.GridView2.OptionsView.ShowFooter = false;
            this.GridControl2.DataSource = Global.조명제어;

            Localization.SetColumnCaption(this.GridView1, typeof(그랩장치));
            Localization.SetColumnCaption(this.GridView2, typeof(조명정보));
            this.b켜기.Click += 모두켜기;
            this.b끄기.Click += 모두끄기;
            this.b저장.Click += 저장하기;
            this.b저장.Text = Localization.저장.GetString();
            this.GridView2.CellValueChanged += GridView2_CellValueChanged;
            this.e조명켜짐.Toggled += E켜짐_Toggled;

            this.g카메라들.Text = this.번역.카메라목록;
            this.g조명들.Text = this.번역.조명목록;
        }

        public void UpdateLight() => GridView2.RefreshData();

        public void Close() { }

        private void 모두켜기(object sender, EventArgs e) => Global.조명제어.TurnOn();
        private void 모두끄기(object sender, EventArgs e) => Global.조명제어.TurnOff();

        private void 저장하기(object sender, EventArgs e)
        {
            if (!Utils.Confirm(this.FindForm(), 번역.저장확인, Localization.확인.GetString())) return;

            this.GridControl1.EmbeddedNavigator.Buttons.DoClick(this.GridControl1.EmbeddedNavigator.Buttons.EndEdit);
            this.GridControl2.EmbeddedNavigator.Buttons.DoClick(this.GridControl2.EmbeddedNavigator.Buttons.EndEdit);
            Global.그랩제어.Save();
            Global.조명제어.Save();
            Global.정보로그("카메라 설정", "설정저장", "저장되었습니다.", this.FindForm());
        }

        private void GridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != this.col밝기.FieldName) return;
            GridView view = sender as GridView;
            조명정보 정보 = view.GetRow(e.RowHandle) as 조명정보;
            정보?.Set();
            view.RefreshRow(e.RowHandle);
        }

        private void E켜짐_Toggled(object sender, EventArgs e)
        {
            조명정보 정보 = this.GridView2.GetRow(this.GridView2.FocusedRowHandle) as 조명정보;
            if (정보 == null) return;
            정보.OnOff();
            //UpdateLight();
        }

        private class LocalizationCamSetting
        {
            private enum Items
            {
                [Translation("Cameras", "카메라목록")]
                카메라목록,
                [Translation("Lisghts", "조명목록")]
                조명목록,
                [Translation("Save", "설정저장")]
                설정저장,
                [Translation("It's saved.", "저장되었습니다.")]
                저장완료,
                [Translation("Save your Camera & Light Setting?", "카메라 및 조명설정을 저장하시겠습니까?")]
                저장확인,
            }
            public String 카메라목록 => Localization.GetString(Items.카메라목록);
            public String 조명목록 => Localization.GetString(Items.조명목록);
            public String 설정저장 => Localization.GetString(Items.설정저장);
            public String 저장완료 => Localization.GetString(Items.저장완료);
            public String 저장확인 => Localization.GetString(Items.저장확인);
        }
    }
}
