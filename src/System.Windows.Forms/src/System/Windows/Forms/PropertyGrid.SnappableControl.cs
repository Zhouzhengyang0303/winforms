﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable disable

using System.Drawing;

namespace System.Windows.Forms
{
    public partial class PropertyGrid
    {
        internal abstract class SnappableControl : Control
        {
            protected PropertyGrid ownerGrid;
            internal bool userSized;

            public abstract int GetOptimalHeight(int width);
            public abstract int SnapHeightRequest(int request);

            public SnappableControl(PropertyGrid ownerGrid)
            {
                this.ownerGrid = ownerGrid;
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            }

            public override Cursor Cursor
            {
                get
                {
                    return Cursors.Default;
                }
                set => base.Cursor = value;
            }

            protected override void OnControlAdded(ControlEventArgs ce)
            {
            }

            public Color BorderColor { get; set; } = SystemColors.ControlDark;

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Rectangle r = ClientRectangle;
                r.Width--;
                r.Height--;

                using var borderPen = BorderColor.GetCachedPenScope();
                e.Graphics.DrawRectangle(borderPen, r);
            }
        }
    }
}
