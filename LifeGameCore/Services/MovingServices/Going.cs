using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using GameCore.GameServices.ObjectsServices;
using LifeGameCore.Services.GameServices;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace LifeGameCore.Services.MovingServices
{
    class Going : Movement
    {
        public override bool CanMoveTo(Point point)
        {
            return point.IsInside(Map.Size) && !GameObjects.GetAllObjects().Where(x => x.Position == point).Any(x => x.IsBarrier) && Map[point.X, point.Y].TypeOfCell == GameComponents.MapCell.CellType.Ground;
        }
    }
}
