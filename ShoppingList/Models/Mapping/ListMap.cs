using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ShoppingList.Models.Mapping
{
    public class ListMap : EntityTypeConfiguration<List>
    {
        public ListMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("List");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.Creator_Id).HasColumnName("Creator_Id");
            this.HasRequired(t => t.Creator).WithMany(t => t.Lists).HasForeignKey(d => d.Creator_Id);
        }
    }
}
