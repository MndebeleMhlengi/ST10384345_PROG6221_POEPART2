using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBotPart2
{
    internal class Utils
    {
        public void PlayGreeting()
        {
            try
            {
                string filepath = @"C:\Users\lab_services_student\Desktop\CyberSecurityBot\Audio\ElevenLabs_Text_to_Speech_audio.wav";
                Console.WriteLine("\n🎵 Playing greeting...");

                /*if (!File.Exists(path))
                {
                    Console.WriteLine($"❌ Audio file not found at: {path}");
                    return;
                }*/

                using (SoundPlayer player = new SoundPlayer(filepath))
                {

                    player.PlaySync(); // Play and wait for it to finish
                }

                Console.WriteLine("✅ Audio playback finished.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error playing audio: {ex.Message}");
            }
        }
    }
}
