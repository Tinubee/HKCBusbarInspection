using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKCBusbarInspection.Schemas
{
    public class 마킹기제어
    {
        //public event Global.BaseEvent 통신상태알림;
        public String 로그영역 = "잉크젯마킹기";
        public 마킹기 마킹기;
        public Boolean Init()
        {
            try
            {
                this.마킹기 = new 마킹기();
                this.마킹기.Init();
                this.마킹기.자료수신 += 통신수신;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        private void 통신수신(object sender, String e)
        {
            try
            {
                Common.DebugWriteLine(로그영역, 로그구분.정보, $"수신내용 : {e}");

                if (e.Contains("ERROR"))
                    Global.오류로그(로그영역, "통신수신", $"{e}", false);
            }
            catch (Exception ex)
            {
                Global.오류로그(로그영역, "자료수신", $"수신 자료가 올바르지 않습니다. {ex.Message}", true);
            }
        }

        public void Close() => this.마킹기?.Close();
        public void Start() => this.마킹기?.Start();
        public void Stop() => this.마킹기?.Stop();

        public Boolean 자료송신(String message)
        {
            if (!this.마킹기.연결여부) return false;

            String sendMsg = $"SETTEXT \"001\" \"{message}\"\r\n";
            if (this.마킹기.Send(sendMsg)) return true;

            Global.오류로그(로그영역, "자료송신", $"[{message}] 자료전송에 실패하였습니다.", true);
            return false;
        }

    }
    public class 마킹기
    {
        public event EventHandler<String> 자료수신;
        public Int32 대기시간 { get; set; } = 20;
        public Boolean 동작여부 { get; set; } = false;
        public String 로그영역 { get; set; } = "마킹기";
        public virtual Boolean 연결여부 { get => this.Connected(); }
        public Boolean 핑퐁상태 { get; set; }
        public TcpClient 통신소켓 = null;
        public NetworkStream Stream { get => 통신소켓?.GetStream(); }
        public void Init() { this.통신소켓 = new TcpClient() { ReceiveBufferSize = 4096, SendBufferSize = 4096, SendTimeout = 10000, ReceiveTimeout = 10000 }; }
        public void Start() { this.동작여부 = true; new Thread(Read) { Priority = ThreadPriority.AboveNormal }.Start(); }
        public void Close()
        {
            this.동작여부 = false;
            this.Disconnect();
        }
        public void Stop() => this.동작여부 = false;

        private Int32 PollingPeriod = 1000;
        private DateTime PollingTime = DateTime.Today;
        private Boolean PollingState = false;

        public Boolean Connected()
        {
            if (this.통신소켓 == null) return false;
            if ((DateTime.Now - PollingTime).TotalMilliseconds < PollingPeriod) return PollingState;
            try { PollingState = this.통신소켓.Client.Poll(1000, SelectMode.SelectWrite); }
            catch { PollingState = false; }
            PollingTime = DateTime.Now;
            return PollingState;
        }
        public void Disconnect()
        {
            if (this.연결여부)
            {
                this.통신소켓?.Client?.Shutdown(SocketShutdown.Both);
                this.통신소켓?.Close();
            }
            this.통신소켓?.Dispose();
            this.통신소켓 = null;
        }

        private Int32 통신연결간격 = 1;
        private DateTime 통신연결시간 = DateTime.Now;
        public Boolean Connect()
        {
            try
            {
                if ((DateTime.Now - 통신연결시간).TotalSeconds < 통신연결간격) return false;

                this.Disconnect();
                this.Init();
                this.통신연결시간 = DateTime.Now;
                //String address = Global.환경설정.동작구분 == 동작구분.LocalTest ? "localhost" : Global.환경설정.잉크젯마킹기주소;
                String address = Global.환경설정.잉크젯마킹기주소;
                this.통신소켓?.Connect(address, Global.환경설정.잉크젯마킹기포트);

                Debug.WriteLine("잉크젯 마킹기 연결완료.");

                return 연결여부;
            }
            catch (Exception ex)
            {
                Global.경고로그(로그영역, "마킹기연결", $"잉크젯마킹기에 연결할 수 없습니다. {ex.Message}", true);
            }
            return false;
        }

        public List<Byte> ReceiveBuffer = new List<Byte>();
        public void Read()
        {
            while (this.동작여부)
            {
                Thread.Sleep(대기시간);
                if (!this.동작여부) break;

                if (!this.연결여부)
                {
                    if (this.Connect()) { }
                    continue;
                }

                try
                {
                    통신핑퐁전송();
                    if (this.통신소켓 == null)
                    {
                        this.동작여부 = false;
                        return;
                    }

                    if (this.통신소켓.Available < 1) continue;

                    Byte[] buffer = new Byte[4096];
                    Int32 read = this.Stream.Read(buffer, 0, buffer.Length);
                    string messege = Encoding.UTF8.GetString(buffer.ToArray());

                    if (messege == "") continue;
                    this.자료수신?.Invoke(this, messege);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message, "Read Error");
                }
            }
        }
        public Boolean Send(String data)
        {
            if (!this.연결여부) return false;
            try
            {
                Byte[] bytes = Encoding.UTF8.GetBytes(data);
                this.Stream.Write(bytes, 0, bytes.Length);
                this.Stream.Flush();
                return true;
            }
            catch (Exception ex)
            {
                Global.오류로그(로그영역, "Send", ex.Message, true);
                this.Disconnect();
                return false;
            }
        }

        public void 통신핑퐁전송()
        {
            if ((DateTime.Now - 통신연결시간).TotalSeconds < 통신연결간격) return;
            통신연결시간 = DateTime.Now;

            this.핑퐁상태 = !this.핑퐁상태;
        }
    }

    public class 통신프로토콜
    {
        public static string ConvertSpecialCharacters(string input)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                switch (c)
                {
                    case '<':
                        result.Append("<60>");
                        break;
                    case '>':
                        result.Append("<62>");
                        break;
                    case '\\':
                        result.Append("<92>");
                        break;
                    case '"':
                        result.Append("<34>");
                        break;
                    case '\b':
                        result.Append("<8>");
                        break;
                    case '\n':
                        result.Append("<10>");
                        break;
                    default:
                        result.Append(c);
                        break;
                }
            }

            //result = $"[SETTEXT \"001\" <{result}}>";

            Debug.WriteLine($"전송 Text : {result}");

            return result.ToString();
        }

    }
}
