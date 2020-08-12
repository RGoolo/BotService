using System;
using BotModel.Bots.BotTypes.Enums;

namespace BotModel.Bots.BotTypes.Interfaces.Messages
{
	public interface IUser
	{
		TypeUser Type { get;}
		string Display { get; }
		Guid Id { get; }
	}
}