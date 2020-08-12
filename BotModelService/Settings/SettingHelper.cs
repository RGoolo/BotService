using System;
using BotModel.Bots.BotTypes.Class.Ids;
using BotModel.Bots.BotTypes.Interfaces.Ids;
using BotModel.Files.FileTokens;
using BotModel.Settings.Classes;

namespace BotModel.Settings
{
	public class SettingHelper0 : IChatService0, ISettingValues
	{
		private readonly object _lockObj = new object();
		private IChatFile _settingsFile;

		public string GetValue(string name, string @default = default) => Settings.GetValue(name.ToLower(), @default);
		public bool GetValueBool(string name, bool @default = default) => Settings.GetValueBool(name.ToLower(), @default);
		public long GetValueLong(string name, long @default = default) => Settings.GetValueLong(name.ToLower(), @default);
		public Guid GetValueGuid(string name, Guid @default = default) => Settings.GetValueGuid(name.ToLower(), @default);
		public IMessageId GetIMessageId(string name, IMessageId @default = null) => Settings.GetMessageId(name.ToLower(), @default);

        public void SetValue(string name, string value)
        {
            Settings.SetValue(name, value);
            Save();
        }

		public Settings Settings { get; private set; }
		public IChatId ChatId  => new ChatGuid(Settings.ChatGuid);

		public IChatFileFactory FileChatFactory { get; private set; }

		public void Init(IChatId chatId, string directory)
		{
			FileChatFactory = new ChatFileFactory(chatId, directory); //This 
			_settingsFile = FileChatFactory.SystemFile(SystemChatFile.Settings);
            
			if (!_settingsFile.Exists())
			{
				Settings = new Settings(chatId.GetId);
				Save();
			}

			lock (_lockObj)
			{
				Settings = _settingsFile.Read<Settings>();
				Settings.SetDictionary();
			}
        }

        public void Clear()
		{
			Settings.Clear();
			Settings.SetList();

			lock (_lockObj)
			{
				_settingsFile.Delete();
			}
		}

		private void Save()
		{
			Settings.SetList();
			
			lock (_lockObj)
			{
				_settingsFile.Save(Settings);
			}
		}
	}
}
