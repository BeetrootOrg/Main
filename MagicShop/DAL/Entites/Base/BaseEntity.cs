using DLL.Enums;

namespace DLL.Entites.Base
{
    public abstract class BaseEntity
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
        public int Price { get; set; }

    }
}
