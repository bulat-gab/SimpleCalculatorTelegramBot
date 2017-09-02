using System;
using System.Threading;
using System.Threading.Tasks;
using MySimpleBot.Commands;
using Telegram.Bot;

namespace MySimpleBot
{
    static class Bot
    {
        private static TelegramBotClient _bot;
        private static Command _command;

        public static async void Start()
        {
            try
            {
                _bot = new TelegramBotClient(Settings.Key);
                _command = new EvaluateCommand();

                var me = await _bot.GetMeAsync();
                Console.WriteLine("Hello my name is " + me.FirstName);

                await Task.Factory.StartNew(ReceiveMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Smth is wrong =( " + ex.Message);
            }
        }
        private static async Task ReceiveMessage()
        {
            var currentUpdateId = 0;
            while (true)
            {
                var updates = await _bot.GetUpdatesAsync();
                if (updates.Length > 0)
                {
                    var lastUpdate = updates[updates.Length - 1];
                    if (currentUpdateId != lastUpdate.Id)
                    {
                        currentUpdateId = lastUpdate.Id;
                        var message = lastUpdate.Message;

                        Utility.Log(message);

                        _command.Execute(message, _bot);                          
                    }
                }
                Thread.Sleep(200);
            }
        }
    }
}