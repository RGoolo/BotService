﻿namespace BotModel.Bots.BotTypes.Interfaces.Ids
{
	public interface IMessageId : IId
	{
		public IChatId ChatId { get; }
	}
}