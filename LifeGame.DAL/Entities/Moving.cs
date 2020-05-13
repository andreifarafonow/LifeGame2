using System;
using System.Collections.Generic;
using System.Text;

namespace LifeGame.DAL.Entities
{
    public class Moving
    {
        public int Id { get; set; }
        public Step Step { get; set; }

        public GameObject GameObject { get; set; }

        public int NewX { get; set; }
        public int NewY { get; set; }
    }
}
