using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBotPart2
{
    public static class Art
    {
        public static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
    _   _   _   _   _   _   _   _   _
   / \ / \ / \ / \ / \ / \ / \ / \ / \
  | C | y | b | e | r | s | e | c | u |
   \/ \/ \/ \/ \/ \/ \/ \/ \_/
    _   _   _   _   _   _
   / \ / \ / \ / \ / \ / \
  | A | w | a | r | e | n |
   \/ \/ \/ \/ \/ \/
        _   _   _
       / \ / \ / \
      | B | o | t |
       \/ \/ \_/");
            Console.ResetColor();
        }
    }
}
