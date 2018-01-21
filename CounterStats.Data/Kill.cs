using System.ComponentModel.DataAnnotations;

namespace CounterStats.Data
{
    public class Kill
    {
        [Key]
        public int LocalId { get; set; }
        public string MapName { get; set; }
        public string Location { get; set; }
        public string PlayerSide { get; set; }
        public bool WasHeadshot { get; set; }
        public int Round { get; set; }
        public string GameType { get; set; }
        public string BombState { get; set; }
    }
}
