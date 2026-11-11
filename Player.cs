using System;
using System.Collections.Generic;

namespace RPG_Battle
{
    public class Player : Character
    {
        public Weapon CurrentWeapon { get; set; }

        public List<Item> Inventory { get; private set; }

        public Dictionary<string, int> Stats { get; private set; }

        public Player(string name)
            : base(name, 100)
        {
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

        public override void Attack(Character target)
        {
            if (CurrentWeapon.Durability > 0)
            {
                Console.WriteLine(
                    $"{Name} атакує {target.Name} зброєю {CurrentWeapon.Name}!"
                );

                target.TakeDamage(CurrentWeapon.Damage);

                CurrentWeapon.DecreaseDurability();

                Console.WriteLine(
                    $"{target.Name} отримав {CurrentWeapon.Damage} шкоди."
                );
            }
            else
            {
                Console.WriteLine("Зброя зламана!");
            }
        }

        public override void ShowInfo()
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
                    Heal(item.Value);

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
