using LifeGame.Core.GameComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LifeGame.Core.Services.GameServices
{
    class RandomMapGenerator : IMapGenerator
    {
        public readonly Random _random;

        public RandomMapGenerator(Random random)
        {
            _random = random;
        }

        public void Generate(IMap map)
        {
            for (int y = 0; y < map.Size.Height; y++)
            {
                for (int x = 0; x < map.Size.Width; x++)
                {
                    var type = (MapCell.CellType)_random.Next(0, Enum.GetNames(typeof(MapCell.CellType)).Length);
                    map[x, y] = new MapCell(new Point(x, y), type);
                }
            }
        }
    }
}
