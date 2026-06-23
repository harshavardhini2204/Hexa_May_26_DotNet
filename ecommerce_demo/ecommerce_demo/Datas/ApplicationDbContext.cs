using ecommerce_demo.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_demo.Datas
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey(e => e.CategoryId);
                e.Property(e => e.CategoryName).HasMaxLength(100).IsRequired();
                e.Property(e => e.Description).HasMaxLength(500);


            });
            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(e => e.ProductId);
                e.Property(e => e.ProductName).HasMaxLength(100).IsRequired();
                e.Property(e => e.Price).HasColumnType("decimal(18,2)");
                e.Property(e => e.ImageUrl).HasMaxLength(500);
                e.HasOne(c => c.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);

            });
        }
    }
}
