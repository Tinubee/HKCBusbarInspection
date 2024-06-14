using HKCBusbarInspection.Schemas;
using MvUtils;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HKCBusbarInspection
{
    public enum 동작구분
    {
        Live = 0,
        LocalTest = 2
    }
    public class Global
    {
        public const String SkinName = "The Bezier";
        public const String BlackPalette = "Office Black";
        public const String ColorPalette = "Office Colorful";

        public static MainForm MainForm = null;
        public delegate void BaseEvent();
        public static event EventHandler<Boolean> Initialized;

        private const String 로그영역 = "프로그램";
        public static 환경설정 환경설정;
        public static 로그자료 로그자료;
        public static 조명제어 조명제어;
        public static 모델자료 모델자료;
        public static 그랩제어 그랩제어;
        public static 신호제어 신호제어;
        public static VM제어 VM제어;
        public static 검사자료 검사자료;
        public static 사진자료 사진자료;
        public static 유저자료 유저자료;
        public static 마킹기제어 마킹기제어;

        public static class 장치상태
        {
            //public static Boolean 정상여부 => 조명장치 && 그랩장치;
            public static Boolean 조명장치 => 조명제어.정상여부;
            public static Boolean 그랩장치 => Global.그랩제어.정상여부;
            public static Boolean 카메라1 => Global.그랩제어.상부검사카메라.상태;
            public static Boolean 카메라2 => Global.그랩제어.측면검사카메라.상태;
            public static Boolean 카메라3 => Global.그랩제어.L부검사카메라.상태;
            public static Boolean 카메라4 => Global.그랩제어.하부검사카메라.상태;
            public static Boolean 잉크젯 => Global.마킹기제어 == null ? false : Global.마킹기제어.마킹기.연결여부;
            public static Boolean 자동수동 => Global.신호제어.자동수동여부;
            public static Boolean 시작정지 => Global.신호제어.시작정지여부;
        }

        public static Boolean Init()
        {
            try
            {
                로그자료 = new 로그자료();
                환경설정 = new 환경설정();
                모델자료 = new 모델자료();
                조명제어 = new 조명제어();
                검사자료 = new 검사자료();
                VM제어 = new VM제어();
                그랩제어 = new 그랩제어();
                신호제어 = new 신호제어();
                사진자료 = new 사진자료();
                유저자료 = new 유저자료();
                //마킹기제어 = new 마킹기제어();

                로그자료.Init();
                환경설정.Init();
                유저자료.Init();
                모델자료.Init();
                사진자료.Init();
                VM제어.Init();
                검사자료.Init();
                //마킹기제어.Init();

                if (Global.환경설정.동작구분 == 동작구분.Live)
                {
                    신호제어.Init();
                    if (!그랩제어.Init()) new Exception("카메라 초기화에 실패하였습니다.");
                    if (!신호제어.Open()) new Exception("PLC 서버에 연결할 수 없습니다.");
                    조명제어.Init();
                }
               
                Global.정보로그(로그영역, "초기화", "시스템을 초기화 합니다.", false);
                Initialized?.Invoke(null, true);
                return true;
            }
            catch (Exception ex)
            {
                Utils.DebugException(ex, 3);
                Global.오류로그(로그영역, "초기화 오류", "시스템 초기화에 실패하였습니다.\n" + ex.Message, true);
            }
           
            Initialized?.Invoke(null, false);
            return false;
        }

        public static Boolean Close()
        {
            try
            {
                if (환경설정.동작구분 == 동작구분.Live)
                {
                    조명제어?.Close();
                    그랩제어?.Close();
                }

                마킹기제어?.Close();
                VM제어?.Close();
                유저자료.Close();
                신호제어?.Close();
                환경설정?.Close();
                사진자료?.Close();
                모델자료?.Close();
                검사자료?.Close();
                로그자료?.Close();

                Properties.Settings.Default.Save();
                return true;
            }
            catch(Exception ex)
            {
                return Utils.ErrorMsg("프로그램 종료 중 오류가 발생하였습니다.\n" + ex.Message);
            }
        }

        public static void Start()
        {
            신호제어?.Start();
            마킹기제어?.Start();
            if (Global.환경설정.동작구분 != 동작구분.Live) return;
        }


        public static void DxLocalization()
        {
            if (Localization.CurrentLanguage != Language.KO) return;
            MvUtils.Localization.CurrentLanguage = MvUtils.Localization.Language.KO;
            DxDataGridLocalizer.Enable();
            DxEditorsLocalizer.Enable();
            DxDataFilteringLocalizer.Enable();
            DxLayoutLocalizer.Enable();
            DxBarLocalizer.Enable();
        }

        public static String GetGuid()
        {
            Assembly assembly = typeof(Program).Assembly;
            GuidAttribute attribute = assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0] as GuidAttribute;
            return attribute.Value;
        }

        #region 로그 / Alert
        private static AlertControl 알림화면 = new AlertControl() { AutoHeight = false, FormSize = new System.Drawing.Size(400, 150) };// { PopupLocation = AlertControl.PopupLocations.CenterForm };
        private delegate void ShowMessageDelegate(Form Owner, 로그정보 로그);
        private static void ShowMessage(Form Owner, 로그정보 로그)
        {
            if (Owner == null || Owner.IsDisposed) return;
            if (Owner.InvokeRequired)
            {
                Owner.BeginInvoke(new ShowMessageDelegate(ShowMessage), new object[] { Owner, 로그 });
                return;
            }

            if (로그.구분 == 로그구분.오류)
                알림화면.Show(AlertControl.AlertTypes.Invalid, 로그.제목, 로그.내용, Owner);
            else if (로그.구분 == 로그구분.경고)
                알림화면.Show(AlertControl.AlertTypes.Warning, 로그.제목, 로그.내용, Owner);
            else if (로그.구분 == 로그구분.정보)
                알림화면.Show(AlertControl.AlertTypes.Information, 로그.제목, 로그.내용, Owner);
        }
        public static void ShowMessage(로그정보 로그) => ShowMessage(MainForm, 로그);

        public static 로그정보 로그기록(string 영역, 로그구분 구분, string 제목, string 내용)
        {
            try
            {
                로그정보 로그 = 로그자료.Add(영역, 구분, 제목, 내용);
                Debug.WriteLine($"{MvUtils.Utils.FormatDate(DateTime.Now, "{0:HH:mm:ss}")}\t{구분}\t{영역}\t{제목}\t{내용}");
                return 로그;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "로그기록 오류");
            }
            return null;
        }

        public static 로그정보 오류로그(string 영역, string 제목, string 내용, bool Show) =>
            오류로그(영역, 제목, 내용, Show ? MainForm : null);
        public static 로그정보 오류로그(string 영역, string 제목, string 내용, Form Owner)
        {
            로그정보 로그 = 로그기록(영역, 로그구분.오류, 제목, 내용);
            if (로그 != null && Owner != null) ShowMessage(Owner, 로그);
            return 로그;
        }

        public static 로그정보 경고로그(string 영역, string 제목, string 내용, bool Show) =>
            경고로그(영역, 제목, 내용, Show ? MainForm : null);
        public static 로그정보 경고로그(string 영역, string 제목, string 내용, Form Owner)
        {
            로그정보 로그 = 로그기록(영역, 로그구분.경고, 제목, 내용);
            if (로그 != null && Owner != null) ShowMessage(Owner, 로그);
            return 로그;
        }

        public static 로그정보 정보로그(string 영역, string 제목, string 내용, bool Show) =>
            정보로그(영역, 제목, 내용, Show ? MainForm : null);
        public static 로그정보 정보로그(string 영역, string 제목, string 내용, Form Owner)
        {
            로그정보 로그 = 로그기록(영역, 로그구분.정보, 제목, 내용);
            if (로그 != null && Owner != null) ShowMessage(Owner, 로그);
            return 로그;
        }
        #endregion
    }
}
