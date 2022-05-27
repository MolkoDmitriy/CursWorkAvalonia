using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Converters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Avalonia.Interactivity;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;
using CursWorkAvalonia.Models;
namespace CursWorkAvalonia.Views
{
    public partial class ShowRequestResultView : UserControl
    {
        static public Request F;
        public ShowRequestResultView()
        {
            InitializeComponent();

            using (var db = new NHLDataBaseContext())
            {
                string t = F.TableName;
                string l = F.Field1;
                var s = this.Find<DataGrid>("Result").Items;
                switch (t)
                {
                    case "Player":
                        switch (l)
                        {
                            case "*":
                                s = db.Players.Select(x => x).ToList();
                                break;
                            case "Name":
                                s = db.Players.Select(x => x.Name).ToList();
                                break;
                            case "Age":
                                s = db.Players.Select(x => x.Age).ToList();
                                break;
                            case "TeamId":
                                s = db.Players.Select(x => x.TeamId).ToList();
                                break;
                            case "PlayerId":
                                s = db.Players.Select(x => x.PlayerId).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "PlayersStatistic":
                        switch (l)
                        {
                            case "*":
                                s = db.PlayersStatistics.Select(x => x).ToList();
                                break;
                            case "StatisticId":
                                s = db.PlayersStatistics.Select(x => x.StatisticId).ToList();
                                break;
                            case "Pos":
                                s = db.PlayersStatistics.Select(x => x.Pos).ToList();
                                break;
                            case "GamePlayed":
                                s = db.PlayersStatistics.Select(x => x.GamePlayed).ToList();
                                break;
                            case "Satt":
                                s = db.PlayersStatistics.Select(x => x.PlayerId).ToList();
                                break;
                            case "PlayerId":
                                s = db.PlayersStatistics.Select(x => x.PlayerId).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Team":
                        switch (l)
                        {
                            case "*":
                                s = db.Teams.Select(x => x).ToList();
                                break;
                            case "Name":
                                s = db.Teams.Select(x => x.Name).ToList();
                                break;
                            case "TeamId":
                                s = db.Teams.Select(x => x.TeamId).ToList();
                                break;
                            
                            default:
                                break;
                        }
                        break;
                    case "Nhlscore":
                        switch (l)
                        {
                            case "*":
                                s = db.Players.Select(x => x).ToList();
                                break;
                            case "Name":
                                s = db.Players.Select(x => x.Name).ToList();
                                break;
                            case "Age":
                                s = db.Players.Select(x => x.Age).ToList();
                                break;
                            case "TeamId":
                                s = db.Players.Select(x => x.TeamId).ToList();
                                break;
                            case "PlayerId":
                                s = db.Players.Select(x => x.PlayerId).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "TeamsStatistic":
                        switch (l)
                        {
                            case "*":
                                s = db.Players.Select(x => x).ToList();
                                break;
                            case "Name":
                                s = db.Players.Select(x => x.Name).ToList();
                                break;
                            case "Age":
                                s = db.Players.Select(x => x.Age).ToList();
                                break;
                            case "TeamId":
                                s = db.Players.Select(x => x.TeamId).ToList();
                                break;
                            case "PlayerId":
                                s = db.Players.Select(x => x.PlayerId).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                }
                
                this.Find<DataGrid>("Result").Items = s;

            }



        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
