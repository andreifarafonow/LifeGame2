using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using GameCore.GameServices.ObjectsServices;
using LifeGame.Core.Services.GameServices;
using Microsoft.Extensions.DependencyInjection;

namespace LifeGame.Core.Services.MovingServices
{
    class Flying : Movement
    {
        public override bool CanMoveTo(Point point)
        {
            return point.IsInside(Map.Size);
        }
    }
}
