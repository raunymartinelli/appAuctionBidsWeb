using Assignment1.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assignment1.Models;

namespace Assignment1.Areas.Identity.Data;

public class Assignment1Context : IdentityDbContext<Assignment1User>
{
    public Assignment1Context(DbContextOptions<Assignment1Context> options)
        : base(options) { }

    public DbSet<Bid> Products { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Category>().HasData(
      new Category { CategoryId = 1, CategoryName = "Wheel" },
      new Category { CategoryId = 2, CategoryName = "Engine" },
      new Category { CategoryId = 3, CategoryName = "Brake" },
      new Category { CategoryId = 4, CategoryName = "Spare Parts" }
      );

        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

    }

    internal void SavedChanges()
    {
        throw new NotImplementedException();
    }
}
