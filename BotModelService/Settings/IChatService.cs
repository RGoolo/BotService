using BotModel.Bots.BotTypes.Interfaces.Ids;
using BotModel.Files.FileTokens;

namespace BotModel.Settings
{
	public interface IChatService0
    {
        void SetValue(string name, string value);
		string GetValue(string name, string @default = default(string));
		IChatId ChatId { get; }

		void Clear();
		
		IChatFileFactory FileChatFactory { get; }
    }
}