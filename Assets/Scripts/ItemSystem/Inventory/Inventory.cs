using System.Collections.Generic;
using OOP.ItemSystem.Items;

namespace OOP.ItemSystem.Inventory
{
    public class Inventory
    {
        public IReadOnlyList<Item> Slots => _slots;

        private readonly List<Item> _slots = new List<Item>();

        public void AddItem(Item item)
        {
            _slots.Add(item);
        }

        public void ConsumeItem(Item item)
        {
            _slots.Remove(item);
        }

        public T GetItemWithType<T>() where T : Item
        {
            foreach (Item item in _slots)
            {
                if (item is T itemWithType)
                    return itemWithType;
            }

            return null;
        }
    }
}
