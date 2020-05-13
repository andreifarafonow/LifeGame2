using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using GameCore.GameServices.ObjectsServices;
using LifeGame.Core.Services.GameServices;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace LifeGame.Core.Services.MovingServices
{
    class Swimming : Movement
    {
        public override bool CanMoveTo(Point point)
        {
            return point.IsInside(Map.Size) && !GameObjects.GetAllObjects().Where(x => x.Position == point).Any(x => x.IsBarrier) && Map[point.X, point.Y].TypeOfCell == GameComponents.MapCell.CellType.Water;
        }
    }
}
