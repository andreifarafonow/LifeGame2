using LifeGameCore.GameComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LifeGameCore.Services.GameServices
{
    public interface IMap
    {
        public void Initialize(Size size);
        public MapCell this[int x, int y] { get; set; }
        public Size Size { get; }
    }
}
