using System;

namespace RPG_Battle
{
    // Базовий клас для гравця і ворогів
    public abstract class Character
    {
        private int hp;

        public string Name { get; protected set; }
        public int MaxHP { get; protected set; }

        public int HP
        {
            get { return hp; }
            protected set
            {
                if (value < 0)
                {
                    hp = 0;
                }
                else if (value > MaxHP)
                {
                    hp = MaxHP;
                }
                else
                {
                    hp = value;
                }
            }
        }

        protected Character(string name, int hp)
        {
            Name = name;
            MaxHP = hp;
            HP = hp;
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
        }

        public void Heal(int amount)
        {
            HP += amount;
        }

        public abstract void Attack(Character target);

        public abstract void ShowInfo();
    }
}
