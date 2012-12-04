using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeManager3.Model.Entity
{
    class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public ICollection<RecipeIngredientQuantity> RecipeIngredientQuantities { get; set; }

        public Ingredient()
        {
            RecipeIngredientQuantities = new HashSet<RecipeIngredientQuantity>();
        }
    }
}
