using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BotModel.Bots.BotTypes.Class;
using BotModel.Bots.BotTypes.Enums;
using BotModel.Bots.BotTypes.Interfaces.Ids;
using BotModel.Bots.BotTypes.Interfaces.Messages;
using BotModel.Logger;

namespace BotModel.Bots.BotTypes.Interfaces
{
	//public delegate void MessageArrivedDel(IMessage message);
	//public delegate void SendMessage(IMessageMark messageMark);

	public interface IConcurrentBot : IDisposable
	{
        List<IBotMessage> GetMessages();
		Task<IBotMessage> SendMessage(IMessageToBot message, IChatId chatId);
		Task<IBotMessage> DownloadFileAsync(IBotMessage msg);
		
		void OnError(System.Exception ex);

		ILogger Log { get; }
		IBotId Id { get; }
		TypeBot TypeBot { get; }
	}

	public interface IBot: IDisposable
	{
		IBotId Id { get;}

		Task StartAsync(CancellationToken token);

		TypeBot TypeBot { get; }

        IBotMessage GetNewMessage();
		void SendMessage(IChatId chatId, TransactionCommandMessage tMessage);
		void SendMessages(IChatId chatId, List<TransactionCommandMessage> tMessage);
		void DownloadResource(IBotMessage msg);
	}
}
