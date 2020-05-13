using LifeGame.Core.GameComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LifeGame.Core.Services.GameServices
{
    public interface IMap
    {
        public void Initialize(Size size);
        public MapCell this[int x, int y] { get; set; }
        public Size Size { get; }
    }
}
