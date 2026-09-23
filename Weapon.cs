using System;
using System.Collections.Generic;

namespace RPG_Battle
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Durability { get; set; }
        public string Type { get; set; }

        public List<string> Effects { get; set; }
        public Dictionary<string, int> Stats { get; set; }
        public Queue<string> Upgrades { get; set; }
        public HashSet<string> Enemies { get; set; }

        public Weapon(string name, int damage, int durability, string type)
        {
            Name = name;
            Damage = damage;
            Durability = durability;
            Type = type;

            Effects = new List<string>();
            Stats = new Dictionary<string, int>();
            Upgrades = new Queue<string>();
            Enemies = new HashSet<string>();
        }

        public void Attack()
        {
            if (Durability > 0)
            {
                Console.WriteLine($"{Name} завдає {Damage} шкоди!");
                Durability--;
            }
            else
            {
                Console.WriteLine($"{Name} зламана!");
            }
        }

        public void Repair(int amount)
        {
            Durability += amount;
            Console.WriteLine($"{Name} відремонтовано на {amount}.");
        }

        public void AddEffect(string effect)
        {
            Effects.Add(effect);
            Console.WriteLine($"Додано ефект: {effect}");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Зброя: {Name}");
            Console.WriteLine($"Тип: {Type}");
            Console.WriteLine($"Шкода: {Damage}");
            Console.WriteLine($"Міцність: {Durability}");
        }
    }
}
