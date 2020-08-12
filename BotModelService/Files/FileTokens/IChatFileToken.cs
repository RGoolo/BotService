using BotModel.Bots.BotTypes.Enums;

namespace BotModel.Files.FileTokens
{
	public interface IChatFileToken
	{
		FileTypeFlags FileType { get; }
		string FileName { get; }
		string FullName { get; }
	}
}