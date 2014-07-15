using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ShoppingList.Models.Mapping
{
    public class ListItemMap : EntityTypeConfiguration<ListItem>
    {
        public ListItemMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(1600);

            // Table & Column Mappings
            this.ToTable("ListItem");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.List_Id).HasColumnName("List_Id");
            this.Property(t => t.Done).HasColumnName("Done");
            this.HasRequired(t => t.ShoppingList).WithMany(t => t.Items).HasForeignKey(t => t.List_Id);
        }
    }
}
