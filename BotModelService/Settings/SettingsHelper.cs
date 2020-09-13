using System;
using System.Collections.Generic;
using System.IO;
using BotModel.Bots.BotTypes.Class.Ids;
using BotModel.Bots.BotTypes.Interfaces.Ids;
using BotModel.Bots.BotTypes.Interfaces.Messages;

namespace BotModel.Settings
{
	public static class SettingsHelper0
	{
		//ToDo: in DB
        private static readonly Dictionary<IChatId, SettingHelper0> Settings = new Dictionary<IChatId, SettingHelper0>();

        public static SettingHelper0 GetChatService0(IUser user)
		{
			return GetChatService0(new ChatGuid(user.Id));
		}

		public static SettingHelper0 GetChatService0(IChatId chatId)
		{
            if (!Settings.ContainsKey(chatId))
            {
                var s = new SettingHelper0(chatId, Path.Combine(Directory, chatId.GetId.ToString()));
                Settings.Add(chatId, s);
            }

            return Settings[chatId];
		}

        public static string Directory { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NightGameBot", "Resources");

        // public static IChatFileWorker FileWorker => _fileWorker ??= new LocalChatFileWorker(new ChatGuid(Guid.Empty));
    }
}