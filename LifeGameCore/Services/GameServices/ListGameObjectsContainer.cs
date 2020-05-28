using LifeGame.Core.GameComponents;
using LifeGame.DAL;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameCore.GameServices.ObjectsServices
{
    class ListGameObjectsContainer : IGameObjectsContainer
    {
        private readonly DefaultContext _defaultContext;
        List<GameObject> gameObjects = new List<GameObject>();

        public ListGameObjectsContainer(DefaultContext defaultContext)
        {
            _defaultContext = defaultContext;
        }

        public void Add(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
            _defaultContext.GameObjects.Add(new LifeGame.DAL.Entities.GameObject());
        }

        public IEnumerable<GameObject> GetAllObjects()
        {
            return gameObjects;
        }

        public IEnumerable<GameObject> GetObjectsInPosition(Point position)
        {
            return gameObjects.Where(obj => obj.Position == position);
        }

        public void Remove(GameObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }
    }
}
