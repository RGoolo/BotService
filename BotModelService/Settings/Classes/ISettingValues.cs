﻿using System;
using BotModel.Bots.BotTypes.Interfaces.Ids;

namespace BotModel.Settings.Classes
{
	public interface ISettingValues
	{
		void SetValue(string name, string value);
		string GetValue(string name, string @default = default(string));
		//T GetValue<T>(string name, T @default);
		bool GetValueBool(string name, bool @default = default(bool));
		long GetValueLong(string name, long @default = default(long));
		Guid GetValueGuid(string name, Guid @default = default(Guid));
		IMessageId GetIMessageId(string name, IMessageId @default = null); //ToDo
	}
}