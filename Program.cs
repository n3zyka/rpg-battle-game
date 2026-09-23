using System;
using System.Collections.Generic;

// ==================== PLAYER ====================

class Player
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

        CurrentWeapon = new Weapon("Sword", 20);

        Inventory = new List<Item>();
        Stats = new Dictionary<string, int>();

        Stats["Strength"] = 10;
        Stats["Defense"] = 5;
    }

    public void Attack(Enemy enemy)
    {
        Console.WriteLine(
            $"{Name} атакує {enemy.Name} зброєю {CurrentWeapon.Name}!"
        );

        enemy.HP -= CurrentWeapon.Damage;

        if (enemy.HP < 0)
            enemy.HP = 0;

        Console.WriteLine(
            $"{enemy.Name} отримав {CurrentWeapon.Damage} dmg."
        );
    }

    public void ShowStats()
    {
        Console.WriteLine("\n=== ХАРАКТЕРИСТИКИ ===");
        Console.WriteLine($"Ім'я: {Name}");
        Console.WriteLine($"HP: {HP}");
        Console.WriteLine($"Зброя: {CurrentWeapon.Name}");

        Console.WriteLine("Stats:");

        foreach (var stat in Stats)
        {
            Console.WriteLine($"{stat.Key}: {stat.Value}");
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
            if (item.Name == "Health Potion")
            {
                HP += item.Value;

                if (HP > 100)
                    HP = 100;

                Inventory.Remove(item);

                Console.WriteLine(
                    $"Ви використали зілля. HP: {HP}"
                );

                return;
            }
        }

        Console.WriteLine("У вас немає зілля.");
    }
}


// ==================== ENEMY ====================

class Enemy
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int Damage { get; set; }

    public Enemy(string name, int hp, int damage)
    {
        Name = name;
        HP = hp;
        Damage = damage;
    }

    public void Attack(Player player)
    {
        Console.WriteLine($"{Name} атакує!");

        player.HP -= Damage;

        if (player.HP < 0)
            player.HP = 0;

        Console.WriteLine(
            $"{Name} завдав {Damage} шкоди."
        );
    }
}


// ==================== WEAPON ====================

class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }
}


// ==================== ITEM ====================

class Item
{
    public string Name { get; set; }
    public int Value { get; set; }

    public Item(string name, int value)
    {
        Name = name;
        Value = value;
    }
}


// ==================== QUEST ====================

class Quest
{
    public string Name { get; set; }
    public bool IsCompleted { get; set; }

    public Quest(string name)
    {
        Name = name;
        IsCompleted = false;
    }
}


// ==================== INVENTORY ====================

class Inventory
{
    public List<Item> Items { get; set; }

    public Inventory()
    {
        Items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
        Console.WriteLine($"Отримано: {item.Name}");
    }
}


// ==================== PROGRAM ====================

class Program
{
    static void Main()
    {
        // Створення гравця
        Player player = new Player("Knight");

        // Додавання зілля
        player.Inventory.Add(
            new Item("Health Potion", 30)
        );

        // Створення черги ворогів
        Queue<Enemy> enemies = new Queue<Enemy>();

        enemies.Enqueue(
            new Enemy("Goblin", 60, 10)
        );

        enemies.Enqueue(
            new Enemy("Orc", 100, 15)
        );

        enemies.Enqueue(
            new Enemy("Skeleton", 50, 8)
        );

        // Множина виконаних квестів
        HashSet<string> completedQuests =
            new HashSet<string>();

        // Зброя
        Weapon sword = new Weapon("Sword", 20);
        Weapon axe = new Weapon("Axe", 30);

        player.CurrentWeapon = sword;

        // Основний цикл гри
        while (player.HP > 0 && enemies.Count > 0)
        {
            Enemy enemy = enemies.Peek();

            Console.Clear();

            Console.WriteLine("=== RPG BATTLE ===\n");

            Console.WriteLine(
                $"Гравець: {player.Name}"
            );

            Console.WriteLine(
                $"HP: {player.HP}"
            );

            Console.WriteLine(
                $"Зброя: {player.CurrentWeapon.Name}"
            );

            Console.WriteLine();

            Console.WriteLine(
                $"Ворог: {enemy.Name}"
            );

            Console.WriteLine(
                $"HP: {enemy.HP}"
            );

            Console.WriteLine();

            Console.WriteLine("1. Атакувати");
            Console.WriteLine("2. Використати зілля");
            Console.WriteLine("3. Змінити зброю");
            Console.WriteLine("4. Показати характеристики");
            Console.WriteLine("0. Вийти");

            Console.Write("\nВаш вибір: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    player.Attack(enemy);

                    // Якщо ворог помер
                    if (enemy.HP <= 0)
                    {
                        Console.WriteLine(
                            $"{enemy.Name} переможений!"
                        );

                        enemies.Dequeue();

                        // Завершення квесту
                        if (enemies.Count == 0)
                        {
                            completedQuests.Add(
                                "Defeat all enemies"
                            );
                        }
                    }
                    else
                    {
                        // Ворог атакує у відповідь
                        enemy.Attack(player);
                    }

                    Console.ReadKey();
                    break;


                case "2":
                    player.UsePotion();

                    Console.ReadKey();
                    break;


                case "3":
                    if (player.CurrentWeapon == sword)
                    {
                        player.CurrentWeapon = axe;
                    }
                    else
                    {
                        player.CurrentWeapon = sword;
                    }

                    Console.WriteLine(
                        $"Ви взяли: {player.CurrentWeapon.Name}"
                    );

                    Console.ReadKey();
                    break;


                case "4":
                    player.ShowStats();

                    Console.WriteLine(
                        $"\nВиконаних квестів: {completedQuests.Count}"
                    );

                    Console.ReadKey();
                    break;


                case "0":
                    Console.WriteLine(
                        "Ви вийшли з гри."
                    );

                    return;


                default:
                    Console.WriteLine(
                        "Невірний вибір!"
                    );

                    Console.ReadKey();
                    break;
            }
        }

        Console.Clear();

        if (player.HP <= 0)
        {
            Console.WriteLine("=== GAME OVER ===");
            Console.WriteLine("Ви загинули.");
        }
        else
        {
            Console.WriteLine("=== VICTORY ===");
            Console.WriteLine(
                "Ви перемогли!"
            );

            Console.WriteLine(
                $"Виконаний квест: Defeat all enemies"
            );
        }

        Console.ReadKey();
    }
}
