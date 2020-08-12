using System;
using BotModel.Bots.BotTypes.Enums;

namespace BotModel.Bots.BotTypes.Interfaces
{
	public interface IPay
	{
		Guid Guid { get; }
		bool Paid { get; }
	}

	public interface ICheckAttribute 
	{
		string BoolPropertyName { get; }
	}

	public interface ITypeUserAttribute
	{
		TypeUser TypeUser { get; }
	}
}
