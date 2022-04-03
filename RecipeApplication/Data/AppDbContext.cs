using Microsoft.EntityFrameworkCore;

namespace RecipeApplication.Data
{
   
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions):base(contextOptions)
        {
            
        }
        
        public DbSet<Recipe> Recipes { get; set; }
    }
   
    
}