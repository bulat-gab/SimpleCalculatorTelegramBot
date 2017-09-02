using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jace;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MySimpleBot.Commands
{
    class EvaluateCommand : Command
    {
        public override string Name => "EvaluateCommand";
        public override async void Execute(Message message, TelegramBotClient client)
        {
            var calculationEngine = new CalculationEngine();
            try
            {
                var result = calculationEngine.Calculate(message.Text);
                await client.SendTextMessageAsync(message.From.Id, result.ToString(), replyToMessageId: message.MessageId);
            }
            catch (Exception e)
            {
                Utility.LogError(e);
            };
        }
    }
}
