using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace MySimpleBot
{
    static class Utility
    {
        public static void Log(Message message)
        {
            var tempColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Received message from: " + message.Contact);
            Console.WriteLine("Date: " + message.Date);
            Console.WriteLine("Text: " + message.Text);
            Console.WriteLine();

            Console.ForegroundColor = tempColor;
        }

        public static void LogError(Exception e)
        {
            var tempColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(e.Message);

            Console.ForegroundColor = tempColor;
        }
    }
}
