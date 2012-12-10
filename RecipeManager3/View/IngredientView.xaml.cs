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
    /// Interaction logic for IngredientView.xaml
    /// </summary>
    public partial class IngredientView : Window
    {
        public IngredientView()
        {
            InitializeComponent();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
