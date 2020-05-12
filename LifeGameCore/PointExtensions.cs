using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LifeGameCore
{
    public static class PointExtensions
    {
        public static bool IsInside(this Point point, Size rect)
        {
            return point.X >= 0 && point.Y >= 0 && point.X < rect.Width && point.Y < rect.Height;
        }
    }
}
