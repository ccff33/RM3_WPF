using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows;
using RecipeManager3.View;
using RecipeManager3.Model.Entity;
using RecipeManager3.Model.Repository;

namespace RecipeManager3.ViewModel
{
    class IngredientListViewModel : RM3ViewModel
    {
        IngredientRepository repository = new IngredientRepository();

        public IngredientListViewModel()
        {
            this.List = new OCIngredients();
            this.SearchText = "";
        }

        public OCIngredients List { get; set; }

        public string SearchText { get; set; }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(() => this.SearchExecute(this.SearchText));
            }
        }

        private void SearchExecute(string searchText)
        {
            this.List.Clear();
            this.List.AddIngredientRange(this.repository.GetWithNameLike(searchText));
        }
    }

    class OCIngredients : ObservableViewModelCollection<IngredientViewModel>
    {
        public void AddIngredientRange(IEnumerable<Ingredient> list)
        {
            foreach (var ingredient in list)
            {
                var item = new IngredientViewModel { Ingredient = ingredient };
                this.Add(item);
            }
        }
    }
}
