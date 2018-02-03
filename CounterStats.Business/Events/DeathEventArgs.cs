namespace CounterStats.Business.Events
{
    public class DeathEventArgs
    {
        public int? CurrentDeathStreak { get; set; }

        public bool IsCurrentPlayer { get; set; }
    }
}
