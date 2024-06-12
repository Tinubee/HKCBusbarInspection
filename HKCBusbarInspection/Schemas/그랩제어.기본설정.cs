using MvCamCtrl.NET;
using MvCamCtrl.NET.CameraParams;
using MvFGCtrlC.NET;
using Newtonsoft.Json;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace HKCBusbarInspection.Schemas
{
    public enum AcquisitionMode
    {
        SingleFrame = 0,
        Continuous = 2,
    }

    public enum TriggerMode
    {
        TRIGGER_MODE_OFF = 0,
        TRIGGER_MODE_ON = 1,
    }

    public enum TriggerSource
    {
        Line0 = 0,
        Line1 = 1,
        Line2 = 2,
        Line3 = 3,
        Counter = 4,
        Software = 7,
    }

    public class 그랩장치 : IDisposable
    {
        [JsonProperty("Camera"), Translation("Camera", "카메라")]
        public virtual 카메라구분 구분 { get; set; } = 카메라구분.None;
        [JsonIgnore, Translation("Index", "번호")]
        public virtual Int32 번호 { get; set; } = 0;
        [JsonProperty("Serial"), Translation("Serial", "Serial")]
        public virtual String 코드 { get; set; } = String.Empty;
        [JsonIgnore, Translation("Name", "명칭")]
        public virtual String 명칭 { get; set; } = String.Empty;
        [JsonProperty("Description"), Translation("Description", "설명")]
        public virtual String 설명 { get; set; } = String.Empty;
        [JsonProperty("IpAddress"), Translation("IP", "IP")]
        public virtual String 주소 { get; set; } = String.Empty;
        [JsonProperty("Width"), Description("Width"), Translation("Width", "가로")]
        public virtual Int32 가로 { get; set; } = 0;
        [JsonProperty("Height"), Description("Height"), Translation("Height", "세로")]
        public virtual Int32 세로 { get; set; } = 0;
        [JsonProperty("CalibX"), Description("CalibX(µm)"), Translation("CalibX(µm)", "CalibX(µm)")]
        public virtual Double 교정X { get; set; } = 0;
        [JsonProperty("CalibY"), Description("CalibY(µm)"), Translation("CalibY(µm)", "CalibY(µm)")]
        public virtual Double 교정Y { get; set; } = 0;
        [JsonIgnore, Description("카메라 초기화 상태"), Translation("Live", "상태")]
        public virtual Boolean 상태 { get; set; } = false;
        [JsonIgnore]
        internal virtual MatType ImageType => MatType.CV_8UC1;
        [JsonIgnore]
        internal virtual Boolean UseMemoryCopy => false;
        [JsonIgnore]
        internal Int32 ImageWidth = 0;
        [JsonIgnore]
        internal Int32 ImageHeight = 0;
        [JsonIgnore]
        internal Object BufferLock = new Object();
        [JsonIgnore]
        internal UInt32 BufferSize = 0;
        [JsonIgnore]
        internal IntPtr BufferAddress = IntPtr.Zero;
        [JsonIgnore]
        internal Queue<Mat> Images = new Queue<Mat>();
        [JsonIgnore]
        internal Mat Image => Images.LastOrDefault<Mat>();
        [JsonIgnore]
        public List<Mat> MatImageList = new List<Mat>();
        [JsonIgnore]
        public Boolean 라이브 { get; set; } = false;
        [JsonIgnore]
        public Boolean 검사중 { get; set; } = false;
        [JsonIgnore]
        public const String 로그영역 = "Camera";

        public void Dispose()
        {
            while (this.Images.Count > 3)
                this.Dispose(this.Images.Dequeue());
        }
        internal void Dispose(Mat image)
        {
            if (image == null || image.IsDisposed) return;
            image.Dispose();
        }

        public virtual void Set(그랩장치 장치)
        {
            if (장치 == null) return;
            this.코드 = 장치.코드;
            this.설명 = 장치.설명;
            this.교정X = 장치.교정X;
            this.교정Y = 장치.교정Y;
        }
        public virtual Boolean Init() => false;
        public virtual Boolean Active() => false;
        public virtual Boolean Stop() => false;
        public virtual Boolean Close()
        {
            while (this.Images.Count > 0)
                this.Dispose(this.Images.Dequeue());
            return true;
        }
        public virtual void TurnOn() => Global.조명제어.TurnOn(this.구분);
        public virtual void TurnOff() => Global.조명제어.TurnOff(this.구분);

        public virtual Boolean StartLive() => false;

        public virtual Boolean StopLive() => false;

        public virtual Boolean SoftwareTrigger() => false;

        public virtual void ClearImageBuffer() => this.ClearImageBuffer();

        #region 이미지그랩
        internal void InitBuffers(Int32 width, Int32 height)
        {
            if (width == 0 || height == 0) return;
            Int32 channels = ImageType == MatType.CV_8UC3 ? 3 : 1;
            Int32 imageSize = width * height * channels;
            if (BufferAddress != IntPtr.Zero && imageSize == BufferSize) return;
            this.ImageWidth = width; this.ImageHeight = height;
            if (BufferAddress != IntPtr.Zero)
            {
                Marshal.Release(BufferAddress);
                BufferAddress = IntPtr.Zero;
                BufferSize = 0;
            }

            BufferAddress = Marshal.AllocHGlobal(imageSize);
            if (BufferAddress == IntPtr.Zero) return;
            BufferSize = (UInt32)imageSize;
            Debug.WriteLine(this.구분.ToString(), "InitBuffers");
        }

        internal void CopyMemory(IntPtr surfaceAddr, Int32 width, Int32 height)
        {
            // 메모리 복사
            lock (this.BufferLock)
            {
                try
                {
                    this.InitBuffers(width, height);
                    Common.CopyMemory(BufferAddress, surfaceAddr, BufferSize);
                }
                catch (Exception e)
                {
                    Global.오류로그(로그영역, "Acquisition", $"[{this.구분.ToString()}] {e.Message}", true);
                }
            }
        }

        internal void AcquisitionFinished(IntPtr surfaceAddr, Int32 width, Int32 height)
        {
            if (surfaceAddr == IntPtr.Zero) { AcquisitionFinished("Failed."); return; }
            try
            {
                if (this.UseMemoryCopy) this.CopyMemory(surfaceAddr, width, height);
                else
                {
                    this.BufferAddress = surfaceAddr;
                    this.ImageWidth = width;
                    this.ImageHeight = height;
                }

                Global.그랩제어.그랩완료(this);
            }
            catch (Exception ex)
            {
                Global.오류로그(로그영역, "Acquisition", $"[{this.구분}] {ex.Message}", true);
            }
        }

        internal void AcquisitionFinished(String error) =>
            Global.오류로그(로그영역, "Acquisition", $"[{this.구분.ToString()}] {error}", true);
        internal void AcquisitionFinished(Mat image)
        {
            if (image == null)
            {
                AcquisitionFinished("Failed.");
                return;
            }
            this.Images.Enqueue(image);
            this.Dispose();
            //Global.그랩제어.그랩완료(this);
        }

        public Mat MatImage()
        {
            if (this.Image != null) return this.Image;
            if (BufferAddress == IntPtr.Zero) return null;

            if (this.구분 == 카메라구분.Cam01)
            {
                Mat Image = new Mat(ImageHeight, ImageWidth, ImageType, BufferAddress);
                Mat rotateImage = new Mat();

                Cv2.Transpose(Image, rotateImage);
                Cv2.Flip(rotateImage, rotateImage, FlipMode.Y);

                return rotateImage;
            }

            return new Mat(ImageHeight, ImageWidth, ImageType, BufferAddress);
        }
        #endregion
    }
    public class HikeGigE : 그랩장치
    {
        internal override Boolean UseMemoryCopy => true;
        [JsonIgnore]
        private CCamera Camera = null;
        [JsonIgnore]
        private CCameraInfo Device;
        [JsonIgnore]
        private cbOutputExdelegate ImageCallBackDelegate;
        [JsonIgnore]
        public Int32 OffsetX { get; set; } = 0;
        [JsonIgnore]
        public Boolean ReverseX { get; set; } = false;
        [JsonIgnore]
        public Int32 number { get; set; } = 0;
        [JsonIgnore]
        public uint ImageCount = 3;
        [JsonIgnore, Description("Trig Mode")]
        public TriggerMode TrigMode { get; set; } = TriggerMode.TRIGGER_MODE_ON;
        [JsonIgnore, Description("Trig Source")]
        public TriggerSource TrigSource { get; set; } = TriggerSource.Software;
        public Boolean Init(CGigECameraInfo info)
        {
            try
            {
                this.Camera = new CCamera();
                this.Device = info;
                this.ImageCallBackDelegate = new cbOutputExdelegate(ImageCallBack);

                this.명칭 = info.chManufacturerName + " " + info.chModelName;
                UInt32 ip1 = (info.nCurrentIp & 0xff000000) >> 24;
                UInt32 ip2 = (info.nCurrentIp & 0x00ff0000) >> 16;
                UInt32 ip3 = (info.nCurrentIp & 0x0000ff00) >> 8;
                UInt32 ip4 = info.nCurrentIp & 0x000000ff;
                this.주소 = $"{ip1}.{ip2}.{ip3}.{ip4}";
                this.번호 = (int)this.구분;
                this.상태 = this.Init();
                this.Active();
            }
            catch (Exception ex)
            {
                Global.오류로그(로그영역, "초기화", $"초기화 오류: {ex.Message}", true);
                this.상태 = false;
            }

            Debug.WriteLine($"{this.명칭}, {this.코드}, {this.주소}, {this.상태}");
            return this.상태;
        }

        public override Boolean StartLive()
        {
            this.라이브 = true;
            return 그랩제어.Validate($"{this.구분} Active", Camera.StartGrabbing(), false);
        }

        public override Boolean StopLive()
        {
            this.라이브 = false;
            return 그랩제어.Validate($"{this.구분} Active", Camera.StopGrabbing(), false);
        }

        public override Boolean SoftwareTrigger() => 그랩제어.Validate($"{this.구분} TriggerSoftware", this.Camera.SetCommandValue("TriggerSoftware"), true);

        public override Boolean Init()
        {
            Int32 nRet = this.Camera.CreateHandle(ref Device);
            if (!그랩제어.Validate($"[{this.구분}] 카메라 초기화에 실패하였습니다.", nRet, true)) return false;

            nRet = this.Camera.OpenDevice();
            if (!그랩제어.Validate($"[{this.구분}] 카메라 연결 실패!", nRet, true)) return false;

            그랩제어.Validate("RegisterImageCallBackEx", this.Camera.RegisterImageCallBackEx(this.ImageCallBackDelegate, IntPtr.Zero), false);
            this.Camera.SetImageNodeNum(ImageCount);
            this.옵션적용();
            Global.정보로그(로그영역, "카메라 연결", $"[{this.구분}] 카메라 연결 성공!", false);
            return true;
        }
        private void 옵션적용()
        {
            this.트리거모드적용();
            this.트리거소스적용();
        }
        public void 트리거모드적용()
        {
            if (this.Camera == null) return;
            Int32 nRet = this.Camera.SetEnumValue("TriggerMode", (uint)this.TrigMode);
            그랩제어.Validate($"[{this.구분}] 트리거모드 설정에 실패하였습니다.", nRet, true);
        }

        public void 트리거소스적용()
        {
            if (this.Camera == null) return;

            //하부카메라 트리거보드 오류 수정 전으로 임시로 제거.
            if (this.구분 == 카메라구분.Cam04)
                this.TrigSource = TriggerSource.Line0;

            Int32 nRet = this.Camera.SetEnumValue("TriggerSource", (uint)this.TrigSource);
            그랩제어.Validate($"[{this.구분}] 트리거소스 설정에 실패하였습니다.", nRet, true);
        }
        public override Boolean Active()
        {
            this.Camera.ClearImageBuffer();
            return 그랩제어.Validate($"{this.구분} Active", Camera.StartGrabbing(), true);
        }

        public override Boolean Close()
        {
            base.Close();
            if (this.Camera == null || !this.상태) return true;
            return 그랩제어.Validate($"{this.구분} Close", Camera.CloseDevice(), false);
        }

        public override Boolean Stop()
        {
            Camera.ClearImageBuffer();
            return 그랩제어.Validate($"{this.구분} Stop", Camera.StopGrabbing(), false);
        }

        public override void ClearImageBuffer() => this.Camera.ClearImageBuffer();

        private void ImageCallBack(IntPtr surfaceAddr, ref MV_FRAME_OUT_INFO_EX frameInfo, IntPtr user)
        {
            Common.DebugWriteLine("ImageCallBack", 로그구분.정보, $"{this.구분} ImageCallBack 완료.");
            this.AcquisitionFinished(surfaceAddr, frameInfo.nWidth, frameInfo.nHeight);
            //this.Stop();
        }
    }

    public class HikeCxp : 그랩장치
    {
        internal override Boolean UseMemoryCopy => true;
        [JsonIgnore]
        private CInterface Interface = null;
        [JsonIgnore]
        private CDevice Device = null;
        [JsonIgnore]
        private CParam DeviceParam = null;
        [JsonIgnore]
        private CStream Stream = null;
        [JsonIgnore]
        private CStream.ImageDelegate ImageCallBackDelegate;
        [JsonIgnore]
        public Int32 OffsetX { get; set; } = 0;
        [JsonIgnore]
        public Boolean ReverseX { get; set; } = false;
        [JsonIgnore]
        public Int32 number { get; set; } = 0;
        [JsonIgnore]
        public const Int32 BufNum = 10;
        [JsonIgnore, Description("Trig Mode")]
        public TriggerMode TrigMode { get; set; } = TriggerMode.TRIGGER_MODE_ON;
        [JsonIgnore, Description("Trig Source")]
        public TriggerSource TrigSource { get; set; } = TriggerSource.Software;

        public Boolean Init(CInterface cInterface, MV_CXP_DEVICE_INFO info)
        {
            try
            {

                this.Interface = cInterface;
                int nRet = this.Interface.OpenDevice(Convert.ToUInt32(0), out this.Device);

                if (!그랩제어.ValidateMVFG($"[{this.구분}] 카메라 연결 실패!", nRet, true)) return false;

                this.DeviceParam = new CParam(this.Device);

                nRet = this.Device.OpenStream(0, out Stream);
                if (!그랩제어.ValidateMVFG($"[{this.구분}] OpenStream Fail!", nRet, true)) return false;

                this.ImageCallBackDelegate = new CStream.ImageDelegate(ImageCallBack);
                this.명칭 = info.chModelName;
                this.번호 = (int)this.구분;
                this.상태 = this.Init();
                this.Active();
            }
            catch (Exception ex)
            {
                Global.오류로그(로그영역, "초기화", $"초기화 오류: {ex.Message}", true);
                this.상태 = false;
            }

            Debug.WriteLine($"{this.명칭}, {this.코드}, {this.주소}, {this.상태}");
            return this.상태;
        }

        public override Boolean Init()
        {
            this.Stream.SetBufferNum(BufNum);
            그랩제어.ValidateMVFG("RegisterImageCallBack", this.Stream.RegisterImageCallBack(this.ImageCallBackDelegate, IntPtr.Zero), false);
            옵션적용();
            Global.정보로그(로그영역, "카메라 연결", $"[{this.구분}] 카메라 연결 성공!", false);
            return true;
        }
        private void 옵션적용()
        {
            //this.DeviceParam.SetEnumValue("AcquisitionMode", (UInt32)AcquisitionMode.Continuous);
            this.트리거모드적용();
            this.트리거소스적용();
        }
        public void 트리거모드적용()
        {
            if (this.DeviceParam == null) return;
            Int32 nRet = this.DeviceParam.SetEnumValue("TriggerMode", (uint)this.TrigMode);
            그랩제어.Validate($"[{this.구분}] 트리거모드 설정에 실패하였습니다.", nRet, true);
        }

        public void 트리거소스적용()
        {
            if (this.DeviceParam == null) return;

            Int32 nRet = this.DeviceParam.SetEnumValue("TriggerSource", (uint)this.TrigSource);
            그랩제어.Validate($"[{this.구분}] 트리거소스 설정에 실패하였습니다.", nRet, true);
        }
        public override Boolean StartLive()
        {
            //this.DeviceParam.SetEnumValue("AcquisitionMode", (UInt32)AcquisitionMode.Continuous);
            //this.DeviceParam.SetEnumValue("TriggerMode", (UInt32)TriggerMode.TRIGGER_MODE_OFF);
            //this.라이브 = true;
            return 그랩제어.ValidateMVFG($"{this.구분} Active", this.Stream.StartAcquisition(), false);
        }

        public override Boolean StopLive()
        {
            //this.DeviceParam.SetEnumValue("AcquisitionMode", (UInt32)AcquisitionMode.SingleFrame);
            //this.DeviceParam.SetEnumValue("TriggerMode", (UInt32)TriggerMode.TRIGGER_MODE_ON);
            //this.DeviceParam.SetEnumValue("TriggerSource", (UInt32)TriggerSource.Software);
            this.라이브 = false;
            return 그랩제어.ValidateMVFG($"{this.구분} Close", this.Stream.StopAcquisition(), false);
        }

        public override void ClearImageBuffer()
        {

        }

        public override Boolean SoftwareTrigger()
        {
            //this.Active();
            return 그랩제어.ValidateMVFG($"{this.구분} Trigger software", this.DeviceParam.SetCommandValue("TriggerSoftware"), false);
        }

        public override Boolean Active()
        {
            return 그랩제어.ValidateMVFG($"{this.구분} Active", this.Stream.StartAcquisition(), true);
        }

        public override Boolean Close()
        {
            base.Close();
            그랩제어.ValidateMVFG($"{this.구분} Close Stream", this.Stream.CloseStream(), false);
            그랩제어.ValidateMVFG($"{this.구분} Close Device", this.Device.CloseDevice(), false);
            return 그랩제어.ValidateMVFG($"{this.구분} Close Interface", this.Interface.CloseInterface(), false);
        }

        public override Boolean Stop()
        {
            return 그랩제어.ValidateMVFG($"{this.구분} Close", this.Stream.StopAcquisition(), false);
        }

        private void ImageCallBack(ref MV_FG_BUFFER_INFO stBufferInfo, IntPtr pUser)
        {
            if (null != stBufferInfo.pBuffer)
            {
                Common.DebugWriteLine("ImageCallBack", 로그구분.정보, $"{this.구분} ImageCallBack 완료.");
                this.AcquisitionFinished(stBufferInfo.pBuffer, (Int32)stBufferInfo.nWidth, (Int32)stBufferInfo.nHeight);
                //this.Stop();
            }
        }
    }
}
