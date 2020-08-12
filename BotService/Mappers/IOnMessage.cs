using System.Collections.Generic;
using BotModel.Bots.BotTypes.Class;
using BotModel.Bots.BotTypes.Interfaces.Messages;

namespace BotService.Mappers
{
	public interface IOnMessage
	{
        //ToDo IEnumerabe
		IEnumerable<TransactionCommandMessage> OnMessage(IBotMessage message);
	}

	public interface IMapper: IOnMessage
	{
		void AddInstance(object instance);
	}
}