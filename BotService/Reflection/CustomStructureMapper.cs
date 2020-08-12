using System;
using System.Collections.Generic;
using BotModel.Bots.BotTypes.Interfaces.Messages;
using BotModel.Files.FileTokens;

namespace BotService.Reflection
{
	public static class CustomStructureMapper
	{
		private static Dictionary<Type, Func<IBotMessage, IMessageCommand, object>> parameters => new Dictionary<Type, Func<IBotMessage, IMessageCommand, object>>()
		{
			[typeof(string[])] = (mess, command) => command.Values.ToArray(),
			[typeof(IChatFile)] = (mess, command) => mess.Resource.File,
			[typeof(IChatFile)] = (mess, command) => mess.Resource.File,
			
			[typeof(IEnumerable<string>)] = (mess, command) => command.Values,
			[typeof(IMessageCommand)] = (mess, command) => command,
			[typeof(IBotMessage)] = (mess, command) => mess,
			[typeof(IUser)] = (mess, command) => mess.User,
		};
	}
}