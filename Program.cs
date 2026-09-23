using System;
using System.Collections.Generic;

namespace RPG_Battle
{
    class Program
    {
        static void Main()
        {
            Player player = new Player("Knight");

            player.Inventory.Add(
                new Item(
                    "Health Potion",
                    "Potion",
                    30,
                    50
                )
            );

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

            HashSet<string> completedQuests =
                new HashSet<string>();

            Quest quest = new Quest(
                "Defeat all enemies"
            );

            Weapon sword = new Weapon(
                "Sword",
                20,
                100,
                "Melee"
            );

            Weapon axe = new Weapon(
                "Axe",
                30,
                80,
                "Melee"
            );

            player.CurrentWeapon = sword;

            int choice = 0;

            while (
                player.HP > 0 &&
                enemies.Count > 0 &&
                choice != 0
            )
            {
                Enemy enemy = enemies.Peek();

                Console.Clear();

                Console.WriteLine("=== RPG BATTLE ===");
                Console.WriteLine();

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

                choice = Convert.ToInt32(
                    Console.ReadLine()
                );

                switch (choice)
                {
                    case 1:
                        player.Attack(enemy);

                        if (enemy.HP <= 0)
                        {
                            Console.WriteLine(
                                $"{enemy.Name} переможений!"
                            );

                            enemies.Dequeue();

                            if (enemies.Count == 0)
                            {
                                quest.IsCompleted = true;

                                completedQuests.Add(
                                    quest.Name
                                );
                            }
                        }
                        else
                        {
                            enemy.Attack(player);
                        }

                        Console.ReadKey();
                        break;

                    case 2:
                        player.UsePotion();

                        Console.ReadKey();
                        break;

                    case 3:
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

                    case 4:
                        player.ShowStats();

                        Console.WriteLine(
                            $"\nВиконаних квестів: " +
                            $"{completedQuests.Count}"
                        );

                        Console.ReadKey();
                        break;

                    case 0:
                        Console.WriteLine(
                            "Ви вийшли з гри."
                        );

                        break;

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
            else if (enemies.Count == 0)
            {
                Console.WriteLine("=== VICTORY ===");
                Console.WriteLine(
                    "Ви перемогли всіх ворогів!"
                );

                Console.WriteLine(
                    $"Виконаний квест: {quest.Name}"
                );
            }
            else
            {
                Console.WriteLine(
                    "Гру завершено."
                );
            }

            Console.ReadKey();
        }
    }
}
