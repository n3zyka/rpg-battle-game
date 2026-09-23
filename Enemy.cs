using System;

namespace RPG_Battle
{
    public class Enemy
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
            {
                player.HP = 0;
            }

            Console.WriteLine(
                $"{Name} завдав {Damage} шкоди."
            );
        }
    }
}
