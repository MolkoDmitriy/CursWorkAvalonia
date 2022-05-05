using Avalonia.Media;
using Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using CursWorkAvalonia.Models;
namespace CursWorkAvalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }
        public ObservableCollection<Player> Items { get; set; }
        public MainWindowViewModel()
        {
            Player a1 = new Player("1");
            Player a2 = new Player("2");
            Player a3 = new Player("3");
            Items = new ObservableCollection<Player>() { a1, a2, a3 };
            Content = new DataBaseViewModel();
        }
        public void SQLRequestOpen()
        {
            Content = new SQLRequestViewModel();
        }
        public void SQLRequestRun()
        {
            Content = new DataBaseViewModel();
        }
    }
}
