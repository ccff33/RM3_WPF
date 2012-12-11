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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RecipeManager3.ViewModel;

namespace RecipeManager3.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddIngredientWindow(object sender, RoutedEventArgs e)
        {
            new IngredientView().Show();
        }

        private void AddRecipeWindow(object sender, RoutedEventArgs e)
        {
            new RecipeView().Show();
        }

        private void SearchIngredientWindow(object sender, RoutedEventArgs e)
        {
            new IngredientListView().Show();
        }

        private void SearchRecipeWindow(object sender, RoutedEventArgs e)
        {
            new RecipeListView().Show();
        }
    }
}
