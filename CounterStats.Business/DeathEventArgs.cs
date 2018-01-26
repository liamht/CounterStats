namespace CounterStats.Business
{
    public class DeathEventArgs
    {
        public int? CurrentDeathStreak { get; set; }

        public bool IsCurrentPlayer { get; set; }
    }
}
