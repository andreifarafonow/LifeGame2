using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using GameCore.GameServices.ObjectsServices;
using LifeGameCore.Services.GameServices;
using Microsoft.Extensions.DependencyInjection;

namespace LifeGameCore.Services.MovingServices
{
    class Flying : Movement
    {
        public override bool CanMoveTo(Point point)
        {
            return point.IsInside(Map.Size);
        }
    }
}
