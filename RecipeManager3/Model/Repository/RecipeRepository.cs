using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecipeManager3.Model.Entity;

namespace RecipeManager3.Model.Repository
{
    class RecipeRepository : Repository<RM3Context, Recipe>
    {
        public override bool Exists(Recipe e)
        {
            return this.Find(e.RecipeId) != null;
        }

        public IEnumerable<RecipeIngredientQuantity> GetRecipeIngredientQuantities(Recipe recipe)
        {
            using (var context = this.Context())
            {
                var queriable = from ri in context.RecipeIngredientQuantities.Include("Ingredient")
                                where ri.RecipeId == recipe.RecipeId
                                select ri;

                return queriable.ToList();
            }
        }

        public IEnumerable<Recipe> GetWithNameLike(string name)
        {
            using (var context = this.Context())
            {
                var result = from r in context.Recipes
                             where r.Name.Contains(name)
                             select r;
                return result.ToList();
            }
        }

        public override void Update(Recipe e)
        {
            //Sorry to say, I couldn't make it update by just attaching to the current context
            //spent a couple of hours here
            //at leasts it works
            #region Hell, no
            using (var context = this.Context())
            {
                foreach (var r in context.RecipeIngredientQuantities.Where(ri => ri.RecipeId == e.RecipeId))
                {
                    context.RecipeIngredientQuantities.Remove(r);
                }
                Recipe recipe = context.Recipes.Find(e.RecipeId);
                recipe.Name = e.Name;
                recipe.Description = e.Description;
                foreach (var ri in e.RecipeIngredientQuantities)
                {
                    Ingredient i = context.Ingredients.Find(ri.Ingredient.IngredientId);
                    recipe.RecipeIngredientQuantities.Add(new RecipeIngredientQuantity() {
                        Ingredient = i,
                        Quantity = ri.Quantity,
                        Unit = ri.Unit
                    });
                }
                context.Entry(recipe).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
            #endregion
        }

        public override void Add(Recipe e)
        {
            using (var context = this.Context())
            {
                context.Recipes.Add(e);
                foreach (var ri in e.RecipeIngredientQuantities)
                {
                    context.Ingredients.Attach(ri.Ingredient);
                }
                context.SaveChanges();
            }
        }
    }
}
