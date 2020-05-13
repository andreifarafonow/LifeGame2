using LifeGame.Core.Services.GameServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using GameCore.GameServices;
using System.Linq;

namespace LifeGame.Core.Services.MovingServices
{
    public abstract class Movement
    {
        protected IMap Map { get => Game.ServiceProvider.GetService<IMap>(); }
        protected IGameObjectsContainer GameObjects { get => Game.ServiceProvider.GetService<IGameObjectsContainer>(); }
        protected Random Random { get => Game.ServiceProvider.GetService<Random>(); }

        /// <summary>
        /// Передвижение объекта
        /// </summary>
        /// <param name="maxStepLength">Максимальная длина шага</param>
        /// <param name="startPosition">Начальная позиция перемещения</param>
        /// <returns>Возвращает конечную позицию (Может вернуть стартувую позицию, если тип передвижения не возможен)</returns>
        public Point GetMovingResult(int maxStepLength, Point startPosition)
        {
            Point result = startPosition;

            Direction[] randomSortedDirs = Enum.GetValues(typeof(Direction)).Cast<Direction>().OrderBy(x => Random.Next(1000)).ToArray();

            bool moved = false;

            foreach(var dir in randomSortedDirs)
            {
                for (int i = 0; i < maxStepLength; i++)
                {
                    Point target = GetPointInDirection(result, dir);

                    if (CanMoveTo(target))
                    {
                        result = target;
                        moved = true;
                    }
                    else
                    {
                        break;
                    }
                }

                if (moved)
                    break;
            }

            return result;
        }

        /// <summary>
        /// Возвращает логическое значение, означающее возможно ли оказаться в указанной точке конкретным способом передвижения.
        /// </summary>
        /// <param name="point">Конечная точка</param>
        /// <returns></returns>
        public abstract bool CanMoveTo(Point point);

        enum Direction
        {
            Right,
            Down,
            Left,
            Up
        }

        Point GetPointInDirection(Point from, Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    return new Point(from.X, from.Y + 1);
                case Direction.Up:
                    return new Point(from.X, from.Y - 1);
                case Direction.Left:
                    return new Point(from.X - 1, from.Y);
                case Direction.Right:
                    return new Point(from.X + 1, from.Y);
            }
            throw new Exception();
        }
    }
}
