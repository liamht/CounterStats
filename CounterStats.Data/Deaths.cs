using System.ComponentModel.DataAnnotations;

namespace CounterStats.Data
{
    public class Death
    {
        [Key]
        public int LocalId { get; set; }
        public string MapName { get; set; }
        public string Location { get; set; }
        public string PlayerSide { get; set; }
        public int Round { get; set; }
        public string GameType { get; set; }
        public string BombState { get; set; }
    }
}
