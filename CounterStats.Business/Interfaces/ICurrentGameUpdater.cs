﻿using System;
using CounterStats.Business.Events;

namespace CounterStats.Business.Interfaces
{
    public interface ICurrentGameUpdater : IDisposable
    {
        event EventHandler OnCouldNotStartListening;
        event EventHandler OnNoGameInProgress;
        event CsgoDeathHandler OnDeath;
        event CsgoKillHandler OnKill;
        event CsgoStateChangeHandler OnStateChange;

        void Start();
    }
}