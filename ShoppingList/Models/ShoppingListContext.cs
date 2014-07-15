using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ShoppingList.Models.Mapping;

namespace ShoppingList.Models
{
    public partial class ShoppingListContext : DbContext
    {
        static ShoppingListContext()
        {
            Database.SetInitializer<ShoppingListContext>(null);
        }

        public ShoppingListContext()
            : base("Name=ShoppingListContext")
        {
        }

        public DbSet<List> Lists { get; set; }
        public DbSet<ListItem> ListItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ListMap());
            modelBuilder.Configurations.Add(new ListItemMap());
        }
    }
}
