using BotModel.Files.FileTokens;
using Telegram.Bot.Types.InputFiles;

namespace BotModel.Bots.TelegramBot.Services
{
	public static class TelegramFileExtension
	{ 
		public static InputOnlineFile GetInputFile(this IChatFileToken token)
		{
			return token.IsLocal() ? new InputOnlineFile(token.ReadStream(), token.FileName) : new InputOnlineFile(token.FullName);
		}
	}
}