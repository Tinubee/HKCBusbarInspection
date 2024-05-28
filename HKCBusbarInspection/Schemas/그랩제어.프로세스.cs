using MvCamCtrl.NET;
using MvUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OpenCvSharp;
using MvFGCtrlC.NET;
using OpenCvSharp.Dnn;

namespace HKCBusbarInspection.Schemas
{
    public class 그랩제어 : Dictionary<카메라구분, 그랩장치>
    {
        public static List<카메라구분> 대상카메라 = new List<카메라구분>() { 카메라구분.Cam01, 카메라구분.Cam02, 카메라구분.Cam03, 카메라구분.Cam04 };

        public delegate void 그랩완료대리자(그랩장치 장치);
        public event 그랩완료대리자 그랩완료보고;

        [JsonIgnore]
        public HikeGigE 상부검사카메라 = null;
        [JsonIgnore]
        public HikeGigE 측면검사카메라 = null;
        [JsonIgnore]
        public HikeGigE L부검사카메라 = null;
        [JsonIgnore]
        public HikeGigE 하부검사카메라 = null;
        [JsonIgnore]
        public HikeGigE 트레이검사카메라 = null;

        [JsonIgnore]
        private const string 로그영역 = "Camera";
        [JsonIgnore]
        private string 저장파일 => Path.Combine(Global.환경설정.기본경로, "Cameras.json");
        [JsonIgnore]
        public Boolean 정상여부 => !this.Values.Any(e => !e.상태);

        public Boolean Init()
        {
            this.상부검사카메라 = new HikeGigE() { 구분 = 카메라구분.Cam01, 코드 = "DA3152184" };
            this.측면검사카메라 = new HikeGigE() { 구분 = 카메라구분.Cam02, 코드 = "" };
            this.L부검사카메라 = new HikeGigE() { 구분 = 카메라구분.Cam03, 코드 = "" };
            this.하부검사카메라 = new HikeGigE() { 구분 = 카메라구분.Cam04, 코드 = "" };
            this.트레이검사카메라 = new HikeGigE() { 구분 = 카메라구분.Cam05, 코드 = "" };

            this.Add(카메라구분.Cam01, this.상부검사카메라);
            this.Add(카메라구분.Cam02, this.측면검사카메라);
            this.Add(카메라구분.Cam03, this.L부검사카메라);
            this.Add(카메라구분.Cam04, this.하부검사카메라);
            this.Add(카메라구분.Cam04, this.트레이검사카메라);

            // 카메라 설정 저장정보 로드
            그랩장치 정보;
            List<그랩장치> 자료 = Load();
            if (자료 != null)
            {
                foreach (그랩장치 설정 in 자료)
                {
                    정보 = this.GetItem(설정.구분);
                    if (정보 == null) continue;
                    정보.Set(설정);
                }
            }
            if (Global.환경설정.동작구분 != 동작구분.Live) return true;
            //Test();
            // GigE 카메라 초기화
            List<CCameraInfo> 카메라들 = new List<CCameraInfo>();

            Int32 nRet = MvCamCtrl.NET.CSystem.EnumDevices(MvCamCtrl.NET.CSystem.MV_GIGE_DEVICE, ref 카메라들);// | CSystem.MV_USB_DEVICE

            if (!Validate("Enumerate devices fail!", nRet, true)) return false;

            for (int i = 0; i < 카메라들.Count; i++)
            {
                CGigECameraInfo gigeInfo = 카메라들[i] as CGigECameraInfo;
                HikeGigE gige = this.GetItem(gigeInfo.chSerialNumber) as HikeGigE;
                if (gige == null) continue;
                //Debug.WriteLine(gigeInfo.chSerialNumber, "시리얼");
                gige.Init(gigeInfo);
                //if (gige.상태) gige.Start();
            }

            Debug.WriteLine($"카메라 갯수: {this.Count}");
            GC.Collect();
            return true;
        }

        public void Test()
        {
            CInterface m_cInterface = null;
            CDevice m_cDevice = null;

            int nRet = 0;
            bool bChanged = false;
            MvFGCtrlC.NET.CSystem m_cSystem = new MvFGCtrlC.NET.CSystem();


            nRet = m_cSystem.UpdateInterfaceList(
               CParamDefine.MV_FG_CAMERALINK_INTERFACE | CParamDefine.MV_FG_GEV_INTERFACE | CParamDefine.MV_FG_CXP_INTERFACE,
               ref bChanged);

            uint m_nInterfaceNum = 0;

            nRet = m_cSystem.GetNumInterfaces(ref m_nInterfaceNum);

            MV_FG_INTERFACE_INFO stIfInfo = new MV_FG_INTERFACE_INFO();
            for (uint i = 0; i < m_nInterfaceNum; i++)
            {
                nRet = m_cSystem.GetInterfaceInfo(i, ref stIfInfo);
                string strShowIfInfo = null;
                switch (stIfInfo.nTLayerType)
                {
                    case CParamDefine.MV_FG_GEV_INTERFACE:
                        {
                            MV_GEV_INTERFACE_INFO stGevIFInfo = (MV_GEV_INTERFACE_INFO)CAdditional.ByteToStruct(
                                stIfInfo.SpecialInfo.stGevIfInfo, typeof(MV_GEV_INTERFACE_INFO));
                            strShowIfInfo += "GEV[" + i.ToString() + "]: " + stGevIFInfo.chDisplayName + " | " +
                                stGevIFInfo.chInterfaceID + " | " + stGevIFInfo.chSerialNumber;
                            break;
                        }
                    case CParamDefine.MV_FG_CXP_INTERFACE:
                        {
                            MV_CXP_INTERFACE_INFO stCxpIFInfo = (MV_CXP_INTERFACE_INFO)CAdditional.ByteToStruct(
                                stIfInfo.SpecialInfo.stCXPIfInfo, typeof(MV_CXP_INTERFACE_INFO));
                            strShowIfInfo += "CXP[" + i.ToString() + "]: " + stCxpIFInfo.chDisplayName + " | " +
                                stCxpIFInfo.chInterfaceID + " | " + stCxpIFInfo.chSerialNumber;
                            break;
                        }
                    case CParamDefine.MV_FG_CAMERALINK_INTERFACE:
                        {
                            MV_CML_INTERFACE_INFO stCmlIFInfo = (MV_CML_INTERFACE_INFO)CAdditional.ByteToStruct(
                                stIfInfo.SpecialInfo.stCMLIfInfo, typeof(MV_CML_INTERFACE_INFO));
                            strShowIfInfo += "CML[" + i.ToString() + "]: " + stCmlIFInfo.chDisplayName + " | " +
                                stCmlIFInfo.chInterfaceID + " | " + stCmlIFInfo.chSerialNumber;
                            break;
                        }
                    default:
                        {
                            strShowIfInfo += "Unknown interface[" + i.ToString() + "]";
                            break;
                        }
                }

                Debug.WriteLine(strShowIfInfo);
             
            }
            int nRet2 = m_cSystem.OpenInterface(Convert.ToUInt32(1), out m_cInterface);

            uint nDeviceNum = 0;
            nRet2 = m_cInterface.GetNumDevices(ref nDeviceNum);
        }

        private List<그랩장치> Load()
        {
            if (!File.Exists(this.저장파일)) return null;
            return JsonConvert.DeserializeObject<List<그랩장치>>(File.ReadAllText(this.저장파일), Utils.JsonSetting());
        }

        public void Save()
        {
            if (!Utils.WriteAllText(저장파일, JsonConvert.SerializeObject(this.Values, Utils.JsonSetting())))
                Global.오류로그(로그영역, "카메라 설정 저장", "카메라 설정 저장에 실패하였습니다.", true);
        }

        public void Close()
        {
            if (Global.환경설정.동작구분 != 동작구분.Live) return;
            foreach (그랩장치 장치 in this.Values)
                장치?.Close();
        }
        public void Active(카메라구분 구분) => this.GetItem(구분)?.Active();

        public 그랩장치 GetItem(카메라구분 구분)
        {
            if (this.ContainsKey(구분)) return this[구분];
            return null;
        }
        private 그랩장치 GetItem(String serial) => this.Values.Where(e => e.코드 == serial).FirstOrDefault();

        public void 그랩완료(그랩장치 장치)
        {
            //장치.TurnOff();
            //if (Global.장치상태.자동수동)
            //{
            //    Int32 검사번호 = Global.장치통신.촬영위치번호(장치.구분);
            //    검사결과 검사 = Global.검사자료.검사항목찾기(검사번호);
            //    if (검사 == null) return;
            //    Global.비전검사.Run(장치, 검사);
            //    if (장치.구분 == 카메라구분.Cam01)
            //    {
            //        Mat 표면검사용이미지 = Common.ResizeImage(장치.MatImage(), 장치.ResizeScale);
            //        if (Global.환경설정.표면검사사용)
            //        {
            //            Debug.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")} : 표면 검사시작");
            //            Task.Run(() => { Global.VM제어.GetItem(Flow구분.표면검사).Run(표면검사용이미지, null, 검사번호); });
            //        }

            //        if (Global.환경설정.표면검사이미지저장) Global.사진자료.SaveImage(표면검사용이미지, 검사번호);
            //    }
            //}
            //else
            //{
            //    Global.비전검사.Run(장치.구분, 장치.CogImage(), Global.검사자료.수동검사);
            //    this.그랩완료보고?.Invoke(장치);
            //}
        }

        #region 오류메세지
        public static Boolean Validate(String message, Int32 errorNum, Boolean show)
        {
            if (errorNum == CErrorDefine.MV_OK) return true;

            String errorMsg = String.Empty;
            switch (errorNum)
            {
                case CErrorDefine.MV_E_HANDLE: errorMsg = "Error or invalid handle"; break;
                case CErrorDefine.MV_E_SUPPORT: errorMsg = "Not supported function"; break;
                case CErrorDefine.MV_E_BUFOVER: errorMsg = "Cache is full"; break;
                case CErrorDefine.MV_E_CALLORDER: errorMsg = "Function calling order error"; break;
                case CErrorDefine.MV_E_PARAMETER: errorMsg = "Incorrect parameter"; break;
                case CErrorDefine.MV_E_RESOURCE: errorMsg = "Applying resource failed"; break;
                case CErrorDefine.MV_E_NODATA: errorMsg = "No data"; break;
                case CErrorDefine.MV_E_PRECONDITION: errorMsg = "Precondition error, or running environment changed"; break;
                case CErrorDefine.MV_E_VERSION: errorMsg = "Version mismatches"; break;
                case CErrorDefine.MV_E_NOENOUGH_BUF: errorMsg = "Insufficient memory"; break;
                case CErrorDefine.MV_E_UNKNOW: errorMsg = "Unknown error"; break;
                case CErrorDefine.MV_E_GC_GENERIC: errorMsg = "General error"; break;
                case CErrorDefine.MV_E_GC_ACCESS: errorMsg = "Node accessing condition error"; break;
                case CErrorDefine.MV_E_ACCESS_DENIED: errorMsg = "No permission"; break;
                case CErrorDefine.MV_E_BUSY: errorMsg = "Device is busy, or network disconnected"; break;
                case CErrorDefine.MV_E_NETER: errorMsg = "Network error"; break;
                default: errorMsg = "Unknown error"; break;
            }

            Global.오류로그("Camera", "Error", $"[{errorNum}] {message} {errorMsg}", show);
            return false;
        }
        #endregion
    }
}