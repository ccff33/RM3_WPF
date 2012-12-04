using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RecipeManager3.Model.Entity;

namespace RecipeManager3.Model
{
    class RM3Context : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredientQuantity> RecipeIngredientQuantities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeIngredientQuantity>()
                                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });
        }
    }
}
