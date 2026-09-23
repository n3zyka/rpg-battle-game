using System;
using System.Collections.Generic;

namespace RPG_Battle
{
    public class Inventory
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
}
