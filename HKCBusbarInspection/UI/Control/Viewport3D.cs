﻿using DevExpress.XtraEditors;
using HKCBusbarInspection.Schemas;
using System;
using System.Diagnostics;

namespace HKCBusbarInspection.UI.Control
{
    public partial class Viewport3D : XtraUserControl
    {
        public Viewport3D()
        {
            InitializeComponent();
        }

        private BUSBAR3D Model3D = null;
        public void Init(BUSBAR3D model)
        {
            this.Model3D = model;
            if (!Model3D.Init(out String err2)) { Debug.WriteLine(err2, "Model3D Error"); }
            this.Controls.Clear();
            this.Controls.Add(Model3D.CreateHost());
            this.SetResults(new 검사결과().Reset(DateTime.Now));
        }

        public void SetResults(검사결과 결과)
        {
            if (결과 == null) return;
            if (this.InvokeRequired) { this.BeginInvoke(new Action(() => { SetResults(결과); })); return; }
            this.Model3D.SetResults(결과);
            this.Invalidate();
        }

        public void RefreshViewport()
        {
            if (this.InvokeRequired) { this.BeginInvoke(new Action(RefreshViewport)); }
            else this.Invalidate();
        }
    }
}
