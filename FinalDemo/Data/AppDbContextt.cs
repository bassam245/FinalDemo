using FinalDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalDemo.Data
{
    public class AppDbContextt : DbContext
    {
        public AppDbContextt(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Order> orders { get; set; }


        public DbSet<User>  users { get; set; }

        public DbSet<Category>  categories { get; set; }
        public DbSet<Product>  products { get; set; }

        public DbSet<OrderItem>  Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasMany(s => s.products).WithOne(s => s.category).HasForeignKey(s => s.categoryId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>().HasMany(s => s.orders).WithOne(s => s.user).HasForeignKey(s => s.userid).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>().HasMany(s => s.items).WithOne(s => s.order).HasForeignKey(s => s.orderId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>().HasMany(s => s.items).WithOne(s => s.product).HasForeignKey(s => s.productid).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasData(
    new User
    {
        Id = 1,
        FullName = "Ahmed Hassan",
        Email = "ahmed@example.com",
        PasswordHash = "123456A",
        Role = "Customer"
    },
    new User
    {
        Id = 2,
        FullName = "Mona Ali",
        Email = "mona@example.com",
        PasswordHash = "123456M",
        Role = "Customer"
    },
    new User
    {
        Id = 3,
        FullName = "Store Admin",
        Email = "admin@example.com",
        PasswordHash = "123456Adm",
        Role = "Admin"
    }
);

            modelBuilder.Entity<Category>().HasData(
    new Category
    {
        Id = 1,
        Name = "Electronics",
        Description = "Electronic devices and accessories"
    },
    new Category
    {
        Id = 2,
        Name = "Books",
        Description = "Programming and technical books"
    },
    new Category
    {
        Id = 3,
        Name = "Accessories",
        Description = "Everyday computer accessories"
    }
);

modelBuilder.Entity<Product>().HasData(
    new Product
    {
        Id = 1,
        Name = "Wireless Mouse",
        Description = "Wireless computer mouse",
        price = 450.00m,
        stockquantity = 25,
        categoryId = 3
    },
    new Product
    {
        Id = 2,
        Name = "Headphones",
        Description = "High quality headphones",
        price = 1200.00m,
        stockquantity = 12,
        categoryId = 1
    },
    new Product
    {
        Id = 3,
        Name = "C++ Fundamentals",
        Description = "Programming book for C++ beginners",
        price = 350.00m,
        stockquantity = 30,
        categoryId = 2
    }
);


            modelBuilder.Entity<Order>().HasData(
    new Order
    {
        Id = 1,
        OrderDate = new DateTime(2026, 10, 1),
        Status = "Completed",
         TotallAmount = 800.00m,
         userid = 1
    },
    new Order
    {
        Id = 2,
        OrderDate = new DateTime(2026, 10, 10),
        Status = "Pending",
         TotallAmount = 1200.00m,
         userid = 2
    },
    new Order
    {
        Id = 3,
        OrderDate = new DateTime(2026, 10, 12),
        Status = "Cancelled",
         TotallAmount = 350.00m,
         userid = 1
    }
);
            modelBuilder.Entity<OrderItem>().HasData(
    new OrderItem
    {
        Id = 1,
         orderId = 1,
         productid = 1,
         quantity = 1,
         unitprice = 450.00m
    },
    new OrderItem
    {
        Id = 2,
         orderId = 3,
         productid = 3,
         quantity = 1,
         unitprice = 350.00m
    },
    new OrderItem
    {
        Id = 3,
         orderId = 2,
         productid = 2,
         quantity = 1,
         unitprice = 1200.00m
    }
);
        }

    }
}
