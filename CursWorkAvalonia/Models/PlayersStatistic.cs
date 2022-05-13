using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class PlayersStatistic
    {
        public long StatisticId { get; set; }
        public string? Pos { get; set; }
        public long? GamePlayed { get; set; }
        public long? Satt { get; set; }
        public string? TimeOnIce { get; set; }
        public long? PlayerId { get; set; }

        public virtual Player? Player { get; set; }
    }
}
