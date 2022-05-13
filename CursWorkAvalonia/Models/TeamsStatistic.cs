using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class TeamsStatistic
    {
        public long StatisticId { get; set; }
        public long? From { get; set; }
        public long? GamePlayed { get; set; }
        public long? Win { get; set; }
        public long? Lose { get; set; }
        public long? TeamId { get; set; }

        public virtual Team? Team { get; set; }
    }
}
