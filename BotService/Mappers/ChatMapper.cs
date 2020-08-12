using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BotModel.Bots.BotTypes.Attribute;
using BotModel.Bots.BotTypes.Class;
using BotModel.Bots.BotTypes.Enums;
using BotModel.Bots.BotTypes.Interfaces.Ids;
using BotModel.Bots.BotTypes.Interfaces.Messages;
using BotModel.Settings;
using BotService.Types;

namespace BotService.Mappers
{
	public class ChatMapper 
	{
		private List<object> _instances = new List<object>();
		public PayManager PayManager;
		private readonly TypeBot _typeBot;
        
        private readonly List<IOnMessage> _onMessages = new List<IOnMessage>();
		public IChatId ChatId { get; }

		public ChatMapper(TypeBot typeBot, IChatId chatId, ISendMessages sendMsg, List<(Type, Func<IBotMessage, IMessageCommand, object>)> customProperty, List<Func<IChatId, ISendMessages, object>> commands)
		{
			ChatId = chatId;
			_typeBot = typeBot;
        
            var settingHelper = SettingsHelper<SettingHelper0>.GetSetting(chatId);
			
			var all = new MethodsAllMapper(sendMsg, settingHelper, customProperty);
			var concrete = new MethodsConcreteMapper(sendMsg, settingHelper, customProperty);
			var props = new PropsMapper(settingHelper);
			
			_onMessages.Add(all);
			_onMessages.Add(concrete);
			_onMessages.Add(props);
			
			PayManager = new PayManager(chatId);

            
			foreach (var command in commands)
            {
                var instance = command(chatId, sendMsg);
				_instances.Add(instance);
				
				all.AddInstance(instance);
				props.AddInstance(instance);
				concrete.AddInstance(instance);
			}

			props.FillProperty();
		}

		private object CreateInstance(Type type, ISendMessages message, IChatId chatId, IChatService0 settings)
		{
			//ToDo FirstOrDefault?
			var ctors = type.GetConstructors();
			var ctor = ctors.First();
			var param = new List<object>();
			
			foreach (var parameterInfo in ctor.GetParameters())
			{
				if (parameterInfo.ParameterType == typeof(ISendMessages))
					param.Add(message);
				else if (parameterInfo.ParameterType == typeof(IChatId))
					param.Add(chatId);
				else if (parameterInfo.ParameterType == typeof(IChatService0))
					param.Add(settings);
			}

			return Activator.CreateInstance(type, param.ToArray());
		}

		public List<TransactionCommandMessage> OnMessage(IBotMessage message)
		{
			return _onMessages.SelectMany(x => x.OnMessage(message)).ToList();
		}

		public void Dispose()
		{
			foreach (var instance in _instances)
			{
				
			}
		}
	}
}

