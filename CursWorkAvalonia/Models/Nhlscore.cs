using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Nhlscore
    {
        public long NhlscoresId { get; set; }
        public long? Points { get; set; }
        public long? GoalFor { get; set; }
        public long? GoalAg { get; set; }
        public long? TeamId { get; set; }

        public virtual Team? Team { get; set; }
    }
}
