using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class ApplicationDbContext : DbContext
{
    public DbSet<Property> Properties => Set<Property>();
    public DbSet<Image> Images => Set<Image>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { 
    }
}
