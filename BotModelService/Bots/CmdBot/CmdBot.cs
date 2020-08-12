using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BotModel.Bots.BotTypes.Class;
using BotModel.Bots.BotTypes.Enums;
using BotModel.Bots.BotTypes.Interfaces;
using BotModel.Bots.BotTypes.Interfaces.Ids;
using BotModel.Bots.BotTypes.Interfaces.Messages;
using BotModel.Logger;

namespace BotModel.Bots.CmdBot
{
	public class CmdBot : IConcurrentBot
	{
		public IBotId Id { get; }

		public ILogger Log { get; }

		public TypeBot TypeBot { get; } = TypeBot.Cmd;

		public CmdBot(IBotId id) 
		{
			Id = id;
			Log =  Logger.Logger.CreateLogger(id.ToString());
		}

		/*protected void Cycle2()
		{
			while (true)
			{
				if (!_toSendQueue.IsEmpty)
				{
					if (_toSendQueue.TryDequeue(out var tMsg))
					{
						if (tMsg.Message != null)
							Console.WriteLine(tMsg.Message.Texter);

						if (tMsg.Messages != null)
							foreach (var msg in tMsg.Messages)
								Console.WriteLine(msg.Texter);
					}
				}
				Thread.Sleep(100);
			}
		}*/

		public void Message(string text)
		{
			var msg = new CmdMessage(Id, null, text);
			//_messagesQueue.Enqueue(msg);
		}

		public  void Dispose() => throw new NotImplementedException();

		public List<IBotMessage> GetMessages()
		{
			var text = Console.ReadLine();
			var msg = new CmdMessage(Id, null, text);
			return new List<IBotMessage> { msg };
		}

        public Task<IBotMessage> SendMessage(IMessageToBot message, IChatId chatId)
        {
           Console.WriteLine(message.Text);
           return null;
        }

        public async Task<IBotMessage> Message(IMessageToBot message, IChatId chatId)
		{
			switch (message.TypeMessage)
			{
					case MessageType.SystemMessage:
					return null;
				case MessageType.Text:
					Console.WriteLine(message.Text);
					break;
				case MessageType.Coordinates:
					Console.WriteLine($"{message.Coordinate} : {message.Text}");
					break;
				case MessageType.Photo:
					Console.WriteLine($"{message.FileToken}");
					break;
			}
			
			return new CmdMessage(Id, message);
		}

		protected  void DownloadFile(IBotMessage msg)
		{
			//empty
		}

		public Task<IBotMessage> DownloadFileAsync(IBotMessage msg)
		{
			return null;
			//throw new NotImplementedException();
		}

		public void OnError(System.Exception ex)
		{
			//throw new NotImplementedException();
		}
	}
}
