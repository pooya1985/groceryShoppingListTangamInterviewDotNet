using System;
using System.Collections.Generic;

namespace ShoppingList.Models
{
    public partial class ListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int List_Id { get; set; }
        public bool Done { get; set; }
        public virtual List ShoppingList { get; set; }
    }
}
