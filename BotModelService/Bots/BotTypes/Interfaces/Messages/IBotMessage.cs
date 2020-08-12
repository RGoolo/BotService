using System.Collections.Generic;
using BotModel.Bots.BotTypes.Class;
using BotModel.Bots.BotTypes.Enums;
using BotModel.Bots.BotTypes.Interfaces.Ids;

namespace BotModel.Bots.BotTypes.Interfaces.Messages
{
	public interface IBotMessage
	{
		IMessageId MessageId { get; }
		IChat Chat { get; }

		string Text { get; }
		MessageType TypeMessage { get; }
		IUser User { get; }
		List<IMessageCommand> MessageCommands { get;}
		IBotMessage ReplyToMessage { get; }

		IMessageToBot ReplyToCommandMessage { get; }
		IResource Resource { get; set; }
	}
}
