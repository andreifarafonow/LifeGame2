using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LifeGame.DAL.Entities
{
    public class Interaction
    {
        public int Id { get; set; }
        public Step Step { get; set; }

        public GameObject Subject { get; set; }
        public GameObject Object { get; set; }

        public int ObjectHealthChange { get; set; }
    }
}
