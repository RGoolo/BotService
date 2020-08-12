using BotModel.Bots.BotTypes.Class.Ids;
using BotModel.Bots.BotTypes.Interfaces;
using BotModel.Bots.BotTypes.Interfaces.Ids;
using Telegram.Bot.Types;

namespace BotModel.Bots.TelegramBot.Entity
{
	public class TelegramChat : IChat
	{
		public TelegramChat(Chat chat)
		{
			ChatName = chat.Title;
			Id =  new ChatLong(chat.Id);
			Type = chat.Type switch
			{
				Telegram.Bot.Types.Enums.ChatType.Private => ChatType.Private,
				_ => ChatType.Group,
			};
		}

		public string ChatName { get; }
		public ChatType Type { get; }
		public IChatId Id { get; }
	}
}