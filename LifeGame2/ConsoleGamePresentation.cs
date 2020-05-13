﻿using LifeGame.Core;
using LifeGame.Core.GameComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace LifeGame
{
    public class ConsoleGamePresentation
    {
        int gridLeftMargin = 4, gridTopMargin = 2, 
                   cellWidth = 9, cellHeight = 5;

        

        

        void DrawCellBackground(Point position, MapCell.CellType cellType)
        {
            for (int i = 0; i < cellHeight; i++)
            {
                Console.ForegroundColor = Console.BackgroundColor = cellType.GetConsoleColor();

                Console.SetCursorPosition(gridLeftMargin + position.X * cellWidth, gridTopMargin + position.Y * cellHeight + i);

                Console.WriteLine(string.Concat(Enumerable.Repeat('█', cellWidth)));
            }
        }

        void DrawObjectsNumInCell(Point position, int num)
        {
            Console.SetCursorPosition(gridLeftMargin + position.X * cellWidth + 3, gridTopMargin + position.Y * cellHeight + 2);
            Console.Write($"[{num}]");
        }

        void DrawObjectsNamesInCell(IEnumerable<GameObject> objects)
        {
            int offset = 0;

            foreach (var obj in objects)
            {
                string name = obj.Name;
                Console.SetCursorPosition(gridLeftMargin + obj.Position.X * cellWidth + 4 - name.Length / 2, gridTopMargin + obj.Position.Y * cellHeight + 2 - offset);
                Console.Write(name);

                if (offset <= 0)
                    offset = -offset + 1;
                else
                    offset = -offset;
            }
        }

        public void Display(Game game)
        {
            for (int y = 0; y < game.Map.Size.Height; y++)
            {
                for (int x = 0; x < game.Map.Size.Width; x++)
                {
                    DrawCellBackground(new Point(x, y), game.Map[x, y].TypeOfCell);

                    if (game.GameObjects != null && game.GameObjects.Count() > 0)
                    {
                        var objectsOnThisCell = game.GameObjects.Where(obj => obj.Position == new Point(x, y));

                        Console.ForegroundColor = ConsoleColor.Black;

                        if (objectsOnThisCell.Count() > 3)
                        {
                            DrawObjectsNumInCell(new Point(x, y), objectsOnThisCell.Count());
                        }
                        else if (objectsOnThisCell.Count() > 0)
                        {
                            DrawObjectsNamesInCell(objectsOnThisCell);
                        }
                    }
                }
            }

            Console.ResetColor();

            Console.SetCursorPosition(0, game.Map.Size.Height * cellHeight + gridTopMargin + 1);
        }
    }
}
