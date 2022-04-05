using System.ComponentModel.DataAnnotations;
using RecipeApplication.Data;

namespace RecipeApplication.Models
{
    public class CreateIngredientCommand
    {
        [Required,StringLength(100)]
        public string Name { get; set; }    
        [Range(0,int.MaxValue)]
        public decimal Quantitiy { get; set; }  
        [StringLength(20)]
        public string Unit { get; set; }

        public Ingredient ToIngredient()
        {
            return new Ingredient
            {
                Name = Name,
                Quantity = Quantitiy,
                Unit = Unit,
            };
        }
        
    }
}