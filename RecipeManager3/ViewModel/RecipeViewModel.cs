using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using RecipeManager3.Model.Entity;
using RecipeManager3.Model.Repository;

namespace RecipeManager3.ViewModel
{
    class RecipeViewModel : RM3ViewModel
    {
        RecipeRepository repository = new RecipeRepository();

        Recipe recipe;
        bool deleted;

        public RecipeViewModel()
        {
            this.Quantities = new ObservableCollection<RecipeIngredientQuantity>();
            this.Recipe = this.repository.Create();
        }

        public Recipe Recipe
        {
            get { return this.recipe; }
            set
            {
                this.recipe = value;
                this.Id = this.recipe.RecipeId;
                this.Name = this.recipe.Name;
                this.Description = this.recipe.Description;
                this.Quantities.Clear();
                foreach (var q in this.repository.GetRecipeIngredientQuantities(this.Recipe))
                {
                    this.Quantities.Add(q);
                }
                this.Deleted = false;
            }
        }

        public bool Deleted {
            get { return this.deleted; }
            set
            {
                if (this.deleted == value) return;
                this.deleted = value;
                this.NotifyPropertyChanged("Deleted");
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ObservableCollection<RecipeIngredientQuantity> Quantities { get; set; }

        public void Add(IEnumerable<IngredientViewModel> items)
        {
            foreach (var item in items)
            {
                if (!this.Quantities.Any(ri => ri.IngredientId == item.Id))
                {
                    this.Quantities.Add(new RecipeIngredientQuantity() { Ingredient = item.Ingredient, IngredientId = item.Id });
                }
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(() => this.SaveExecute());
            }
        }

        private void SaveExecute()
        {
            this.Recipe.Name = this.Name;
            this.Recipe.Description = this.Description;
            foreach (var q in this.Quantities)
            {
                this.Recipe.RecipeIngredientQuantities.Add(new RecipeIngredientQuantity()
                {
                    Ingredient = q.Ingredient,
                    Quantity = q.Quantity,
                    Unit = q.Unit
                });
            }
            this.repository.AddOrUpdate(this.Recipe);
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(() => this.DeleteExecute());
            }
        }

        private void DeleteExecute()
        {
            if (this.repository.Exists(this.Recipe))
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?",
                                                          "Delete",
                                                          System.Windows.MessageBoxButton.YesNo);
                if (result != MessageBoxResult.Yes) return;

                this.repository.Delete(this.Recipe);

                this.Deleted = true;

                this.Recipe = this.repository.Create();
            }
        }
    }
}
