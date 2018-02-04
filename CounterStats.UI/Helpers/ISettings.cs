namespace CounterStats.UI.Helpers
{
    public interface ISettings
    {
        bool PlayQuakeSounds { get; set; }
        string SteamId { get; set; }
        string SteamName { get; set; }
        string CsgoPath { get; set; }

        void SaveChanges();
    }
}