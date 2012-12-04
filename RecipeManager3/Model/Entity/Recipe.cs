using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeManager3.Model.Entity
{
    class Recipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<RecipeIngredientQuantity> RecipeIngredientQuantities { get; set; }

        public Recipe()
        {
            RecipeIngredientQuantities = new HashSet<RecipeIngredientQuantity>();
        }
    }
}
