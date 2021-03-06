﻿using System;
using CounterStats.Business.Entities;
using CounterStats.Business.Interfaces;

namespace CounterStats.UI.ViewModels
{
    public class LifetimeStatsViewModel
    {
        private ILifetimeStatisticsFetcher _fetcher;

        public long Kills { get; set; }

        public long Deaths { get; set; }

        public long MvpCount { get; set; }

        public double KillDeathRatio { get; set; }

        public double AverageDamagePerRound { get; set; }

        public double KillsPerRound { get; set; }

        public double HeadshotPercentage { get; set; }

        public double Accuracy { get; set; }

        public long PistolKills { get; set; }

        public long AssaultRifleKills { get; set; }

        public long ShotgunKills { get; set; }

        public long SubmachineGunKills { get; set; }

        public long LightMachinegunKills { get; set; }

        public long EquipmentKills { get; set; }
        
        public long CloseQuartersKills { get; set; }

        public LifetimeStatsViewModel(ILifetimeStatisticsFetcher fetcher)
        {
            _fetcher = fetcher;
            CsGoStats stats;
            try
            {
                stats = _fetcher.GetCsgoStats(Properties.Settings.Default.SteamId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Kills = stats.Kills;
            Deaths = stats.Deaths;
            KillDeathRatio = Math.Round(Kills / (double) Deaths, 2);
            AverageDamagePerRound = Math.Round(stats.DamageDone / (double) stats.RoundsPlayed, 2);
            KillsPerRound = Math.Round(stats.Kills / (double) stats.RoundsPlayed, 2);
            Accuracy = Math.Round(stats.ShotsFired / (double) stats.ShotsHit, 2);
            HeadshotPercentage = Math.Round(stats.Kills / (double) stats.Headshots, 2);
            MvpCount = stats.MvpCount;

            PistolKills = stats.PistolKills.Total;
            AssaultRifleKills = stats.AssaultRifleKills.Total;
            SubmachineGunKills = stats.SubmachineGunKills.Total;
            ShotgunKills = stats.ShotgunKills.Total;
            LightMachinegunKills = stats.LightMachinegunKills.Total;
            EquipmentKills = stats.EquipmentKills.Total;
            CloseQuartersKills = stats.CloseQuartersKills.Total;
        }
    }
}
