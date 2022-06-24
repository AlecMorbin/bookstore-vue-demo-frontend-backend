using bookstore_vue_demo_backend.Models;
using Microsoft.EntityFrameworkCore;


namespace bookstore_vue_demo_backend.Data
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        /*
        public DbSet<OrderLog> OrderLog { get; set; }
        public DbSet<SellLog> SellLog { get; set; }
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=BookStore;Integrated Security=True");
        }

        //onmodelcreating override
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(b => b.Url)
                .IsRequired();
        }*/
    }
}
