using BotModel.Bots.BotTypes.Enums;

namespace BotModel.Bots.BotTypes.Interfaces.Messages
{
	public interface ICommand
	{
		string Value { get; }
		MessageType TypeMessage { get; }
	}
}