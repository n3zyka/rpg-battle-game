using System;
using System.Collections.Generic;

namespace RPG_Battle
{
    // 1. Базовий клас ворога (сумісний із Player та Program)
    public class Enemy
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Level { get; set; }

        public Enemy(string name, int hp, int damage)
        {
            Name = name;
            HP = hp;
            Damage = damage;
            Armor = 2;
            Level = 1;
        }

        public Enemy(string name, int hp, int damage, int armor, int level)
        {
            Name = name;
            HP = hp;
            Damage = damage;
            Armor = armor;
            Level = level;
        }

        public virtual void Attack(Player player)
        {
            Console.WriteLine($"{Name} атакує!");

            int effectiveDamage = Damage;
            player.HP -= effectiveDamage;

            if (player.HP < 0)
            {
                player.HP = 0;
            }

            Console.WriteLine($"{Name} завдав {effectiveDamage} шкоди.");
        }
    }

    // 2. Клас Гобліна
    public class Goblin : Enemy
    {
        public int Stealth { get; set; }
        public bool IsFrenzied { get; set; }
        public string WeaponType { get; set; }

        public Goblin(string name, int hp, int damage, int stealth, string weaponType)
            : base(name, hp, damage, 1, 1)
        {
            Stealth = stealth;
            IsFrenzied = false;
            WeaponType = weaponType;
        }
    }

    // 3. Клас Орка
    public class Orc : Enemy
    {
        public int Rage { get; set; }
        public int ShieldBlock { get; set; }
        public string ClanName { get; set; }

        public Orc(string name, int hp, int damage, int rage, string clanName)
            : base(name, hp, damage, 5, 2)
        {
            Rage = rage;
            ShieldBlock = 10;
            ClanName = clanName;
        }
    }

    // 4. Клас Скелета
    public class Skeleton : Enemy
    {
        public int BoneShield { get; set; }
        public bool CanResurrect { get; set; }
        public string ElementType { get; set; }

        public Skeleton(string name, int hp, int damage, string elementType)
            : base(name, hp, damage, 0, 1)
        {
            BoneShield = 15;
            CanResurrect = true;
            ElementType = elementType;
        }
    }

    // 5. Клас Дракона / Боса
    public class Dragon : Enemy
    {
        public int FirePower { get; set; }
        public int FlightHeight { get; set; }
        public bool IsRoaring { get; set; }
        public List<string> SpecialAbilities { get; set; }

        public Dragon(string name, int hp, int damage, int firePower)
            : base(name, hp, damage, 10, 5)
        {
            FirePower = firePower;
            FlightHeight = 0;
            IsRoaring = false;
            SpecialAbilities = new List<string> { "Fire Breath", "Tail Whip" };
        }
    }
}