﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? DeletedDate { get; set; }
        public string Name { get; set; }
    }
}
