using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Player
    {
        public Player()
        {
            PlayersStatistics = new HashSet<PlayersStatistic>();
        }

        public long PlayerId { get; set; }
        public string? Name { get; set; }
        public long? Age { get; set; }
        public long? TeamId { get; set; }

        public virtual Team? Team { get; set; }
        public virtual ICollection<PlayersStatistic> PlayersStatistics { get; set; }
    }
}
