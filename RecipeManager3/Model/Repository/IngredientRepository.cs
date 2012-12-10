using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecipeManager3.Model.Entity;

namespace RecipeManager3.Model.Repository
{
    class IngredientRepository : Repository<RM3Context, Ingredient>
    {
        public override bool Exists(Ingredient e)
        {
            return this.Find(e.IngredientId) != null;
        }

        public IEnumerable<Ingredient> GetWithNameLike(string name)
        {
            using (var context = this.Context())
            {
                var result = from i in context.Ingredients
                             where i.Name.Contains(name)
                             select i;
                return result.ToList();
            }
        }
    }
}
