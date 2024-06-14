using DevExpress.XtraEditors;
using HKCBusbarInspection.Schemas;
using MvUtils;
using System;

namespace HKCBusbarInspection.UI.Control
{
    public partial class DeviceSettings : XtraUserControl
    {
        private LocalizationDeviceSetting 번역 = new LocalizationDeviceSetting();
        public DeviceSettings() => InitializeComponent();

        private void 원점복귀알림()
        {
            Global.그랩제어.GetItem(카메라구분.Cam01).MatImageList.Clear();
            Global.그랩제어.GetItem(카메라구분.Cam02).MatImageList.Clear();
            Global.그랩제어.GetItem(카메라구분.Cam03).MatImageList.Clear();
            Global.그랩제어.GetItem(카메라구분.Cam04).MatImageList.Clear();
            Global.그랩제어.GetItem(카메라구분.Cam05).MatImageList.Clear();

            Global.그랩제어.GetItem(카메라구분.Cam01).SurFaceMatImageList.Clear();
            Global.그랩제어.GetItem(카메라구분.Cam02).SurFaceMatImageList.Clear();
            Global.그랩제어.GetItem(카메라구분.Cam03).SurFaceMatImageList.Clear();
            Global.그랩제어.GetItem(카메라구분.Cam04).SurFaceMatImageList.Clear();
            Global.그랩제어.GetItem(카메라구분.Cam05).SurFaceMatImageList.Clear();

            Global.조명제어.TurnOff();

            Global.신호제어.원점복귀완료 = false;
            Common.DebugWriteLine("원점복귀", 로그구분.정보, "원점복귀완료");
            Global.정보로그("원점복귀", "원점복귀완료", "원점복귀완료", true);
        }
        private void 인덱스리셋(object sender, EventArgs e)
        {
            if (!Utils.Confirm(this.FindForm(), this.번역.인덱스초기화확인, Localization.확인.GetString())) return;

            Global.신호제어.인덱스전체초기화 = true;
        }

        public void Init()
        {
            this.e강제배출.IsOn = Global.환경설정.강제배출;
            this.e배출구분.IsOn = Global.환경설정.양품불량;
            this.e배출구분랜덤.IsOn = Global.환경설정.랜덤배출;

            this.e강제배출.EditValueChanged += 강제배출Changed;
            this.e배출구분.EditValueChanged += 배출구분Changed;
            this.e배출구분랜덤.EditValueChanged += 배출구분랜덤Changed;
            this.e표면검사이미지저장.EditValueChanged += 표면검사이미지저장Changed;

            this.SetLocalization();
            this.BindLocalization.DataSource = this.번역;
            this.환경설정Bind.DataSource = Global.환경설정;

            this.b설정저장.Click += 환경설정저장;
            this.b인덱스리셋.Click += 인덱스리셋;

            Global.신호제어.원점복귀알림 += 원점복귀알림;

            this.e카메라.Init();
            this.e기본설정.Init();
            this.e입출신호.Init();
        }

        private void 표면검사이미지저장Changed(object sender, EventArgs e) => Global.환경설정.사진저장표면 = this.e표면검사이미지저장.IsOn;

        private void 배출구분랜덤Changed(object sender, EventArgs e) => Global.환경설정.랜덤배출 = this.e배출구분랜덤.IsOn;
        private void 강제배출Changed(object sender, EventArgs e) => Global.환경설정.강제배출 = this.e강제배출.IsOn;
        private void 배출구분Changed(object sender, EventArgs e) => Global.환경설정.양품불량 = this.e배출구분.IsOn;

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
            this.g인덱스초기화.Text = this.번역.인덱스초기화;
            this.b캠트리거리셋.Text = this.번역.초기화;
            this.b인덱스리셋.Text = this.번역.초기화;
            this.b표면검사이미지저장.Text = this.번역.표면검사이미지저장사용;
            this.t기타설정.Text = this.번역.기타설정;
            this.t환경설정.Text = this.번역.기본설정;
            this.g기타.Text = this.번역.기타장치;
            this.c강제배출사용유무.Text = this.번역.강제배출온오프;
            this.c양품불량.Text = this.번역.양품불량설정;
            this.c양품불량랜덤.Text = this.번역.랜덤결과온오프;
            this.e강제배출.Properties.OnText = this.번역.강제배출온;
            this.e강제배출.Properties.OffText = this.번역.강제배출오프;
            this.e배출구분.Properties.OnText = this.번역.양품설정;
            this.e배출구분.Properties.OffText = this.번역.불량설정;
            this.t입출신호.Text = this.번역.주소목록;
        }

        private class LocalizationDeviceSetting
        {
            private enum Items
            {
                [Translation("Forced Ejection", "강제배출")]
                강제배출,
                [Translation("TriggerBoard Position Reset ", "트리거보드 초기화")]
                트리거보드초기화,
                [Translation("Index Reset ", "인덱스 초기화")]
                인덱스초기화,
                [Translation("Etc Device ", "기타장치")]
                기타장치,
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
                [Translation("Do you want to initialize the index?", "인덱스를 초기화 하시겠습니까?")]
                인덱스초기화확인,

                [Translation("Force Result", "강제배출")]
                강제배출온오프,
                [Translation("On", "사용")]
                강제배출온,
                [Translation("Off", "미사용")]
                강제배출오프,
                [Translation("Enforce Result", "적용결과")]
                양품불량설정,
                [Translation("Random Result", "랜덤 검사결과")]
                랜덤결과온오프,
                [Translation("OK", "양품")]
                양품설정,
                [Translation("NG", "불량")]
                불량설정,
                [Translation("Address", "주소목록")]
                주소목록,
                [Translation("Host", "주소")]
                잉크젯주소,
                [Translation("Port", "포트")]
                잉크젯포트,
            }
            public String 강제배출온오프 => Localization.GetString(Items.강제배출온오프);
            public String 강제배출온 => Localization.GetString(Items.강제배출온);
            public String 강제배출오프 => Localization.GetString(Items.강제배출오프);
            public String 양품불량설정 => Localization.GetString(Items.양품불량설정);
            public String 양품설정 => Localization.GetString(Items.양품설정);
            public String 불량설정 => Localization.GetString(Items.불량설정);
            public String 랜덤결과온오프 => Localization.GetString(Items.랜덤결과온오프);
            public String 강제배출 => Localization.GetString(Items.강제배출);
            public String 초기화 => Localization.GetString(Items.초기화);
            public String 트리거보드초기화 => Localization.GetString(Items.트리거보드초기화);
            public String 인덱스초기화 => Localization.GetString(Items.인덱스초기화);
            public String 인덱스초기화확인 => Localization.GetString(Items.인덱스초기화확인);
            public String 기타장치 => Localization.GetString(Items.기타장치);
            public String 표면검사이미지저장사용 => Localization.GetString(Items.표면검사이미지저장사용);
            public String 설정저장 => Localization.GetString(Items.설정저장);
            public String 저장완료 => Localization.GetString(Items.저장완료);
            public String 저장확인 => Localization.GetString(Items.저장확인);
            public String 기타설정 => Localization.GetString(Items.기타설정);
            public String 기본설정 => Localization.GetString(Items.기본설정);
            public String 주소목록 => Localization.GetString(Items.주소목록);
            public String 잉크젯주소 => Localization.GetString(Items.잉크젯주소);
            public String 잉크젯포트 => Localization.GetString(Items.잉크젯포트);
        }
    }
}
