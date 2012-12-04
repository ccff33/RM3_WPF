using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Data.Entity;
using RecipeManager3.Model;
using RecipeManager3.Model.Entity;

namespace RecipeManager3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Database.SetInitializer<RM3Context>(new RM3ContextInitializer());
            base.OnStartup(e);
        }
    }
}
