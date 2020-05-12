using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LifeGameCore.Services.GameServices
{
    interface IMapGenerator
    {
        public void Generate(IMap map);
    }
}
