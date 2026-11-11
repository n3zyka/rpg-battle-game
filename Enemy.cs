using System;
using System.Collections.Generic;

namespace RPG_Battle
{

    public class Enemy : Character
    {
        public int Damage { get; protected set; }
        public int Armor { get; protected set; }
        public int Level { get; protected set; }

        public Enemy(string name, int hp, int damage)
            : base(name, hp)
        {
            Damage = damage;
            Armor = 2;
            Level = 1;
        }

        public Enemy(string name, int hp, int damage, int armor, int level)
            : base(name, hp)
        {
            Damage = damage;
            Armor = armor;
            Level = level;
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} атакує!");

            target.TakeDamage(Damage);

            Console.WriteLine($"{Name} завдав {Damage} шкоди.");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Ворог: {Name} [{GetType().Name}]");
            Console.WriteLine($"HP: {HP} | Броня: {Armor} | Рівень: {Level}");
        }
    }


    public class Goblin : Enemy
    {
        public int Stealth { get; private set; }
        public bool IsFrenzied { get; private set; }
        public string WeaponType { get; private set; }

        public Goblin(string name, int hp, int damage, int stealth, string weaponType)
            : base(name, hp, damage, 1, 1)
        {
            Stealth = stealth;
            IsFrenzied = false;
            WeaponType = weaponType;
        }

        public override void Attack(Character target)
        {
            int totalDamage = Damage + Stealth / 2;

            Console.WriteLine($"{Name} підкрадається і б'є ({WeaponType})!");

            target.TakeDamage(totalDamage);

            Console.WriteLine($"{Name} завдав {totalDamage} шкоди.");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Стелс: {Stealth} | Зброя: {WeaponType}");
        }
    }


    public class Orc : Enemy
    {
        public int Rage { get; private set; }
        public int ShieldBlock { get; private set; }
        public string ClanName { get; private set; }

        public Orc(string name, int hp, int damage, int rage, string clanName)
            : base(name, hp, damage, 5, 2)
        {
            Rage = rage;
            ShieldBlock = 10;
            ClanName = clanName;
        }

        public override void Attack(Character target)
        {
            Rage += 5;

            int totalDamage = Damage + Rage / 10;

            Console.WriteLine($"{Name} впадає в лють! (Rage: {Rage})");

            target.TakeDamage(totalDamage);

            Console.WriteLine($"{Name} завдав {totalDamage} шкоди.");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Лють (Rage): {Rage} | Клан: {ClanName}");
        }
    }


    public class Skeleton : Enemy
    {
        public int BoneShield { get; private set; }
        public bool CanResurrect { get; private set; }
        public string ElementType { get; private set; }

        public Skeleton(string name, int hp, int damage, string elementType)
            : base(name, hp, damage, 0, 1)
        {
            BoneShield = 15;
            CanResurrect = true;
            ElementType = elementType;
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} випускає стрілу стихії {ElementType}!");

            target.TakeDamage(Damage);

            Console.WriteLine($"{Name} завдав {Damage} шкоди.");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Кістяний щит: {BoneShield} | Стихія: {ElementType}");
        }
    }


    public class Dragon : Enemy
    {
        private int turnCounter;

        public int FirePower { get; private set; }
        public int FlightHeight { get; private set; }
        public bool IsRoaring { get; private set; }
        public List<string> SpecialAbilities { get; private set; }

        public Dragon(string name, int hp, int damage, int firePower)
            : base(name, hp, damage, 10, 5)
        {
            FirePower = firePower;
            FlightHeight = 0;
            IsRoaring = false;
            SpecialAbilities = new List<string> { "Fire Breath", "Tail Whip" };
            turnCounter = 0;
        }

        public override void Attack(Character target)
        {
            turnCounter++;

            // кожен третій хід дракон дихає вогнем
            if (turnCounter % 3 == 0)
            {
                int totalDamage = Damage + FirePower / 2;

                Console.WriteLine($"{Name} використовує Fire Breath!");

                target.TakeDamage(totalDamage);

                Console.WriteLine($"{Name} завдав {totalDamage} шкоди.");
            }
            else
            {
                base.Attack(target);
            }
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Сила вогню: {FirePower} | Здібності: {string.Join(", ", SpecialAbilities)}");
        }
    }
}
