namespace CounterStats.Business
{
    public delegate void CsgoStateChangeHandler(CsgoStateChangeEventArgs state);

    public delegate void CsgoKillHandler(KillEventArgs state);

    public delegate void CsgoDeathHandler(DeathEventArgs state);
}
