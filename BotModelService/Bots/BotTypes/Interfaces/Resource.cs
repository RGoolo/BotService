using BotModel.Bots.BotTypes.Enums;
using BotModel.Bots.BotTypes.Interfaces.Messages;
using BotModel.Files.FileTokens;

namespace BotModel.Bots.BotTypes.Interfaces
{
	public class Resource : IResource
	{
		public Resource(IChatFile file, TypeResource type)
		{
			File = file;
			Type = type;
		}

		public IChatFile File { get; }
		public TypeResource Type { get; }
	}
}