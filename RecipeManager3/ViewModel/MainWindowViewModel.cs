using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RecipeManager3.Model;
using RecipeManager3.Model.Repository;

namespace RecipeManager3.ViewModel
{
    class MainWindowViewModel : RM3ViewModel
    {

        int recipeCount;
        int ingredientCount;

        RecipeRepository recipeRepository = new RecipeRepository();
        IngredientRepository ingredientRepository = new IngredientRepository();

        public MainWindowViewModel()
        {
            Thread updateCounts = new Thread(this.UpdateCounts);
            updateCounts.Start();
        }

        public int RecipeCount
        {
            get { return this.recipeCount; }

            set
            {
                if (value == this.recipeCount) return;
                this.recipeCount = value;
                this.NotifyPropertyChanged("RecipeCount");
            }
        }

        public int IngredientCount
        {
            get { return this.ingredientCount; }

            set
            {
                if (value == this.ingredientCount) return;
                this.ingredientCount = value;
                this.NotifyPropertyChanged("IngredientCount");
            }
        }

        private void UpdateCounts()
        {
            while (true)
            {
                this.RecipeCount = this.recipeRepository.Count();
                this.IngredientCount = this.ingredientRepository.Count();
                Thread.Sleep(1000);
            }
        }
    }
}
