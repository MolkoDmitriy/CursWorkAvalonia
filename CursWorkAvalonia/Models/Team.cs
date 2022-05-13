using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Team
    {
        public Team()
        {
            Nhlscores = new HashSet<Nhlscore>();
            Players = new HashSet<Player>();
            TeamsStatistics = new HashSet<TeamsStatistic>();
        }

        public long TeamId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Nhlscore> Nhlscores { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<TeamsStatistic> TeamsStatistics { get; set; }
    }
}
