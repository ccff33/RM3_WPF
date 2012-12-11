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
    /// Interaction logic for RecipeListView.xaml
    /// </summary>
    public partial class RecipeListView : Window
    {
        public RecipeListView()
        {
            InitializeComponent();
        }

        private void EditRecipe(object sender, RoutedEventArgs e)
        {
            RecipeView window = new RecipeView();
            window.DataContext = (sender as Button).DataContext;
            window.Show();
        }
    }
}
