using System;
using System.Collections.Generic;

namespace RPG_Battle
{
    public class Player
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public Weapon CurrentWeapon { get; set; }

        public List<Item> Inventory { get; set; }

        public Dictionary<string, int> Stats { get; set; }

        public Player(string name)
        {
            Name = name;
            HP = 100;

            CurrentWeapon = new Weapon(
                "Sword",
                20,
                100,
                "Melee"
            );

            Inventory = new List<Item>();

            Stats = new Dictionary<string, int>();

            Stats["Strength"] = 10;
            Stats["Defense"] = 5;
        }

        public void Attack(Enemy enemy)
        {
            if (CurrentWeapon.Durability > 0)
            {
                Console.WriteLine(
                    $"{Name} атакує {enemy.Name} зброєю {CurrentWeapon.Name}!"
                );

                enemy.HP -= CurrentWeapon.Damage;

                if (enemy.HP < 0)
                {
                    enemy.HP = 0;
                }

                CurrentWeapon.Durability--;

                Console.WriteLine(
                    $"{enemy.Name} отримав {CurrentWeapon.Damage} шкоди."
                );
            }
            else
            {
                Console.WriteLine("Зброя зламана!");
            }
        }

        public void ShowStats()
        {
            Console.WriteLine("\n=== ХАРАКТЕРИСТИКИ ===");
            Console.WriteLine($"Ім'я: {Name}");
            Console.WriteLine($"HP: {HP}");
            Console.WriteLine($"Зброя: {CurrentWeapon.Name}");
            Console.WriteLine($"Міцність: {CurrentWeapon.Durability}");

            Console.WriteLine("\nStats:");

            foreach (var stat in Stats)
            {
                Console.WriteLine(
                    $"{stat.Key}: {stat.Value}"
                );
            }

            Console.WriteLine("\nІнвентар:");

            if (Inventory.Count == 0)
            {
                Console.WriteLine("Пусто");
            }
            else
            {
                foreach (Item item in Inventory)
                {
                    Console.WriteLine($"- {item.Name}");
                }
            }
        }

        public void UsePotion()
        {
            foreach (Item item in Inventory)
            {
                if (item.Type == "Potion")
                {
                    HP += item.Value;

                    if (HP > 100)
                    {
                        HP = 100;
                    }

                    Console.WriteLine(
                        $"Ви використали {item.Name}. HP: {HP}"
                    );

                    Inventory.Remove(item);

                    return;
                }
            }

            Console.WriteLine("У вас немає зілля.");
        }
    }
}
