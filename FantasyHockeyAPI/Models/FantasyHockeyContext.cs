using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FantasyHockeyAPI.Models{
    
    public class FantasyHockeyContext : DbContext{

        public FantasyHockeyContext(DbContextOptions<FantasyHockeyContext> options) : base(options){}

        public DbSet<LeagueItem> LeagueItem {get; set;}
    }
}