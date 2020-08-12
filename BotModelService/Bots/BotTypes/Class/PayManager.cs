using BotModel.Bots.BotTypes.Interfaces;
using BotModel.Bots.BotTypes.Interfaces.Ids;
using BotModel.Bots.BotTypes.Interfaces.Messages;

namespace BotModel.Bots.BotTypes.Class
{
	public class PayManager
	{
		public IChatId Chat { get; }

		public PayManager(IChatId chat)
		{
			Chat = chat;
		}

		public bool CheckPurchased(IPay pay, IUser user)
		{
			if (user.Type == Enums.TypeUser.Developer)
				return true;

			return !pay.Paid;
		}
	}
}
