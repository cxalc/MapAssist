using System;
using System.Media;

namespace MapAssist.Helpers
{
    public class AudioPlayer
    {
        private static DateTime _itemAlertLastPlayed = DateTime.MinValue;
        private static readonly SoundPlayer _chingAlertPlayer = new SoundPlayer(Properties.Resources.ching);
        public static void PlayItemAlert(string name)
        {
            var now = DateTime.Now;
            if (now - _itemAlertLastPlayed >= TimeSpan.FromSeconds(1))
            {
                _itemAlertLastPlayed = now;

                if (name.ToLower() == "ching") {
                    _chingAlertPlayer.Play();
                }
            }
        }
    }
}
