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

        public long MvpCount => 61;

        public double HeadshotPercentage => 0.52;

        public double KillDeathRatio => Math.Round((double) Kills / (double) Deaths, 2);

        public double AverageDamagePerRound => 156.1;

        public double KillsPerRound => 1.01;

        public double Accuracy => 0.5;

        public long PistolKills = 2111;

        public DesignTimeLifetimeStatsViewModel() 
        {
        }
    }
}
