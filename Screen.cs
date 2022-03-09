using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Snake
{
    static class Screen
    {
        public static void InitialScreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WindowHeight = 30;
            Console.WindowWidth = 120;

            Console.WriteLine("\n\n\n");
            Console.WriteLine("███████╗███╗   ██╗ ██████╗ ██╗   ██╗███████╗");
            Console.WriteLine("██╔════╝████╗  ██║██╔═══██╗██║  ██╔╝██╔════╝");
            Console.WriteLine("███████╗██╔██╗ ██║██║   ██║█████╔═╝ █████╗  ");
            Console.WriteLine("╚════██║██║╚██╗██║████████║██╔══██╗ ██╔══╝  ");
            Console.WriteLine("███████║██║ ╚████║██╔═══██║██║  ╚██╗███████╗");
            Console.WriteLine("╚══════╝╚═╝  ╚═══╝╚═╝   ╚═╝╚═╝   ╚═╝╚══════╝");
            Console.WriteLine("\n\t\tWELCOME TO THE SNAKE GAME");
            Console.WriteLine("\t\tPRESS ANY KEY TO CONTINUE");
            
            Console.ResetColor();

            Console.ReadKey();
            Console.Clear();
        }

        public static void GameOverScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine();
            Console.WriteLine("\t ██████╗ ██████╗ ███╗   ███╗███████╗");
            Console.WriteLine("\t██╔════╝██╔═══██╗████╗ ████║██╔════╝");
            Console.WriteLine("\t██║ ███╗██║   ██║██╔████╔██║█████╗  ");
            Console.WriteLine("\t██║  ██║████████║██║╚██╔╝██║██╔══╝  ");
            Console.WriteLine("\t╚██████║██╔═══██║██║ ╚═╝ ██║███████╗");
            Console.WriteLine("\t ╚═════╝╚═╝   ╚═╝╚═╝     ╚═╝╚══════╝");
            Console.WriteLine("\t ██████╗ ██╗    ██╗███████╗████████╗");
            Console.WriteLine("\t██╔═══██╗██║    ██║██╔════╝██╔═══██║");
            Console.WriteLine("\t██║   ██║██║    ██║█████╗  ██████╔═╝");
            Console.WriteLine("\t██║   ██║╚██╗  ██╔╝██╔══╝  ██╔══██╗ ");
            Console.WriteLine("\t╚██████╔╝ ╚█████╔╝ ███████╗██║  ╚██╗");
            Console.WriteLine("\t ╚═════╝   ╚════╝  ╚══════╝╚═╝   ╚═╝");
            
            Console.WriteLine("\n\t\tYour points are: {0}", Hud.getScore());
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
