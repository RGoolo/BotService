﻿using BotModel.Bots.BotTypes.Class.Ids;
using BotModel.Bots.BotTypes.Interfaces;
using BotModel.Bots.BotTypes.Interfaces.Ids;

namespace BotModel.Bots.CmdBot
{
	public class CmdChat : IChat
	{
        public string ChatName => "cmd chat";
		public ChatType Type => ChatType.Private;
		public IChatId Id { get; } = new ChatGuid("BBAF99E5-EF91-4FD4-BA25-4A111A071111");
    }
}