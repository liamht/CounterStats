﻿using System;

namespace CounterStats.Business.Interfaces
{
    public interface ICurrentGameUpdater : IDisposable
    {
        event EventHandler OnCouldNotStartListening;
        event CsgoDeathHandler OnDeath;
        event CsgoKillHandler OnKill;
        event CsgoStateChangeHandler OnStateChange;
    }
}