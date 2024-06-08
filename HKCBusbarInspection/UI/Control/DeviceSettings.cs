using DevExpress.XtraEditors;
using HKCBusbarInspection.Schemas;
using MvUtils;
using System;

namespace HKCBusbarInspection.UI.Control
{
    public partial class DeviceSettings : XtraUserControl
    {
        private LocalizationDeviceSetting 번역 = new LocalizationDeviceSetting();
        public DeviceSettings()
        {
            InitializeComponent();
            this.SetLocalization();
            this.BindLocalization.DataSource = this.번역;
            this.환경설정Bind.DataSource = Global.환경설정;

            this.b설정저장.Click += 환경설정저장;
        }

        public void Init()
        {
            this.e카메라.Init();
            this.e기본설정.Init();
            this.e입출신호.Init();
        }

        private void 환경설정저장(object sender, EventArgs e)
        {
            this.환경설정Bind.EndEdit();
            if (!Utils.Confirm(this.FindForm(), 번역.저장확인, Localization.확인.GetString())) return;
            Global.환경설정.Save();
            Global.정보로그(환경설정.로그영역.GetString(), 번역.설정저장, 번역.저장완료, true);
        }

        public void Close()
        {
          
        }
        private void SetLocalization()
        {
            this.b설정저장.Text = this.번역.설정저장;
            this.g강제배출.Text = this.번역.강제배출;
            this.g트리거보드.Text = this.번역.트리거보드초기화;
            this.b캠트리거리셋.Text = this.번역.초기화;
            this.b표면검사이미지저장.Text = this.번역.표면검사이미지저장사용;
            this.t기타설정.Text = this.번역.기타설정;
            this.t환경설정.Text = this.번역.기본설정;
        }

        private class LocalizationDeviceSetting
        {
            private enum Items
            {
                [Translation("Forced Ejection", "강제배출")]
                강제배출,
                [Translation("TriggerBoard Position Reset ", "트리거보드 초기화")]
                트리거보드초기화,
                [Translation("Reset", "초기화")]
                초기화,
                [Translation("Surface Image Save Used", "표면검사이미지 저장사용")]
                표면검사이미지저장사용,

                [Translation("Other", "기타장치")]
                기타설정,
                [Translation("Config", "기본설정")]
                기본설정,

                [Translation("Save", "설정저장")]
                설정저장,
                [Translation("It's saved.", "저장되었습니다.")]
                저장완료,
                [Translation("Save your preferences?", "환경설정을 저장하시겠습니까?")]
                저장확인,
            }
            public String 강제배출 => Localization.GetString(Items.강제배출);
            public String 초기화 => Localization.GetString(Items.초기화);
            public String 트리거보드초기화 => Localization.GetString(Items.트리거보드초기화);
            public String 표면검사이미지저장사용 => Localization.GetString(Items.표면검사이미지저장사용);
            public String 설정저장 => Localization.GetString(Items.설정저장);
            public String 저장완료 => Localization.GetString(Items.저장완료);
            public String 저장확인 => Localization.GetString(Items.저장확인);
            public String 기타설정 => Localization.GetString(Items.기타설정);
            public String 기본설정 => Localization.GetString(Items.기본설정);
        }
    }
}
