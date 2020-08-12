using BotModel.Bots.BotTypes.Enums;
using BotModel.Files.FileTokens;

namespace BotModel.Bots.BotTypes.Interfaces.Messages
{
	public interface IResource
	{
		IChatFile File { get; }
		TypeResource Type { get; }
	}
}