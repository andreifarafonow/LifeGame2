using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LifeGame.Core.Services.GameServices
{
    interface IMapGenerator
    {
        public void Generate(IMap map);
    }
}
