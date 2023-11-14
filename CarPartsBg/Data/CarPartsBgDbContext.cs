using CarPartsBg.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarPartsBg.Data;

public class CarPartsBgDbContext : IdentityDbContext<User,IdentityRole<int>,int>
{
    public CarPartsBgDbContext(DbContextOptions<CarPartsBgDbContext> options)
        : base(options)
    {

    }
    public DbSet<Order> Orders { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Request> Requests { get; set; }

    public DbSet<Review> Reviews { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<User>()
        //    .Property(u => u.Name.Length >= 10)
        //    .IsRequired()
        //    .HasMaxLength(50);


        //modelBuilder.Entity<User>()
        //    .HasKey(u=>u.Id);
        //set composite key
        modelBuilder.Entity<Order>()
            .HasKey(o => new { o.Id, o.UserId, o.ProductId });//composite key
        //set foreign key
        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);

        modelBuilder.Entity<Order>()
           .HasOne(o => o.Product)
           .WithMany(u => u.Orders)
           .HasForeignKey(o => o.ProductId);

        //set composite key
        modelBuilder.Entity<Review>()
           .HasKey(r => new { r.Id, r.UserId, r.ProductId });//composite key
        //set foreign key
        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId);

        modelBuilder.Entity<Review>()
           .HasOne(r => r.Product)
           .WithMany(u => u.Reviews)
           .HasForeignKey(r => r.ProductId);

    }
}