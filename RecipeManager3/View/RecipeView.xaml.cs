using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RecipeManager3.ViewModel;

namespace RecipeManager3.View
{
    /// <summary>
    /// Interaction logic for RecipeView.xaml
    /// </summary>
    public partial class RecipeView : Window
    {
        public RecipeView()
        {
            InitializeComponent();
        }

        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddSelectedIngredients(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as RecipeViewModel;
            List<IngredientViewModel> selected = new List<IngredientViewModel>();
            foreach (var s in this.ingredientList.SelectedItems)
            {
                selected.Add(s as IngredientViewModel);
            }
            viewModel.Add(selected);
        }
    }
}
