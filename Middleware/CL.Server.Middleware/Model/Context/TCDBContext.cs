using CL.Server.Middleware.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CL.Server.Middleware.Model.Context
{
  public class TCDBContext : DbContext
  {
    private readonly string dbConnectionString;
    public TCDBContext(string dbConnectionString)
    {
      this.dbConnectionString = dbConnectionString;
    }

    public TCDBContext(DbContextOptions<TCDBContext> options) : base(options) { }
    public DbSet<ticket> Ticket { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //string dbConnectionString = "server=localhost; port=3306; database=ticket_db; user=root; password=123!; Persist Security Info=false;";
      optionsBuilder.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ticket>(entity =>
      {
        entity.HasKey("idTicket");
      });
    }
  }
}
