using GameCore.GameServices.ObjectsServices;
using LifeGameCore.GameComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeGameCore.Services.GameServices
{
    interface IGameObjectSetGenerator
    {
        public void GenerateSet(int objectCount);
    }
}
