using System;
using System.Collections.Generic;
using System.Text;

namespace LifeGame.DAL.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public List<Step> Steps { get; set; }
    }
}
