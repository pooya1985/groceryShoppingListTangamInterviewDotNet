using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList.Models
{
    public partial class List
    {
        public List()
        {
            Items = new List<ListItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int Creator_Id { get; set; }

        public int RemainedItems
        {
            get { return Items.Count(t => !t.Done); }
        }

        public virtual UserProfile Creator { get; set; }
        public virtual List<ListItem> Items { get; set; }
    }
}
