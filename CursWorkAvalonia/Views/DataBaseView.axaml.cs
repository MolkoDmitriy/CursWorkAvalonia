using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CursWorkAvalonia.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Avalonia.Interactivity;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
namespace CursWorkAvalonia.Views
{
    public partial class DataBaseView : UserControl
    {
        public DataBaseView()
        {
            InitializeComponent();
            var context = this.DataContext as MainWindowViewModel;
           
           
                
        }
        
        
       
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
