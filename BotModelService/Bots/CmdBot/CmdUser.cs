using System;
using BotModel.Bots.BotTypes.Enums;
using BotModel.Bots.BotTypes.Interfaces.Messages;

namespace BotModel.Bots.CmdBot
{
	public class CmdUser : IUser
	{
		public string Display => "Пользователь ПК";
		public Guid Id => new Guid("{75C20E89-B048-4EF6-8731-922E6DE587BA}");
		public TypeUser Type => TypeUser.Admin | TypeUser.Developer;
	}
}