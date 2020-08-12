using System;
using System.Collections.Generic;
using BotModel.Bots.BotTypes.Class;
using BotModel.Bots.BotTypes.Enums;
using BotModel.Bots.BotTypes.Interfaces;
using BotModel.Bots.BotTypes.Interfaces.Ids;
using BotModel.Bots.BotTypes.Interfaces.Messages;

namespace BotModel.Bots.CmdBot
{
	public class CmdMessage : IBotMessage
	{
		public IChat Chat => new CmdChat();
		public string Text { get; private set; }
		public MessageType TypeMessage { get; }
		
		public List<IMessageCommand> MessageCommands { get; set; } = new List<IMessageCommand>();

		private readonly CmdUser _cmdUser = new CmdUser();
		public IUser User => _cmdUser;
		public IMessageId MessageId { get; }
		public IBotMessage ReplyToMessage => null;
		public IResource Resource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public IMessageToBot ReplyToCommandMessage { get; }

		public CmdMessage(IBotId botId, IMessageId replayToMsgId = null, string text = null)
		{
			TypeMessage = MessageType.Text; 
			
			Text = text;
			MessageId = replayToMsgId;
			FillCommands();
		}

		public CmdMessage(IBotId botId, IMessageToBot message)
		{
			TypeMessage = MessageType.SystemMessage;
			
			ReplyToCommandMessage = message;

			MessageCommands = new List<IMessageCommand>();
		}

		private void FillCommands()
		{
			if (string.IsNullOrEmpty(Text))
				return;
			
			var cc = new CreatorCommands(new string[] { "/","-"});
			
			MessageCommands = cc.CreateCommands(Text, cc.GetCommands(Text));
		}
	}
}

