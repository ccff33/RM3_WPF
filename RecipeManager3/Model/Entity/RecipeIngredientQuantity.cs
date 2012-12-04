using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RecipeManager3.Model.Entity
{
    class RecipeIngredientQuantity
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
    }
}
