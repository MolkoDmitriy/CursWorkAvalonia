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
using CursWorkAvalonia.Views;
using System.Collections.Specialized;
using System.Xml.Linq;

namespace CursWorkAvalonia.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        private Request _request;
        public Request SelectedRequest
        {
            get => _request;
            set => this.RaiseAndSetIfChanged(ref _request, value);
        }
        private ObservableCollection<string> _fields;
        public  ObservableCollection<string> Fields
        {
            get => _fields;
            set => this.RaiseAndSetIfChanged(ref _fields, value);
        }
        private ObservableCollection<string> _tables;
        public ObservableCollection<string> Tables
        {
            get => _tables;
            set => this.RaiseAndSetIfChanged(ref _tables, value);
        }

        private ObservableCollection<Nhlscore> _nhlscores;
        private ObservableCollection<Player> _players;
        private ObservableCollection<Team> _teams;
        private ObservableCollection<TeamsStatistic> _teamsStatistics;
        private ObservableCollection<PlayersStatistic> _playersStatistics;
        public ObservableCollection<Nhlscore> Nhlscores
        {
            get => _nhlscores;
            set => this.RaiseAndSetIfChanged(ref _nhlscores, value);
        }
        public ObservableCollection<Player> Players
        {
            get => _players;
            set => this.RaiseAndSetIfChanged(ref _players, value);
        }
        public ObservableCollection<Team> Teams
        {
            get => _teams;
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
            Fields = new ObservableCollection<string>() { "*", "NhlscoresId", "Points", "GoalFor", "GoalAg",
                "PlayerId", "Name", "Age", "StaticticId", "GamePlayed", "Satt", "Pos", "TimeOnIce", "TeamStatisticId", "Win", "Lose" };
            Tables = new ObservableCollection<string>() { "Player", "PlayersStatistic", "Team", "TeamsStatistic", "Nhlscore"};
            Players = new ObservableCollection<Player>();
            PlayersStatistics = new ObservableCollection<PlayersStatistic>();
            Teams = new ObservableCollection<Team>();
            TeamsStatistics = new ObservableCollection<TeamsStatistic>();
            Nhlscores = new ObservableCollection<Nhlscore>();


            using (var db = new NHLDataBaseContext())
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
            Res = new ObservableCollection<Result>();

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
        public void DeletePlayer(Player e) => Players.Remove(e);
        public void DeletePlayersStatistic(PlayersStatistic e) => PlayersStatistics.Remove(e);
        public void CreateTeam() => Teams.Add(new Team() { Name = "new" });
        public void CreateTeamsStatistic() => TeamsStatistics.Add(new TeamsStatistic() { StatisticId = 1 });
        public void CreateNhlScore() => Nhlscores.Add(new Nhlscore() { NhlscoresId = 1 });
        public void CreatePlayer() => Players.Add(new Player() { Name = "new" });
        public void CreatePlayersStatistic() => PlayersStatistics.Add(new PlayersStatistic() { StatisticId = 1 });
        public void SQLRequestOpen() => Content = new SQLRequestViewModel();
        private ObservableCollection<Result> _res;
        private List<string> _s;
        public List<string> s
        {
            get => _s;
            set => this.RaiseAndSetIfChanged(ref _s, value);
        }
        public ObservableCollection<Result> Res
        {
            get => _res;
            set => this.RaiseAndSetIfChanged(ref _res, value);
        }
        public void SQLRequestRun(Request e)
        {

            ShowRequestResultView.F = e;
            Content = new ShowRequestResultViewModel();
        }
        public void Back()
        {
            Content = new DataBaseViewModel();
        }

        /*  string TableName;
                string Field = GetField(e.Field1);
                switch (e.TableName)
                {
                    case 0:
                        TableName = "Nhlscores";
                        if(e.Additions == null)
                        {
                            if(Field == "*")
                            {
                                foreach (var item in db.Nhlscores)
                                {
                                    s.Add(item.NhlscoresId + " " + item.Points + " " + item.GoalFor + " " + item.GoalAg + " " + item.TeamId);
                                }
                            }
                            else
                            {
                                switch (Field)
                                {
                                    case "NhlscoresId":
                                        s = db.Nhlscores.Select(p => p.NhlscoresId.ToString()).ToList();
                                        break;
                                    case "Points":
                                        s = db.Nhlscores.Select(p => p.Points.ToString()).ToList();
                                        break;
                                    case "GoalFor":
                                        s = db.Nhlscores.Select(p => p.GoalFor.ToString()).ToList();
                                        break;
                                    case "GoalAg":
                                        s = db.Nhlscores.Select(p => p.GoalAg.ToString()).ToList();
                                        break;
                                    case "TeamId":
                                        s = db.Nhlscores.Select(p => p.TeamId.ToString()).ToList();
                                        break;
                                    default:
                                        break;
                                }
                               
                            }
                        }

                        break;
                    case 1:
                        TableName = "Players";
                        break;
                    case 2:
                        TableName = "PlayersStatistics";
                        break;
                    case 3:
                        TableName = "Teams";
                        break;
                    case 4:
                        TableName = "TeamsStatistics";
                        break;
                    default:
                        break;
                }

            }*/
        /*private string GetField(int? sw)
        {
            string Field = "";
            switch (sw)
            {
                case 0:
                    Field = "*";
                    break;
                case 1:
                    Field = "NhlscoresId";
                    break;
                case 2:
                    Field = "Points";
                    break;
                case 3:
                    Field = "GoalFor";
                    break;
                case 4:
                    Field = "GoalAg";
                    break;
                case 5:
                    Field = "TeamId";
                    break;
                case 6:
                    Field = "PlayerId";
                    break;
                case 7:
                    Field = "Name";
                    break;
                case 8:
                    Field = "Age";
                    break;
                case 9:
                    Field = "StatisticId";
                    break;
                case 10:
                    Field = "GamePlayed";
                    break;
                case 11:
                    Field = "Satt";
                    break;
                case 12:
                    Field = "Pos";
                    break;
                case 13:
                    Field = "TimeOnIce";
                    break;
                case 14:
                    Field = "TeamStatisticId";
                    break;
                case 15:
                    Field = "Win";
                    break;
                case 16:
                    Field = "Lose";
                    break;
                default:
                    break;
            }
            return Field;
        }*/
    }
}
