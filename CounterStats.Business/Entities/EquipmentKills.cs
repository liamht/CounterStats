using System.Collections.Generic;
using System.Linq;
using CounterStats.ApiCaller;

namespace CounterStats.Business.Entities
{
    public class EquipmentKills
    {
        public long HeGrenadeKills { get; }
        public long IncendiaryGrenadeKills { get; }

        public long Total => HeGrenadeKills + IncendiaryGrenadeKills;

        internal EquipmentKills(List<GetUserStatsForGameReturnValue> stats)
        {
            HeGrenadeKills = stats.Single(c => c.Name == "total_kills_hegrenade").Value.ToLong();
            IncendiaryGrenadeKills = stats.Single(c => c.Name == "total_kills_molotov").Value.ToLong();
        }
    }
}