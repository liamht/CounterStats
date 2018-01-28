using CounterStats.ApiCaller;
using System.Collections.Generic;
using System.Linq;

namespace CounterStats.Business.Entities
{
    public class CsGoStats
    {
        public long Kills { get; }

        public long Deaths { get; }

        public long TimePlayed { get; }

        public long BombPlants { get; }

        public long BombDefuses { get; }

        public long Wins { get; }

        public long DamageDone { get; }

        public long RoundsPlayed { get; }

        public long ShotsFired { get; }

        public long ShotsHit { get; }

        public long Headshots { get; }

        public long MvpCount { get; }

        public PistolKillStats PistolKills { get; }

        public AssaultRifleKillStats AssaultRifleKills { get; }

        public SubmachineGunKills SubmachineGunKills { get; }

        public ShotgunKills ShotgunKills { get; }

        public LightMachinegunKills LightMachinegunKills { get; }

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
            PistolKills = new PistolKillStats(stats);
            AssaultRifleKills = new AssaultRifleKillStats(stats);
            SubmachineGunKills = new SubmachineGunKills(stats);
            ShotgunKills = new ShotgunKills(stats);
            LightMachinegunKills = new LightMachinegunKills(stats);
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