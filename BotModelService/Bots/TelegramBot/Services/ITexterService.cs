using BotModel.Bots.BotTypes.Class;
using BotModel.Bots.BotTypes.Interfaces.Ids;

namespace BotModel.Bots.TelegramBot.Services
{
    public interface ITexterService
    {
        Texter GetNormalizeText(Texter text, IChatId chatId);
    }
}