using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using RecipeManager3.Model.Entity;
using RecipeManager3.Model.Repository;

namespace RecipeManager3.ViewModel
{
    class IngredientViewModel : RM3ViewModel
    {
        IngredientRepository repository = new IngredientRepository();

        Ingredient ingredient;
        string name;
        int id;
        bool deleted;

        public IngredientViewModel()
        {
            this.Ingredient = this.CreateNew();
            this.Deleted = false;
        }

        public Ingredient Ingredient
        {
            get { return this.ingredient; }
            set
            {
                this.ingredient = value;
                this.Name = this.ingredient.Name;
                this.Id = this.ingredient.IngredientId;
                this.NotifyPropertyChanged("Ingredient");
            }
        }

        public string Name
        {
            get { return this.name; }
            set {
                if (this.name == value) return;
                this.name = value;
                this.NotifyPropertyChanged("Name");
            }
        }

        public int Id {
            get { return this.id; }
            set {
                if (this.id == value) return;
                this.id = value;
                this.NotifyPropertyChanged("Id");
            }
        }

        public bool Deleted
        {
            get { return this.deleted; }
            set
            {
                if (this.deleted == value) return;
                this.deleted = value;
                this.NotifyPropertyChanged("Deleted");
            }
        }

        public ICommand SaveCommand {
            get
            {
                return new RelayCommand(() => this.SaveExecute());
            }
        }

        private void SaveExecute()
        {
            this.Ingredient.Name = this.Name;
            this.repository.AddOrUpdate(Ingredient);
            this.Id = this.Ingredient.IngredientId;
        }
        
        public ICommand DeleteCommand
        {
            get { return new RelayCommand(() => this.DeleteExecute()); }
        }

        private void DeleteExecute()
        {
            if (this.repository.Exists(this.Ingredient))
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?",
                                                          "Delete",
                                                          System.Windows.MessageBoxButton.YesNo);
                if (result != MessageBoxResult.Yes) return;

                this.repository.Delete(this.Ingredient);

                this.Deleted = true;

                this.Ingredient = this.CreateNew();
            }
        }

        public ICommand ResetCommand
        {
            get { return new RelayCommand(() => this.ResetExecute()); }
        }

        private void ResetExecute()
        {
            this.Name = this.Ingredient.Name;
        }

        private Ingredient CreateNew()
        {
            return this.repository.Create();
        }
    }
}
