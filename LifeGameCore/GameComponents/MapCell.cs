﻿using System.Drawing;

namespace LifeGameCore.GameComponents
{
    public class MapCell
    {
        public Point Position { get; set; }
        public CellType TypeOfCell { get; }

        public MapCell(Point position, CellType cellType)
        {
            Position = position;
            TypeOfCell = cellType;
        }

        public enum CellType
        {
            Ground,
            Water
        }
    }
}
