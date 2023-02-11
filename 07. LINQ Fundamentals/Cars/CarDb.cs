using Microsoft.EntityFrameworkCore;

namespace Cars;

public class CarDb : DbContext
{
    public CarDb(DbContextOptions<CarDb> options) : base(options)
    {
    }
    public DbSet<Car> Cars { get; set; }
    // public DbSet<Manufacturer> Manufacturers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(@"Server=.;Database=Cars;User Id=sa;Password=Manager2017;TrustServerCertificate=true;");
    }
}
