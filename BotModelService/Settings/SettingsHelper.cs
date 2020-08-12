using System;
using System.Collections.Generic;
using System.IO;
using BotModel.Bots.BotTypes.Class.Ids;
using BotModel.Bots.BotTypes.Interfaces.Ids;
using BotModel.Bots.BotTypes.Interfaces.Messages;

namespace BotModel.Settings
{
	public static class SettingsHelper<T> where T: IChatService0, new()
	{
		//ToDo: in DB
        private static readonly Dictionary<IChatId, T> Settings = new Dictionary<IChatId, T>();

        public static T GetSetting(IUser user)
		{
			return GetSetting(new ChatGuid(user.Id));
		}

		public static T GetSetting(IChatId chatId)
		{
            if (!Settings.ContainsKey(chatId))
            {
                var s = new T();
                s.Init(chatId, Path.Combine(Directory, chatId.GetId.ToString()));
                Settings.Add(chatId, s);
            }

            return Settings[chatId];
		}

        public static string Directory { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NightGameBot", "Resources");

        // public static IChatFileWorker FileWorker => _fileWorker ??= new LocalChatFileWorker(new ChatGuid(Guid.Empty));
    }
}