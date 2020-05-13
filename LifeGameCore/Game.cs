using GameCore.GameServices;
using GameCore.GameServices.ObjectsServices;
using LifeGame.DAL;
using LifeGame.Core.GameComponents;
using LifeGame.Core.Services.GameServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace LifeGame.Core
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
            .AddDbContext<DefaultContext>()
            .BuildServiceProvider();

            ServiceProvider.GetService<IMap>().Initialize(size);
            ServiceProvider.GetService<IGameObjectSetGenerator>().GenerateSet(objectCount);

            ServiceProvider.GetService<DefaultContext>().GameObjects.Add(new DAL.Entities.GameObject());
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
