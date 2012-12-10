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

        public void SearchExecute(string searchText)
        {
            this.List.Clear();
            this.List.AddIngredientRange(this.repository.GetWithNameLike(searchText));
        }
    }

    /// <summary>
    /// A collection that removes an item on Deleted property changes to true.
    /// </summary>
    /// <remarks>
    /// I don't like this solution either.
    /// </remarks>
    class OCIngredients : ObservableCollection<IngredientViewModel>
    {

        public void AddIngredientRange(IEnumerable<Ingredient> list)
        {
            foreach (var ingredient in list)
            {
                var item = new IngredientViewModel { Ingredient = ingredient };
                this.Add(item);
            }
        }

        protected override void InsertItem(int index, IngredientViewModel item)
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
                if (((IngredientViewModel)sender).Deleted)
                {
                    this.Remove((IngredientViewModel)sender);
                }
            }
        }
    }
}
