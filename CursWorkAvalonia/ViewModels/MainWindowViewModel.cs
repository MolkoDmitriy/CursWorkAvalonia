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
     
        private ObservableCollection<Request> _nhlscore;
        public ObservableCollection<Request> SelectedNhlScore
        {
            get => _nhlscore;
            set => this.RaiseAndSetIfChanged(ref _nhlscore, value);
        }
        private ObservableCollection<Request> _player;
        public ObservableCollection<Request> SelectedPlayer
        {
            get => _player;
            set => this.RaiseAndSetIfChanged(ref _player, value);
        }
        private ObservableCollection<Request> _team;
        public ObservableCollection<Request> SelectedTeam
        {
            get => _team;
            set => this.RaiseAndSetIfChanged(ref _team, value);
        }
        private ObservableCollection<Request> _teamsStatistic;
        public ObservableCollection<Request> SelectedTeamsStatistic
        {
            get => _teamsStatistic;
            set => this.RaiseAndSetIfChanged(ref _teamsStatistic, value);
        }
        private ObservableCollection<Request> _playersStatistic;
        public ObservableCollection<Request> SelectedPlayersStatistic
        {
            get => _playersStatistic;
            set => this.RaiseAndSetIfChanged(ref _playersStatistic, value);
        }

        private ObservableCollection<Nhlscore> _nhlscores;
        private ObservableCollection<Player> _players;
        private ObservableCollection<Team> _teams;
        private ObservableCollection<TeamsStatistic> _teamsStatistics;
        private ObservableCollection<PlayersStatistic> _playersStatistics;
        public ObservableCollection<Nhlscore> Nhlscores { 
            get => _nhlscores; 
            set => this.RaiseAndSetIfChanged(ref _nhlscores,value); 
        }
        public ObservableCollection<Player> Players
        {
            get => _players;
            set => this.RaiseAndSetIfChanged(ref _players, value);
        }
        public ObservableCollection<Team> Teams
        {
            get =>_teams;
            set => this.RaiseAndSetIfChanged(ref _teams, value);
        }
        public ObservableCollection<TeamsStatistic> TeamsStatistics
        {
            get => _teamsStatistics;
            set => this.RaiseAndSetIfChanged(ref _teamsStatistics, value);
        }
        public ObservableCollection<PlayersStatistic> PlayersStatistics
        {
            get => _playersStatistics;
            set => this.RaiseAndSetIfChanged(ref _playersStatistics, value);
        }
        private ObservableCollection<Request> _requests;
        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set => this.RaiseAndSetIfChanged(ref _requests, value);
        }
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
                new Request("1"),
                new Request("2")
            };

          
        }
        public void CreateRequest()
        {
            Requests.Add(new Request("New request"));
        }
        public void DeleteRequest(Request e)
        {
            Requests.Remove(e);
        }

        public void DeleteTeam(Team e) => Teams.Remove(e);
        public void DeleteTeamsStatistic(TeamsStatistic e) => TeamsStatistics.Remove(e);
        public void DeleteNhlscore(Nhlscore e) => Nhlscores.Remove(e);
        public void DeletePlayer()
        {
        }
        public void DeletePlayersStatistic(PlayersStatistic e) => PlayersStatistics.Remove(e);
        public void CreateTeam() => Teams.Add(new Team() {Name = "new" });
        public void CreateTeamsStatistic() => TeamsStatistics.Add(new TeamsStatistic() { StatisticId = 1});
        public void Create() => Nhlscores.Add(new Nhlscore() { NhlscoresId =1});
        public void CreatePlayer() => Players.Add(new Player() { Name = "new"});
        public void CreatePlayersStatistic() => PlayersStatistics.Add(new PlayersStatistic() { StatisticId =1});
        public void SQLRequestOpen() => Content = new SQLRequestViewModel();
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
