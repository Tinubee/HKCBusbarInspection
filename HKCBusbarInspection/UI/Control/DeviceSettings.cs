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
            this.BindLocalization.DataSource = this.번역;
            this.환경설정Bind.DataSource = Global.환경설정;
        }

        public void Init()
        {
            this.e카메라.Init();
            this.e기본설정.Init();
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


        private class LocalizationDeviceSetting
        {
            private enum Items
            {
                [Translation("Save", "설정저장")]
                설정저장,
                [Translation("It's saved.", "저장되었습니다.")]
                저장완료,
                [Translation("Save your preferences?", "환경설정을 저장하시겠습니까?")]
                저장확인,
            }

            public String 설정저장 => Localization.GetString(Items.설정저장);
            public String 저장완료 => Localization.GetString(Items.저장완료);
            public String 저장확인 => Localization.GetString(Items.저장확인);
        }
    }
}
