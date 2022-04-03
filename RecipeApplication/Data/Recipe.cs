﻿using System;
using System.Collections.Generic;

namespace RecipeApplication.Data
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public TimeSpan TimeToCook { get; set; }
        public bool IsDeleted { get; set; }
        public string Method { get; set; }
        public bool IsVegan { get; set; }
        public bool IsVegeterian { get; set; }  
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}