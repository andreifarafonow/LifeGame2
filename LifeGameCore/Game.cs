using GameCore.GameServices;
using GameCore.GameServices.ObjectsServices;
using LifeGameCore.GameComponents;
using LifeGameCore.Services.GameServices;
using LifeGameCore.Services.MovingServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace LifeGameCore
{
    public class Game
    {
        public static ServiceProvider ServiceProvider;

        public Game(Size size, int objectCount)
        {
            ServiceProvider = new ServiceCollection()
            .AddSingleton<IMap, DefaultMap>()
            .AddTransient<IMapGenerator, RandomMapGenerator>()
            .AddSingleton(new Random())
            .AddSingleton<IGameObjectsContainer, ListGameObjectsContainer>()
            .AddSingleton<IGameObjectSetGenerator, RandomGameObjectSetGenerator>()
            .BuildServiceProvider();

            ServiceProvider.GetService<IMap>().Initialize(size);
            ServiceProvider.GetService<IGameObjectSetGenerator>().GenerateSet(objectCount);
        }

        public IMap Map 
        { 
            get => ServiceProvider.GetService<IMap>(); 
        }

        public IEnumerable<GameObject> GameObjects { get => ServiceProvider.GetService<IGameObjectsContainer>().GetAllObjects(); }


        public void Step()
        {
            foreach(var gameObject in GameObjects)
            {
                gameObject.Move();
            }
        }
    }
}
