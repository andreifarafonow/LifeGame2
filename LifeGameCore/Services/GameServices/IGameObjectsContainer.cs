using LifeGame.Core.GameComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GameCore.GameServices
{
    public interface IGameObjectsContainer
    {
        public IEnumerable<GameObject> GetAllObjects();
        public IEnumerable<GameObject> GetObjectsInPosition(Point position);

        public void Add(GameObject gameObject);
        public void Remove(GameObject gameObject);
    }
}
