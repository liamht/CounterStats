using CounterStats.ApiCaller;
using System.Collections.Generic;
using System.Linq;

namespace CounterStats.Business.Entities
{
    public class CsGoStats
    {
        public long Kills { get; set; }

        public long Deaths { get; set; }

        public long TimePlayed { get; set; }

        public long BombPlants { get; set; }

        public long BombDefuses { get; set; }

        public long Wins { get; set; }

        public long DamageDone { get; set; }

        public long RoundsPlayed { get; set; }

        public long ShotsFired { get; set; }

        public long ShotsHit { get; set; }

        public long Headshots { get; set; }

        public long MvpCount { get; set; }
        
        internal CsGoStats(List<GetUserStatsForGameReturnValue> stats)
        {
            Kills = stats.Single(c => c.Name == "total_kills").Value.ToLong();
            Deaths = stats.Single(c => c.Name == "total_deaths").Value.ToLong();
            TimePlayed = stats.Single(c => c.Name == "total_time_played").Value.ToLong();
            BombPlants = stats.Single(c => c.Name == "total_planted_bombs").Value.ToLong();
            BombDefuses = stats.Single(c => c.Name == "total_defused_bombs").Value.ToLong();
            Wins = stats.Single(c => c.Name == "total_wins").Value.ToLong();
            DamageDone = stats.Single(c => c.Name == "total_damage_done").Value.ToLong();
            RoundsPlayed = stats.Single(c => c.Name == "total_rounds_played").Value.ToLong();
            ShotsFired = stats.Single(c => c.Name == "total_shots_fired").Value.ToLong();
            ShotsHit = stats.Single(c => c.Name == "total_shots_hit").Value.ToLong();
            Headshots = stats.Single(c => c.Name == "total_kills_headshot").Value.ToLong();
            MvpCount = stats.Single(c => c.Name == "total_mvps").Value.ToLong();
        }
    }

    internal static class CsgoStatsExtensions
    {
        internal static long ToLong(this string value)
        {
            return long.Parse(value);
        }
    }
}