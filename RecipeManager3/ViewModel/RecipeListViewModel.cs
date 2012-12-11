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

    class OCRecipes : ObservableCollection<RecipeViewModel>
    {

        public void AddRecipeRange(IEnumerable<Recipe> list)
        {
            foreach (var recipe in list)
            {
                var item = new RecipeViewModel { Recipe =  recipe};
                this.Add(item);
            }
        }

        protected override void InsertItem(int index, RecipeViewModel item)
        {
            base.InsertItem(index, item);
            item.PropertyChanged += ItemPropertyChanged;
        }

        protected override void RemoveItem(int index)
        {
            this.ElementAt(index).PropertyChanged -= ItemPropertyChanged;
            base.RemoveItem(index);
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Deleted")
            {
                if (((RecipeViewModel)sender).Deleted)
                {
                    this.Remove((RecipeViewModel)sender);
                }
            }
        }
    }
}
