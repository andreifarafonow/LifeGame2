using GameCore.GameServices.ObjectsServices;
using LifeGame.Core.GameComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeGame.Core.Services.GameServices
{
    interface IGameObjectSetGenerator
    {
        public void GenerateSet(int objectCount);
    }
}
