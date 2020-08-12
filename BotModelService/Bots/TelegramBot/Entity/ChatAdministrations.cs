using System;
using System.Collections.Generic;

namespace BotModel.Bots.TelegramBot.Entity
{
	public class ChatAdministrations
	{
		public DateTime LastUpdate { get; set; }
		public List<int> UserIds { get; set; }
	}
}
