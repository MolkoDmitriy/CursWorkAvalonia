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
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using CursWorkAvalonia.Models;
using System.Collections.Specialized;


namespace CursWorkAvalonia.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        private Request _request;
        public Request SelectedRequest
        {
            get => _request;
            set => this.RaiseAndSetIfChanged(ref _request,value);
        }    
     

        private ObservableCollection<Request> _requests;
        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set => this.RaiseAndSetIfChanged(ref _requests, value);
        }

        public ObservableCollection<Nhlscore> Nhlscores { get; set; }
        public ObservableCollection<Player> Players { get; set; }
        public ObservableCollection<Team> Teams { get; set; }
        public ObservableCollection<TeamsStatistic> TeamsStatistics { get; set; }
        public ObservableCollection<PlayersStatistic> PlayersStatistics { get; set; }

        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }
        
        public MainWindowViewModel()
        {
            //tableNames = new ObservableCollection<TableName>() {
                  //  new TableName("Nhlscore"){Fields = new List<string> {"NhlscoresId","Points","GoalFor","GoalAg","TeamId"}},
                //    new TableName("Player"){Fields = new List<string>{"PlayerId","Name","Age","TeamId"} },
                    //new TableName("PlayerStatistic"){Fields = new List<string>{ "StaticticId","PlayerId","GamePlayed","Pos" ,"Satt","TimeOnIce"} },
                    //new TableName("Team"){Fields = new List<string>{ "TeamId","Name"} },
                    //new TableName("TeamStatistic"){ Fields = new List<string>{ "TeamStatisticId","GamePlayed", "Win", "Lose" ,"TeamId"} }
                    //};
            Players = new ObservableCollection<Player>();
            PlayersStatistics = new ObservableCollection<PlayersStatistic>();
            Teams = new ObservableCollection<Team>();
            TeamsStatistics = new ObservableCollection<TeamsStatistic>();
            Nhlscores = new ObservableCollection<Nhlscore>();
            using(var db = new NHLDataBaseContext())
            {
            
                foreach (var item in db.Players) Players.Add(item);
                foreach (var item in db.PlayersStatistics) PlayersStatistics.Add(item);
                foreach (var item in db.Teams) Teams.Add(item);
                foreach (var item in db.TeamsStatistics) TeamsStatistics.Add(item);
                foreach (var item in db.Nhlscores) Nhlscores.Add(item);
            }
            Content = new DataBaseViewModel();
            Requests = new ObservableCollection<Request>()
            {
                new Request("1")
            };

          
        }
        public void SQLRequestOpen()
        {
            Content = new SQLRequestViewModel();
        }
        public void SQLRequestRun()
        {
            
            using(var db = new NHLDataBaseContext())
            {
               //Сделать реализацию запросов, через свитч команды(SELECT JOIN и т.д.), в кейсах сам запрос, результат записывать в список запросов
               // Тип списка запросов? Отдельный класс?
            }
            Content = new DataBaseViewModel();
        }
    }
}
