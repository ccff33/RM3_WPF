using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using RecipeManager3.Model.Entity;
using RecipeManager3.Model.Repository;

namespace RecipeManager3.ViewModel
{
    class RecipeListViewModel : RM3ViewModel
    {
        RecipeRepository repository = new RecipeRepository();

        public RecipeListViewModel()
        {
            this.List = new OCRecipes();
            this.SearchText = "";
        }

        public OCRecipes List { get; set; }

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
            this.List.AddRecipeRange(this.repository.GetWithNameLike(searchText));
        }
    }

    class OCRecipes : ObservableViewModelCollection<RecipeViewModel>
    {
        public void AddRecipeRange(IEnumerable<Recipe> list)
        {
            foreach (var recipe in list)
            {
                var item = new RecipeViewModel { Recipe =  recipe};
                this.Add(item);
            }
        }
    }
}
