using BotModel.Bots.BotTypes;
using BotModel.Bots.BotTypes.Interfaces.Messages;
using BotService.Reflection;

namespace BotService.Mappers
{
	public abstract class BaseMapper
	{
		protected bool CheckUsage(MapperMemberInfo info, IBotMessage msg)
		{
			if (!info.CheckUsage(msg))
				return false;

			return true;
			//ToDo check pay;
			//if (_payManager.CheckPurchased(info.InstanceAttribute, msg.User) && _payManager.CheckPurchased(info, msg.User))
			//	return true;

			throw new MessageException(msg, "А это платно(");
		}
    }
}