using System;
using CounterStats.ApiCaller;
using CounterStats.ApiCaller.HttpWebClient;
using CounterStats.Business;
using CounterStats.UI.ViewModels;

namespace CounterStats.UI.DesignTimeViewModels
{
    public class DesignTimeLifetimeStatsViewModel
    {
        public long Kills => 23123;

        public long Deaths => 6464;

        public double KillDeathRatio => Math.Round((double) Kills / (double) Deaths, 2);

        public long DamageDone => 234584;

        public DesignTimeLifetimeStatsViewModel() 
        {
        }
    }
}
