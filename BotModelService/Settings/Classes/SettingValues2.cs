﻿namespace BotModel.Settings.Classes
{
	public abstract class SettingValues2
	{
		protected ISettingValues SettingsValues { get; }
		protected SettingValues2(ISettingValues settingsValues)
		{
			SettingsValues = settingsValues;
		}
	}
}