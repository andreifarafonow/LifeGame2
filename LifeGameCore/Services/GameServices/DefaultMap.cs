using LifeGameCore.GameComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LifeGameCore.Services.GameServices
{
    class DefaultMap : IMap
    {
        List<MapCell> _mapCells = new List<MapCell>();
        private readonly IMapGenerator _mapGenerator;
        

        public DefaultMap(IMapGenerator mapGenerator)
        {
            _mapGenerator = mapGenerator;
        }

        public void Initialize(Size size)
        {
            Size = size;

            _mapGenerator.Generate(this);
        }

        public MapCell this[int x, int y]
        {
            get
            {
                return _mapCells.First(cell => cell.Position == new Point(x, y));
            }
            set
            {
                _mapCells.RemoveAll(cell => cell.Position == new Point(x, y));
                _mapCells.Add(value);
            }
        }

        public Size Size { get; private set; }
    }
}
