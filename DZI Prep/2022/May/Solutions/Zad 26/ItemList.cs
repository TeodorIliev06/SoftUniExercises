using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_26
{
    public class ItemList
    {
        public List<Item> Items { get; set; } = new List<Item>();

        public int Count => Items.Count;

        public Item Get(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            return this.Items[index];
        }

        public void Add(Item item)
        {
            if (this.Items.Contains(item))
            {
                throw new InvalidOperationException();
            }

            this.Items.Add(item);
            this.Items = this.Items.OrderBy(i => i.Description).ToList();
        }
    }
}
