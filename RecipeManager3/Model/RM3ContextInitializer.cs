using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RecipeManager3.Model.Entity;

namespace RecipeManager3.Model
{
    class RM3ContextInitializer : DropCreateDatabaseAlways<RM3Context>
    {
        protected override void Seed(RM3Context context)
        {
            Ingredient eggs = new Ingredient { Name = "яйца" };
            Ingredient oil = new Ingredient { Name = "олио" };
            Ingredient onion = new Ingredient { Name = "лук" };
            Ingredient water = new Ingredient { Name = "вода" };
            Ingredient rice = new Ingredient { Name = "ориз" };

            Recipe scrEggs = new Recipe { Name = "бъркани яйца", Description = "описание" };
            Recipe scrEggsWithOnion = new Recipe { Name = "бъркани яйца с лук", Description = "описание с лук" };
            Recipe boiledRice = new Recipe { Name = "варен ориз", Description = "описание" };

            scrEggs.RecipeIngredientQuantities.Add(new RecipeIngredientQuantity
            {
                Ingredient = eggs,
                Recipe = scrEggs,
                Quantity = 4,
                Unit = "брой"
            });

            scrEggs.RecipeIngredientQuantities.Add(new RecipeIngredientQuantity
            {
                Ingredient = oil,
                Recipe = scrEggs,
                Quantity = 50,
                Unit = "мл"
            });

            scrEggsWithOnion.RecipeIngredientQuantities.Add(new RecipeIngredientQuantity
            {
                Ingredient = eggs,
                Recipe = scrEggsWithOnion,
                Quantity = 3,
                Unit = "брой"
            });

            scrEggsWithOnion.RecipeIngredientQuantities.Add(new RecipeIngredientQuantity
            {
                Ingredient = oil,
                Recipe = scrEggsWithOnion,
                Quantity = 50,
                Unit = "мл"
            });

            scrEggsWithOnion.RecipeIngredientQuantities.Add(new RecipeIngredientQuantity
            {
                Ingredient = onion,
                Recipe = scrEggsWithOnion,
                Quantity = 2,
                Unit = "брой"
            });

            boiledRice.RecipeIngredientQuantities.Add(new RecipeIngredientQuantity
            {
                Ingredient = water,
                Recipe = boiledRice,
                Quantity = 1,
                Unit = "л"
            });

            boiledRice.RecipeIngredientQuantities.Add(new RecipeIngredientQuantity
            {
                Ingredient = rice,
                Recipe = boiledRice,
                Quantity = 150,
                Unit = "г"
            });

            context.Recipes.Add(scrEggs);
            context.Recipes.Add(scrEggsWithOnion);
            context.Recipes.Add(boiledRice);

            base.Seed(context);
        }
    }
}
