﻿namespace CounterStats.Business.Events
{
    public class KillEventArgs
    {
        public bool WasKnife { get; set; }
        public bool WasHeashot { get; set; }
        public int KillsThisRound { get; set; }
    }
}
