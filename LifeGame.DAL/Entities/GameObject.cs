using System;
using System.Collections.Generic;
using System.Text;

namespace LifeGame.DAL.Entities
{
    public class GameObject
    {
        public int Id { get; set; }
        public List<Moving> Movings { get; set; }
    }
}
