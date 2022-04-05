using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RecipeApplication.Data;

namespace RecipeApplication.Models
{
    public class CreateRecipeCommand:EditRecipeBase
    {
        public IList<CreateIngredientCommand> Ingredients { get; set; }

        public Recipe ToRecipe()
        {
            return new Recipe
            {
                Name = Name,
                TimeToCook = new TimeSpan(TimeToCookHrs,TimeToCookMins,0),
                Method = Method,
                IsVegeterian = IsVegetarian,
                IsVegan = IsVegan,
                Ingredients = Ingredients?.Select(x=>x.ToIngredient()).ToList()

            };
        }
        
        
    }
}