using LifeGame.Core.GameComponents;
using System;
using System.Collections.Generic;

namespace LifeGame
{
    public static class ConsoleExtensions
    {
        public static ConsoleColor GetConsoleColor(this MapCell.CellType celltype)
        {
            Dictionary<MapCell.CellType, ConsoleColor> cellColors = new Dictionary<MapCell.CellType, ConsoleColor>()
            {
                { MapCell.CellType.Ground,  ConsoleColor.DarkGreen },
                { MapCell.CellType.Water,  ConsoleColor.Cyan }
            };

            if (cellColors.ContainsKey(celltype))
                return cellColors[celltype];
            else
                throw new Exception("Для данного типа ячейки не задан фоновый цвет");
        }
    }
}
