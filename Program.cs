using System;
using System.Collections.Generic;

class Quest
{
    public string Name;
    public bool Completed;

    public Quest(string name)
    {
        Name = name;
        Completed = false;
    }
}

class Inventory
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
    }
}

class Program
{
    static void Main()
    {
        Player player = new Player("Knight");
        Enemy goblin = new Enemy("Goblin", 60, 10);

        List<Item> inventory = new List<Item>();
        inventory.Add(new Item("Health Potion", 30));

        Dictionary<string, int> stats = new Dictionary<string, int>();
        stats["Strength"] = 10;
        stats["Defense"] = 5;

        Queue<Enemy> enemies = new Queue<Enemy>();
        enemies.Enqueue(goblin);

        HashSet<string> completedQuests = new HashSet<string>();

        Quest quest = new Quest("Defeat Goblin");

        int choice = 0;

        while (choice != 0 && player.HP > 0 && enemies.Count > 0)
        {
            Enemy enemy = enemies.Peek();

            Console.Clear();

            Console.WriteLine("=== RPG BATTLE ===");
            Console.WriteLine();
            Console.WriteLine("Гравець: " + player.Name);
            Console.WriteLine("HP: " + player.HP);
            Console.WriteLine("Зброя: " + player.CurrentWeapon.Name);
            Console.WriteLine();
            Console.WriteLine("Ворог: " + enemy.Name);
            Console.WriteLine("HP: " + enemy.HP);
            Console.WriteLine();

            Console.WriteLine("1. Атакувати");
            Console.WriteLine("2. Використати зілля");
            Console.WriteLine("3. Змінити зброю");
            Console.WriteLine("4. Показати характеристики");
            Console.WriteLine("0. Вийти");

            Console.Write("Ваш вибір: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                player.Attack(enemy);

                if (enemy.HP <= 0)
                {
                    Console.WriteLine("Goblin переможений!");
                    enemies.Dequeue();

                    quest.Completed = true;
                    completedQuests.Add(quest.Name);
                }
                else
                {
                    enemy.Attack(player);
                }

                Console.ReadKey();
            }

            if (choice == 2)
            {
                if (inventory.Count > 0)
                {
                    player.HP += inventory[0].Value;

                    if (player.HP > 100)
                    {
                        player.HP = 100;
                    }

                    Console.WriteLine("Ви використали зілля.");
                    inventory.RemoveAt(0);
                }
                else
                {
                    Console.WriteLine("Зіль немає.");
                }

                Console.ReadKey();
            }

            if (choice == 3)
            {
                if (player.CurrentWeapon.Name == "Sword")
                {
                    player.CurrentWeapon = new Weapon("Axe", 30);
                }
                else
                {
                    player.CurrentWeapon = new Weapon("Sword", 20);
                }

                Console.WriteLine(
                    "Ви змінили зброю на " +
                    player.CurrentWeapon.Name
                );

                Console.ReadKey();
            }

            if (choice == 4)
            {
                Console.WriteLine();
                Console.WriteLine("=== ХАРАКТЕРИСТИКИ ===");
                Console.WriteLine("Strength: " + stats["Strength"]);
                Console.WriteLine("Defense: " + stats["Defense"]);
                Console.WriteLine("Предметів: " + inventory.Count);
                Console.WriteLine("Виконаних квестів: " + completedQuests.Count);

                Console.ReadKey();
            }
        }

        if (player.HP <= 0)
        {
            Console.WriteLine("Ви програли!");
        }
        else if (enemies.Count == 0)
        {
            Console.WriteLine("Ви перемогли!");
        }
        else
        {
            Console.WriteLine("Гру завершено.");
        }
    }
}
