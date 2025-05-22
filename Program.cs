namespace CyberSecurityBotPart2
{
    internal class Program
    {
 
        static async Task Main(string[] args)
        {
            Utils utils = new Utils();
            utils.PlayGreeting(); // Voice greeting

            Art.DisplayAsciiArt(); // ASCII Logo

            Chatbot bot = new Chatbot();
            bot.GreetUser();
            bot.StartChat();
        }
    }
}
