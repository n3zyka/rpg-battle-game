using System;
using System.Collections.Generic;

namespace RPG_Battle
{
    public class Item
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public int Price { get; set; }

        public List<string> Effects { get; set; }
        public Dictionary<string, int> Stats { get; set; }
        public Queue<string> Uses { get; set; }
        public HashSet<string> AllowedClasses { get; set; }

        public Item(string name, string type, int value, int price)
        {
            Name = name;
            Type = type;
            Value = value;
            Price = price;

            Effects = new List<string>();
            Stats = new Dictionary<string, int>();
            Uses = new Queue<string>();
            AllowedClasses = new HashSet<string>();
        }

        public void Use()
        {
            Console.WriteLine($"Використано предмет: {Name}");

            if (Type == "Potion")
            {
                Console.WriteLine($"Відновлено {Value} HP.");
            }
        }

        public void AddEffect(string effect)
        {
            Effects.Add(effect);
            Console.WriteLine($"Ефект {effect} додано до предмета.");
        }

        public void AddUse(string use)
        {
            Uses.Enqueue(use);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Предмет: {Name}");
            Console.WriteLine($"Тип: {Type}");
            Console.WriteLine($"Значення: {Value}");
            Console.WriteLine($"Ціна: {Price}");
        }
    }
}