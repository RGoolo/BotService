using System;
using BotModel.Bots.BotTypes.Class.Ids;
using BotModel.Bots.BotTypes.Interfaces;
using BotModel.Bots.BotTypes.Interfaces.Ids;

namespace BotModel.Bots.UnitTestBot
{
	public class UnitTestChat : IChat
	{
        public UnitTestChat()
        {

        }

        public UnitTestChat(IChatId id)
        {
            Id = id;
        }


        public string ChatName { get; } = "unit test chat";
        public ChatType Type { get; set; } = ChatType.Private;
        public IChatId Id { get; set; } = new ChatGuid(new Guid());
    }
}