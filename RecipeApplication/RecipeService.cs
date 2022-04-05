using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeApplication.Data;
using RecipeApplication.Models;

namespace RecipeApplication
{
    public class RecipeService
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public RecipeService(AppDbContext context, ILoggerFactory factory)
        {
            _context = context;
            _logger = factory.CreateLogger<RecipeService>();
        }
        
        /// <summary>
        /// Create a new recipe
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>The id of the new recipe</returns>
        public async Task<int> CreateRecipe(CreateRecipeCommand cmd)
        {
            var recipe = cmd.ToRecipe();
            _context.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe.RecipeId;
        }

        public async Task<RecipeDetailViewModel> GetRecipeDetail(int recipeId)
        {
            return await _context.Recipes
                .Where(x => x.RecipeId == recipeId)
                .Where(x => !x.IsDeleted)
                .Select(x => new RecipeDetailViewModel
                {
                    Name = x.Name,
                    Id = x.RecipeId,
                    Method = x.Method,
                    Ingredients = x.Ingredients
                        .Select(item => new RecipeDetailViewModel.Item
                        {

                            Name = item.Name,
                            Quantity = $"{item.Quantity} {item.Unit}"

                        })


                })
                .SingleOrDefaultAsync();

        }
    }
}