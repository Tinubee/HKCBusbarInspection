using HelixToolkit.Wpf;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HKCBusbarInspection.Schemas
{
    public class BUSBAR3D : Viewport
    {
        #region 초기화
        public override String StlPath => Global.환경설정.기본경로;
        public override String StlFile => Path.Combine(StlPath, $"{Global.환경설정.선택모델}.stl");
        public override Double Scale => 1;
        internal override void LoadStl()
        {
            if (!File.Exists(StlFile)) return;
            StLReader reader = new StLReader();
            Model3DGroup groups = reader.Read(StlFile);
            MainModel = groups.Children[0] as GeometryModel3D;
            //Debug.WriteLine(groups.Children.Count, "Groups Count");

            Point3D p = Center3D();
            Transform3DGroup transform = new Transform3DGroup();
            transform.Children.Add(new TranslateTransform3D(p.X * Scale, p.Y * Scale, 0 * Scale));
            transform.Children.Add(new ScaleTransform3D(Scale, Scale, Scale));
            MainModel.Transform = transform;
            MainModel.SetName(nameof(MainModel));
            MainModel.Material = FrontMaterial;
            MainModel.BackMaterial = BackMaterial;
            ModelGroup.Children.Add(MainModel);
        }
        #endregion

        #region 기본 설정
        List<Base3D> InspItems = new List<Base3D>();
        internal String InspectionName(검사항목 항목)
        {
            검사정보 정보 = Global.모델자료.선택모델.검사설정.GetItem(항목);
            if (정보 == null) return String.Empty;
            return 정보.검사명칭;
        }
        internal override void InitModel()
        {
            if (MainModel == null) return;
            Rect3D r = MainModel.Bounds;
            Debug.WriteLine($"{r.SizeY}, {r.SizeX}, {r.SizeZ}", "Rectangle3D");
            Double hx = r.SizeX / 2;
            Double hy = r.SizeY / 2;
            Double tz = 100;
            Double fz = 90;
            Double sz = 80;
            Double standardX = -52.5;
            Double standardY = -150;
            Double Scale = 3.5;


            AddText3D(new Point3D(-hx - 100, standardY, tz), "L", 48, MajorColors.FrameColor);
            AddText3D(new Point3D(+hx + 100, standardY, tz), "R", 48, MajorColors.FrameColor);
            AddArrowLine(new Point3D(-hx - 50, standardY, tz), new Point3D(hx + 50, standardY, tz), MajorColors.FrameColor); // Left ~ Right Center
            AddArrowLine(new Point3D(standardX, -hy, tz), new Point3D(standardX, hy, tz), MajorColors.FrameColor); // Width Center

            InspItems.Add(new Rectangle3D(검사항목.좌슬롯1) { Point = new Point3D(standardX - 4.825 * 2 * Scale, standardY - 1.95 * Scale, tz), Width = 30, Height = 30, Name = "좌슬롯1", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });
            InspItems.Add(new Rectangle3D(검사항목.좌슬롯2) { Point = new Point3D(standardX - 4.825 * 2 * Scale, standardY + 8.375 * Scale, tz), Width = 30, Height = 30, Name = "좌슬롯2", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });
            InspItems.Add(new Rectangle3D(검사항목.좌슬롯3) { Point = new Point3D(standardX - 4.825 * 2 * Scale, standardY + 19.25 * Scale, tz), Width = 30, Height = 30, Name = "좌슬롯3", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });
            InspItems.Add(new Rectangle3D(검사항목.좌슬롯4) { Point = new Point3D(standardX - 4.825 * 2 * Scale, standardY + 30.125 * Scale, tz), Width = 30, Height = 30, Name = "좌슬롯4", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });
            InspItems.Add(new Rectangle3D(검사항목.좌슬롯5) { Point = new Point3D(standardX - 4.825 * 2 * Scale, standardY + 41 * Scale, tz), Width = 30, Height = 30, Name = "좌슬롯5", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });

            InspItems.Add(new Rectangle3D(검사항목.중슬롯1) { Point = new Point3D(standardX + 4.525 * Scale, standardY - 1.95 * Scale, tz), Width = 30, Height = 30, Name = "중슬롯1", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });
            InspItems.Add(new Rectangle3D(검사항목.중슬롯2) { Point = new Point3D(standardX + 4.525 * Scale, standardY + 8.375 * Scale, tz), Width = 30, Height = 30, Name = "중슬롯2", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });
            InspItems.Add(new Rectangle3D(검사항목.중슬롯3) { Point = new Point3D(standardX + 4.525 * Scale, standardY + 19.25 * Scale, tz), Width = 30, Height = 30, Name = "중슬롯3", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });
            InspItems.Add(new Rectangle3D(검사항목.중슬롯4) { Point = new Point3D(standardX + 4.525 * Scale, standardY + 30.125 * Scale, tz), Width = 30, Height = 30, Name = "중슬롯4", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });
            InspItems.Add(new Rectangle3D(검사항목.중슬롯5) { Point = new Point3D(standardX + 4.525 * Scale, standardY + 41 * Scale, tz), Width = 30, Height = 30, Name = "중슬롯5", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });

            InspItems.Add(new Rectangle3D(검사항목.우슬롯1) { Point = new Point3D(standardX + 4.825 * 4 * Scale, standardY - 1.95 * Scale, tz), Width = 30, Height = 30, Name = "우슬롯1", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });
            InspItems.Add(new Rectangle3D(검사항목.우슬롯2) { Point = new Point3D(standardX + 4.825 * 4 * Scale, standardY + 8.375 * Scale, tz), Width = 30, Height = 30, Name = "우슬롯2", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });
            InspItems.Add(new Rectangle3D(검사항목.우슬롯3) { Point = new Point3D(standardX + 4.825 * 4 * Scale, standardY + 19.25 * Scale, tz), Width = 30, Height = 30, Name = "우슬롯3", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });
            InspItems.Add(new Rectangle3D(검사항목.우슬롯4) { Point = new Point3D(standardX + 4.825 * 4 * Scale, standardY + 30.125 * Scale, tz), Width = 30, Height = 30, Name = "우슬롯4", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });
            InspItems.Add(new Rectangle3D(검사항목.우슬롯5) { Point = new Point3D(standardX + 4.825 * 4 * Scale, standardY + 41 * Scale, tz), Width = 30, Height = 30, Name = "우슬롯5", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });


            InspItems.Add(new Label3D(검사항목.s좌상홀) { Point = new Point3D(standardX, standardY + 28 * Scale, fz), Origin = new Point3D(standardX - 80, standardY + 25 * Scale, fz), Name = "s좌상홀", LabelStyle = NamePrintType.Up, FontHeight = 10 });
            InspItems.Add(new Label3D(검사항목.s우상홀) { Point = new Point3D(standardX + 9.63 * Scale, standardY + 28 * Scale, fz), Origin = new Point3D(standardX + +80, standardY + 25 * Scale, fz), Name = "s우상홀", LabelStyle = NamePrintType.Up, FontHeight = 10 });
            InspItems.Add(new Label3D(검사항목.s좌하홀) { Point = new Point3D(standardX, standardY + 12.5 * Scale, fz), Origin = new Point3D(standardX - 80, standardY + 10 * Scale, fz), Name = "s좌하홀", LabelStyle = NamePrintType.Up, FontHeight = 10 });
            InspItems.Add(new Label3D(검사항목.s우하홀) { Point = new Point3D(standardX + 9.63 * Scale, standardY + 12.5 * Scale, fz), Origin = new Point3D(standardX + 80, standardY + 10 * Scale, fz), Name = "s우하홀", LabelStyle = NamePrintType.Up, FontHeight = 10 });

            InspItems.Add(new Label3D(검사항목.r좌상홀가로) { Point = new Point3D(standardX, standardY + 46 * Scale, fz), Origin = new Point3D(standardX - 125, standardY + 51 * Scale, tz), Name = "r좌상홀가로", LabelStyle = NamePrintType.Up, FontHeight = 10 });
            InspItems.Add(new Label3D(검사항목.r좌중홀가로) { Point = new Point3D(standardX, standardY + 20.5 * Scale, fz), Origin = new Point3D(standardX - 125, standardY + 25.5 * Scale, tz), Name = "r좌중홀가로", LabelStyle = NamePrintType.Up, FontHeight = 10 });
            InspItems.Add(new Label3D(검사항목.r좌하홀가로) { Point = new Point3D(standardX, standardY, fz), Origin = new Point3D(standardX - 125, standardY + 5 * Scale, tz), Name = "r좌하홀가로", LabelStyle = NamePrintType.Up, FontHeight = 10 });
            InspItems.Add(new Label3D(검사항목.r좌상홀세로) { Point = new Point3D(standardX, standardY + 46 * Scale, fz), Origin = new Point3D(standardX - 125, standardY + 47 * Scale, tz), Name = "r좌상홀세로", LabelStyle = NamePrintType.Up, FontHeight = 10 });
            InspItems.Add(new Label3D(검사항목.r좌중홀세로) { Point = new Point3D(standardX, standardY + 20.5 * Scale, fz), Origin = new Point3D(standardX - 125, standardY + 21.5 * Scale, tz), Name = "r좌중홀세로", LabelStyle = NamePrintType.Up, FontHeight = 10 });
            InspItems.Add(new Label3D(검사항목.r좌하홀세로) { Point = new Point3D(standardX, standardY, fz), Origin = new Point3D(standardX - 125, standardY + 1 * Scale, tz), Name = "r좌하홀세로", LabelStyle = NamePrintType.Up, FontHeight = 10 });

            InspItems.Add(new Label3D(검사항목.r우상홀가로) { Point = new Point3D(standardX + 9.63 * Scale, standardY + 46 * Scale, fz), Origin = new Point3D(standardX + 125, standardY + 51 * Scale, tz), Name = "r우상홀가로", LabelStyle = NamePrintType.Up, FontHeight = 10 });
            InspItems.Add(new Label3D(검사항목.r우중홀가로) { Point = new Point3D(standardX + 9.63 * Scale, standardY + 20.5 * Scale, fz), Origin = new Point3D(standardX + 125, standardY + 25.5 * Scale, tz), Name = "r우중홀가로", LabelStyle = NamePrintType.Up, FontHeight = 10 });
            InspItems.Add(new Label3D(검사항목.r우하홀가로) { Point = new Point3D(standardX + 9.63 * Scale, standardY, fz), Origin = new Point3D(standardX + 125, standardY + 5 * Scale, tz), Name = "r우하홀가로", LabelStyle = NamePrintType.Up, FontHeight = 10 });
            InspItems.Add(new Label3D(검사항목.r우상홀세로) { Point = new Point3D(standardX + 9.63 * Scale, standardY + 46 * Scale, fz), Origin = new Point3D(standardX + 125, standardY + 47 * Scale, tz), Name = "r우상홀세로", LabelStyle = NamePrintType.Up, FontHeight = 10 });
            InspItems.Add(new Label3D(검사항목.r우중홀세로) { Point = new Point3D(standardX + 9.63 * Scale, standardY + 20.5 * Scale, fz), Origin = new Point3D(standardX + 125, standardY + 21.5 * Scale, tz), Name = "r우중홀세로", LabelStyle = NamePrintType.Up, FontHeight = 10 });
            InspItems.Add(new Label3D(검사항목.r우하홀세로) { Point = new Point3D(standardX + 9.63 * Scale, standardY, fz), Origin = new Point3D(standardX + 125, standardY + 1 * Scale, tz), Name = "r우하홀세로", LabelStyle = NamePrintType.Up, FontHeight = 10 });

            AddArrowLine(new Point3D(standardX + 7.7 * Scale, standardY + 93 * Scale, sz), new Point3D(-standardX + 19 * Scale, standardY + 93 * Scale, sz), MajorColors.FrameColor); // 측면너비
            AddArrowLine(new Point3D(standardX + 30 * Scale, standardY + 93.5 * Scale, sz - 53.4), new Point3D(standardX + 30 * Scale, standardY + 92.7 * Scale, sz + 65), MajorColors.FrameColor); // 측면높이
            InspItems.Add(new Label3D(검사항목.측면가로) { Point = new Point3D(standardX + 13 * Scale, standardY + 67.5 * Scale, sz - 260), Origin = new Point3D(standardX + 13 * Scale, standardY + 67.5 * Scale, sz - 260), Name = "측면가로", LabelStyle = NamePrintType.Side, FontHeight = 10 });
            InspItems.Add(new Label3D(검사항목.측면세로) { Point = new Point3D(standardX + 25 * Scale, standardY + 78 * Scale, sz - 260), Origin = new Point3D(standardX + 25 * Scale, standardY + 78 * Scale, sz - 260), Name = "측면세로", LabelStyle = NamePrintType.Side, FontHeight = 10 });
            InspItems.Add(new Circle3D(검사항목.측면홀경) { Point = new Point3D(standardX + 37 * Scale, standardY + 72.5 * Scale, sz - 260), Name = "측면홀경", LabelStyle = NamePrintType.Side , FontHeight = 10 });
            InspItems.ForEach(e => e.Create(Children));
        }
        #endregion

        public virtual Color GetColor(결과구분 결과) => 결과 == 결과구분.OK ? MajorColors.GoodColor : MajorColors.BadColor;
        public void SetResults(검사결과 결과)
        {
            foreach (Base3D 항목 in InspItems)
            {
                검사정보 정보 = 결과.GetItem(항목.Type);
                if (정보 == null) continue;
                //if (항목.Type == 검사항목.QrLegibility) 항목.Draw(Decimal.MinValue, 결과.큐알결과());
                else 항목.Draw(정보.결과값, 정보.측정결과);
            }
        }
    }
}
