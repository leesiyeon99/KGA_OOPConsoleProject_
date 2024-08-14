using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Items;

namespace RPG
{
    public class Inventory
    {
        public static List<Item> items;
        const int MAX = 5;
        Item Item;

        public Inventory()
        {
           items = new List<Item>(MAX);
        }

        public void ShowAllItem()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("아이템 목록: 없음");
            }
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].name}");
                Console.WriteLine($"가격: {items[i].cost}");
                Console.WriteLine($"설명: {items[i].explain}");
                Console.WriteLine();
            }
        }

        public bool AddItem(Item item)
        {
            if (items.Count >= MAX)
            {
                return false;
            }

            items.Add(item);
            return true;

        }


        public bool RemoveItem(Item item)
        {
            return items.Remove(item);
        }
    }
}
