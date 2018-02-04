namespace CounterStats.UI.Helpers
{
    public class Settings : ISettings
    {
        public string SteamName
        {
            get { return Properties.Settings.Default.SteamName; }
            set { Properties.Settings.Default.SteamName = value; }
        }

        public string SteamId
        {
            get { return Properties.Settings.Default.SteamId; }
            set { Properties.Settings.Default.SteamId = value; }
        }

        public string CsgoPath
        {
            get { return Properties.Settings.Default.CsgoPath; }
            set { Properties.Settings.Default.CsgoPath = value; }
        }

        public bool PlayQuakeSounds
        {
            get { return Properties.Settings.Default.PlayQuakeSounds; }
            set { Properties.Settings.Default.PlayQuakeSounds = value; }
        }

        public void SaveChanges()
        {
            Properties.Settings.Default.Save();
        }
    }
}
