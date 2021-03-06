﻿using System.Collections.Generic;
using BotModel.Bots.BotTypes.Class;
using BotModel.Bots.BotTypes.Enums;
using BotModel.Bots.BotTypes.Interfaces;
using BotModel.Bots.BotTypes.Interfaces.Ids;
using BotModel.Bots.BotTypes.Interfaces.Messages;

namespace BotModel.Bots.UnitTestBot
{
	public class UnitTestMessage : IBotMessage
	{
		public IChat Chat { get; set; } = new UnitTestChat();
		public string Text { get; set; }
		public MessageType TypeMessage { get; set; }
		
		public List<IMessageCommand> MessageCommands { get; set; }

		public IUser User { get; set; } = new UnitTestUser();
		public IMessageId MessageId { get; set; }
		public IBotMessage ReplyToMessage => null;
		public IResource Resource { get; set; }
		public IMessageToBot ReplyToCommandMessage { get; set; }

		public UnitTestMessage(string text)
        {
            Text = text;
            FillCommands();
		}

        public UnitTestMessage(string text, IChatId chatId) : this(text)
        {
            Text = text;
            FillCommands();
            Chat = new UnitTestChat(chatId);
        }

		private void FillCommands()
		{
			if (string.IsNullOrEmpty(Text))
				return;
			
			var cc = new CreatorCommands(new[] { "/","-"});
			
			MessageCommands = cc.CreateCommands(Text, cc.GetCommands(Text));
		}
	}
}

