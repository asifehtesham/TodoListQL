using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TodoListQL.Models;

namespace TodoListQL.Data
{
    public class ApiDbContext: DbContext
    {
        public virtual DbSet<ItemDto> Items { get; set; }
        public virtual DbSet<ItemListDto> Lists { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ItemDto>(e =>
            {
                e.HasOne(d => d.ItemList)
                .WithMany(p => p.Items)
                .HasForeignKey(d => d.ListId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ItemDto_ItemList");
            });
        }
        
    }
}
