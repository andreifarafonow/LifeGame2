using System;
using System.Collections.Generic;
using System.Text;

namespace LifeGame.DAL.Entities
{
    public class Step
    {
        public int Id { get; set; }
        public Session Session { get; set; }
        public List<Interaction> Interactions { get; set; }
        public List<Moving> Movings { get; set; }
    }
}
