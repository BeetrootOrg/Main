﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Base
{
    public class BaseEntityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public uint Strength { get; set; }
        public uint Agility { get; set; }
        public uint Endurance { get; set; }
        public uint Intelligence { get; set; }
        public uint CriticalDamage { get; set; }
        public uint Speed { get; set; }
        public Rarity Rarity { get; set; }
    }
}
