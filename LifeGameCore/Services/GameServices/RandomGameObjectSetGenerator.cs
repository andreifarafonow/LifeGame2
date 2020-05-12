using GameCore.GameServices;
using LifeGameCore.GameComponents;
using LifeGameCore.Services.MovingServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LifeGameCore.Services.GameServices
{
    class RandomGameObjectSetGenerator : IGameObjectSetGenerator
    {
        private readonly Random _random;
        private readonly IMap _map;
        private readonly IGameObjectsContainer _gameObjectsContainer;

        delegate GameObject FactoryMethod();

        public RandomGameObjectSetGenerator(Random random, IMap map, IGameObjectsContainer gameObjectsContainer)
        {
            _random = random;
            _map = map;
            _gameObjectsContainer = gameObjectsContainer;
        }

        public void GenerateSet(int objectCount)
        {
            var result = new List<GameObject>();

            FactoryMethod[] barrierCreators = new FactoryMethod[] { CreateStone, CreateTree };
            FactoryMethod[] animalCreators = new FactoryMethod[] { CreateFish, CreateDuck, CreateSparrow, CreateTurtle, CreateRabbit };

            int barrierCount = _random.Next(objectCount);

            for (int i = 0; i < objectCount; i++)
            {
                GameObject created = i < barrierCount ? barrierCreators[_random.Next(barrierCreators.Length)]() : animalCreators[_random.Next(animalCreators.Length)]();

                do
                {
                    created.Position = new Point(_random.Next(_map.Size.Width), _random.Next(_map.Size.Height));
                }
                while (!created.СanBeLocatedAt(created.Position));

                _gameObjectsContainer.Add(created);
            }
        }

        GameObject CreateFish()
        {
            GameObject result = new GameObject() { Name = "Рыба", IsBarrier = false, Speed = 1 };

            result.AddMovementMethod<Swimming>();

            return result;
        }

        GameObject CreateDuck()
        {
            GameObject result = new GameObject() { Name = "Утка", IsBarrier = false, Speed = 2 };

            result.AddMovementMethod<Swimming>()
                  .AddMovementMethod<Flying>()
                  .AddMovementMethod<Going>();

            return result;
        }

        GameObject CreateSparrow()
        {
            GameObject result = new GameObject() { Name = "Воробей", IsBarrier = false, Speed = 3 };

            result.AddMovementMethod<Flying>()
                  .AddMovementMethod<Going>();

            return result;
        }

        GameObject CreateTurtle()
        {
            GameObject result = new GameObject() { Name = "Черепаха", IsBarrier = false, Speed = 1 };

            result.AddMovementMethod<Swimming>()
                  .AddMovementMethod<Going>();

            return result;
        }

        GameObject CreateRabbit()
        {
            GameObject result = new GameObject() { Name = "Кролик", IsBarrier = false, Speed = 2 };

            result.AddMovementMethod<Going>();

            return result;
        }

        GameObject CreateStone()
        {
            GameObject result = new GameObject() { Name = "Камень", IsBarrier = true, Speed = 0 };

            result.AddMovementMethod<Flying>();

            return result;
        }

        GameObject CreateTree()
        {
            GameObject result = new GameObject() { Name = "Дерево", IsBarrier = true, Speed = 0 };

            result.AddMovementMethod<Going>();

            return result;
        }
    }
}
