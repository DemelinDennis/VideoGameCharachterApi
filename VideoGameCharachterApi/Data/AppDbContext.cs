using Microsoft.EntityFrameworkCore;
using VideoGameCharachterApi.Models;

namespace VideoGameCharachterApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
            public DbSet<Charachter> Charachters => Set<Charachter>(); 
    }
}
