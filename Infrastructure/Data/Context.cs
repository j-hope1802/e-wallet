using Domain.Entities;

using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    
    public DbSet<Acount> Acounts { get; set; }
    public DbSet<Transaction> Transactions{get;set;}

  

}