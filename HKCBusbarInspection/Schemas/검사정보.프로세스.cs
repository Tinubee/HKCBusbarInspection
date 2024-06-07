﻿using MvUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;


namespace HKCBusbarInspection.Schemas
{
    [Table("inspl")]
    public class 검사결과
    {
        [Column("ilwdt"), Required, Key, JsonProperty("ilwdt"), Translation("Time", "일시")]
        public DateTime 검사일시 { get; set; } = DateTime.Now;
        [Column("ilmcd"), JsonProperty("ilmcd"), Translation("Model", "모델")]
        public 모델구분 모델구분 { get; set; } = 모델구분.None;
        [Column("ilshu"), JsonProperty("ilres"), Translation("Result", "판정")]
        public 셔틀위치 셔틀위치 { get; set; } = 셔틀위치.None;
        [Column("ilnum"), JsonProperty("ilnum"), Translation("Index", "번호")]
        public Int32 검사코드 { get; set; } = 0;
        [Column("ilres"), JsonProperty("ilres"), Translation("Result", "판정")]
        public 결과구분 측정결과 { get; set; } = 결과구분.WA;
        [Column("ilctq"), JsonProperty("ilctq"), Translation("CTQ", "CTQ결과")] //Critical to Quality
        public 결과구분 CTQ결과 { get; set; } = 결과구분.WA;
        [Column("ilsuf"), JsonProperty("ilsuf"), Translation("Suface", "외관결과")]
        public 결과구분 외관결과 { get; set; } = 결과구분.WA;
        [NotMapped, JsonIgnore, Translation("NG Items", "불량정보")]
        public String 불량정보 { get; set; } = String.Empty;
        [NotMapped, JsonIgnore]
        public String 결과문구 => Localization.GetString(측정결과);
        [NotMapped, JsonIgnore]
        public String 품질문구 => Localization.GetString(CTQ결과);
        [NotMapped, JsonIgnore]
        public String 외관문구 => Localization.GetString(외관결과);
        [NotMapped, JsonProperty("inspd")]
        public List<검사정보> 검사내역 { get; set; } = new List<검사정보>();
        [NotMapped, JsonIgnore, Browsable(false)]
        public List<String> 불량내역 = new List<String>();


        public 검사결과()
        {
            this.검사일시 = DateTime.Now;
            this.모델구분 = Global.환경설정.선택모델;
        }

        public 검사결과 Reset()
        {
            this.검사일시 = DateTime.Now;
            this.모델구분 = Global.환경설정.선택모델;
            this.셔틀위치 = 셔틀위치.None;
            this.측정결과 = 결과구분.WA;
            this.CTQ결과 = 결과구분.WA;
            this.외관결과 = 결과구분.WA;
            this.불량정보 = String.Empty;
            this.검사내역.Clear();
            this.불량내역.Clear();

            검사설정 자료 = Global.모델자료.GetItem(this.모델구분)?.검사설정;
            foreach (검사정보 정보 in 자료)
            {
                if (!정보.검사여부) continue;
                this.검사내역.Add(new 검사정보(정보) { 검사일시 = this.검사일시 });
            }
            return this;
        }
        public 검사결과 Reset(카메라구분 카메라)
        {
            검사설정 자료 = Global.모델자료.GetItem(this.모델구분)?.검사설정;
            foreach (검사정보 정보 in 자료)
            {
                if ((Int32)정보.검사장치 != (Int32)카메라) continue;
                검사정보 수동 = this.검사내역.Where(e => e.검사항목 == 정보.검사항목).FirstOrDefault();
                if (정보 == null) continue;
                수동.검사명칭 = 정보.검사명칭;
                수동.최소값 = 정보.최소값;
                수동.기준값 = 정보.기준값;
                수동.최대값 = 정보.최대값;
                수동.보정값 = 정보.보정값;
                수동.교정값 = 정보.교정값;
            }
            return this;
        }
        public void AddRange(List<검사정보> 자료)
        {
            this.검사내역.AddRange(자료);
            this.검사내역.ForEach(e => { e.Init(); e.검사명칭 = Global.모델자료.GetItemName(this.모델구분, e.검사항목); });
            List<String> 불량내역 = this.검사내역.Where(e => e.측정결과 != 결과구분.OK && e.측정결과 != 결과구분.PS).Select(e => e.검사명칭).ToList();
            if (불량내역.Count > 0) this.불량정보 = String.Join(",", 불량내역);
        }

        private String[] AppearanceFields = new String[] { nameof(측정결과), nameof(CTQ결과), nameof(외관결과) };
        public void SetAppearance(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e == null || !AppearanceFields.Contains(e.Column.FieldName)) return;
            PropertyInfo p = typeof(검사결과).GetProperty(e.Column.FieldName);
            if (p == null || p.PropertyType != typeof(결과구분)) return;
            Object v = p.GetValue(this);
            if (v == null) return;
            e.Appearance.ForeColor = 환경설정.결과표현색상((결과구분)v);
        }

        public 검사정보 GetItem(장치구분 장치, String name) => 검사내역.Where(e => e.검사장치 == 장치 && e.검사명칭 == name).FirstOrDefault();
        public 검사정보 GetItem(검사항목 항목) => 검사내역.Where(e => e.검사항목 == 항목).FirstOrDefault();

        private Decimal PixelToMeter(검사정보 검사, Double value)
        {
            Double result = 0;
            if (value == 0 || 검사.교정값 <= 0) result = value;
            else if (검사.카메라여부) result = value * (Decimal.ToDouble(검사.교정값) / 1000);
            else result = value;
            return (Decimal)Math.Round(result, Global.환경설정.결과자릿수);
        }
        private Double MeterToPixel(검사정보 검사, Decimal value)
        {
            if (검사.교정값 <= 0 || !검사.카메라여부) return Decimal.ToDouble(value);
            return Decimal.ToDouble(value) / Decimal.ToDouble(검사.교정값);
        }


        public Boolean SetResultValue_Client(검사정보 검사, Double value, out Decimal 결과값, out Decimal 측정값, Boolean 마진포함 = false)
        {
            Decimal result = (Decimal)value;
            Boolean r = result >= 검사.최소값 && result <= 검사.최대값;
            결과값 = result;
            측정값 = (Decimal)Math.Round(value, Global.환경설정.결과자릿수);
            if (r) return true;
            if (검사.마진값 <= 0 || 마진포함) return false;

            if (검사.최소값 > result)
            {
                if (검사.최소값 > result + 검사.마진값 * 검사.결과부호) return false;
            }
            else if (검사.최대값 < result)
            {
                if (검사.최대값 < result - 검사.마진값 * 검사.결과부호) return false;
            }

            return false;
        }
        public Boolean SetResultValue(검사정보 검사, Double value, out Decimal 결과값, out Decimal 측정값, Boolean 마진포함 = false)
        {
            Decimal result = PixelToMeter(검사, value);
            result += 검사.보정값;
            result *= 검사.결과부호;
            Boolean r = result >= 검사.최소값 && result <= 검사.최대값;
            결과값 = result;
            측정값 = (Decimal)Math.Round(value, Global.환경설정.결과자릿수);
            if (r) return true;
            if (검사.마진값 <= 0 || 마진포함) return false;

            Int32 factor = 0;
            if (검사.최소값 > result)
            {
                if (검사.최소값 > result + 검사.마진값 * 검사.결과부호) return false;
                factor = 1;
            }
            else if (검사.최대값 < result)
            {
                if (검사.최대값 < result - 검사.마진값 * 검사.결과부호) return false;
                factor = -1;
            }
            Double value2 = value + MeterToPixel(검사, 검사.마진값) * factor;
            if (value2 == value) return false;

            Boolean r2 = SetResultValue(검사, value2, out Decimal 결과값2, out Decimal 측정값2, true);
            if (r2)
            {
                결과값 = 결과값2;
                측정값 = 측정값2;
                return true;
            }
            return false;
        }

        public 검사정보 SetResult(검사정보 검사, Double value)
        {
            if (검사 == null) return null;
            if (Double.IsNaN(value))
            {
                검사.측정값 = 0;
                검사.결과값 = 0;
                검사.측정결과 = 결과구분.ER;
                return 검사;
            }
            Boolean ok = SetResultValue(검사, value, out Decimal 결과값, out Decimal 측정값);
            검사.측정값 = 측정값;
            검사.결과값 = 결과값;
            if (검사.측정단위 == 단위구분.ON)
            {
                //값이 0이면 OK / 1이상이면 NG
                검사.측정결과 = 측정값 == 0 ? 결과구분.OK : 결과구분.NG;
                검사.결과값 = 측정값 == 0 ? 1 : 0;
            }
            else
                검사.측정결과 = ok ? 결과구분.OK : 결과구분.NG;

            //Common.DebugWriteLine("검사정보", 로그구분.정보, $"검사결과 - {검사.측정결과}");
            return 검사;
        }
        public 검사정보 SetResult(String name, Double value) => SetResult(검사내역.Where(e => e.검사항목.ToString() == name).FirstOrDefault(), value);
        public 검사정보 SetResult(검사항목 항목, Double value) => SetResult(검사내역.Where(e => e.검사항목 == 항목).FirstOrDefault(), value);
        public void SetResults(카메라구분 카메라, Dictionary<String, Double> results)
        {
            foreach (var result in results)
            {
                검사정보 정보 = GetItem((장치구분)카메라, result.Key);
                if (정보 == null) continue;

                SetResult(정보, result.Value);
            }
        }
        public void SetResults(Dictionary<Int32, Decimal> 내역)
        {
            if (내역 == null) return;
            foreach (Int32 index in 내역.Keys)
            {
                검사항목 항목 = (검사항목)index;
                SetResult(항목, Convert.ToDouble(내역[index]));
            }
        }

        public 검사정보 SetValue(검사항목 항목, Double value) => SetValue(검사내역.Where(e => e.검사항목 == 항목).FirstOrDefault(), value);
        //결과만 추가하도록 새롭게 추가
        public 검사정보 SetValue(검사정보 검사, Double value)
        {
            if (검사 == null) return null;
            if (Double.IsNaN(value)) { 검사.측정결과 = 결과구분.ER; return 검사; }
            Boolean ok = SetResultValue_Client(검사, value, out Decimal 결과값, out Decimal 측정값);
            검사.측정값 = 측정값;
            검사.결과값 = 결과값;
            검사.측정결과 = ok ? 결과구분.OK : 결과구분.NG;

            return 검사;
        }

        public void SetValues(Dictionary<Int32, Decimal> 내역)
        {
            if (내역 == null) return;
            foreach (Int32 index in 내역.Keys)
            {

                검사항목 항목 = (검사항목)index;
                SetValue(항목, Convert.ToDouble(내역[index]));
                Debug.WriteLine($"{항목}, {내역[index]}");
            }
        }
        private 결과구분 최종결과(List<결과구분> 결과목록)
        {
            if (결과목록.Contains(결과구분.ER)) return 결과구분.ER;
            if (결과목록.Contains(결과구분.NG)) return 결과구분.NG;
            return 결과구분.OK;
        }

        public 결과구분 결과계산()
        {
            List<결과구분> 전체결과 = new List<결과구분>();
            List<결과구분> 품질결과 = new List<결과구분>();
            List<결과구분> 외관결과 = new List<결과구분>();

            foreach (검사정보 정보 in this.검사내역)
            {
                // 임시로 검사중인 항목 완료 처리
                if (정보.측정결과 < 결과구분.PS)
                {
                    this.SetResult(정보, Convert.ToDouble(정보.측정값));
                }

                if (정보.측정결과 == 결과구분.PS) continue;

                if (!전체결과.Contains(정보.측정결과))
                {
                    전체결과.Add(정보.측정결과);
                }

                if (정보.검사그룹 == 검사그룹.CTQ) { if (!품질결과.Contains(정보.측정결과)) 품질결과.Add(정보.측정결과); }
                if (정보.검사그룹 == 검사그룹.Surface) { if (!외관결과.Contains(정보.측정결과)) 외관결과.Add(정보.측정결과); }
            }

            this.측정결과 = 최종결과(전체결과);

            if (this.측정결과 == 결과구분.OK)
            {
                this.CTQ결과 = 결과구분.OK;
                this.외관결과 = 결과구분.OK;
            }
            else
            {
                this.CTQ결과 = 최종결과(품질결과);
                this.외관결과 = 최종결과(외관결과);

                List<검사정보> 불량내역 = this.검사내역.Where(e => e.결과분류 == 결과분류.Summary && (e.측정결과 == 결과구분.NG || e.측정결과 == 결과구분.ER)).ToList();
                if (불량내역.Count > 0)
                {
                    foreach (검사정보 정보 in 불량내역)
                        this.불량내역.Add(정보.검사항목.ToString());
                }
                this.불량정보 = String.Join(",", this.불량내역.ToArray());
                this.불량내역.Clear();
            }
            Debug.WriteLine($"{this.검사코드} = {this.측정결과}", "검사완료");
            return this.측정결과;
        }
        public Boolean 카메라검사보기(검사정보 정보)
        {
            try
            {
                //if (this.검사코드 >= 9999 || this.검사코드 < 1 || 정보 == null || !CameraAttribute.IsCamera(정보.검사장치)) return false;
                //카메라구분 카메라 = (카메라구분)정보.검사장치;
                //String file = Global.사진자료.CopyImageFile(this.검사일시, this.검사코드, 카메라);
                //if (String.IsNullOrEmpty(file) || !File.Exists(file))
                //    return Utils.WarningMsg("The image file does not exist.");
                //CogToolEdit cogToolEdit = new CogToolEdit() { 사진파일 = file };
                //cogToolEdit.Init(Global.비전검사[카메라]);
                //cogToolEdit.Show(Global.MainForm);
                return true;
            }
            catch (Exception ex) { Utils.ErrorMsg(ex.Message); }
            return false;
        }
    }
}
