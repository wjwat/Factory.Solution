using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class FactoryContext : DbContext
  {
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<EngineerMachine> EngineerMachine { get; set; }

    public FactoryContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }

    // Rather than have an auto-incrementing primary key in our join table
    // we're using the primary keys representing the relationship
    // (EngineerId, MachineId) as the key. This allows us to avoid creating
    // duplicate entries in our join table. Without too much extra code.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<EngineerMachine>().HasKey(em => new {
        em.EngineerId,
        em.MachineId
      });
    }
  }
}
