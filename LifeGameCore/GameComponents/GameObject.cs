using GameCore.GameServices;
using LifeGameCore.Services.MovingServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace LifeGameCore.GameComponents
{
    public class GameObject
    {
        public Point Position { get; set; }

        public string Name { get; set; }

        public int Speed { get; set; }

        public bool IsBarrier { get; set; }

        List<Movement> movementMethods = new List<Movement>();

        public void Move()
        {
            var randomSortedMovements = movementMethods.OrderBy(x => Game.ServiceProvider.GetService<Random>().Next(1000));

            foreach(var movement in randomSortedMovements)
            {
                var newPos = movement.GetMovingResult(Speed, Position);

                if(newPos != Position)
                {
                    Position = newPos;
                    return;
                }
            }
            
        }

        public GameObject AddMovementMethod<T>() where T: Movement
        {
            var movement = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(T)) as Movement;

            movementMethods.Add(movement);

            return this;
        }

        public bool СanBeLocatedAt(Point point)
        {
            foreach (var movement in movementMethods)
            {
                if (movement.CanMoveTo(point))
                    return true;

            }

            return false;
        }
    }
}
