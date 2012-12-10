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
    }
}
