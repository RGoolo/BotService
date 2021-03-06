﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BotModel.Bots.BotTypes.Class;
using BotModel.Bots.BotTypes.Enums;
using BotModel.Bots.BotTypes.Interfaces;
using BotModel.Bots.BotTypes.Interfaces.Ids;
using BotModel.Bots.BotTypes.Interfaces.Messages;

namespace BotModel.Bots.UnitTestBot
{
    public class UnitTestBot : IBot
    {
        //ToDo concurrent
        private Queue<IBotMessage> _messages = new Queue<IBotMessage>() ;
        //ToDo concurrent
        private readonly Dictionary<IChatId, List<IMessageToBot>> _messageToBots = new Dictionary<IChatId, List<IMessageToBot>>();

        public void Dispose()
        {
           
        }

        public UnitTestBot(IBotId botId)
        {
            Id = botId;
        }


        public IBotId Id { get; }
        public Task StartAsync(CancellationToken token) => new Task(Run);

        public void Run(){ }

        public TypeBot TypeBot { get; } = TypeBot.UnitTest;
        
        public IBotMessage GetNewMessage()
        {
            if (_messages.Count == 0)
                return null;
            return _messages.Dequeue();
        }

        public void CreateNewMessage(IBotMessage msg)
        {
            _messages.Enqueue(msg);
        }

        public void SendMessage(IChatId chatId, TransactionCommandMessage tMessage)
        {
            if (!_messageToBots.TryGetValue(chatId, out var list))
            {
                list = new List<IMessageToBot>();
                _messageToBots.Add(chatId, list);
            }

            list.AddRange(tMessage);
        }

        public List<IMessageToBot> GetMessageToBots(IChatId chatId)
        {
            if (_messageToBots.TryGetValue(chatId, out var list))
                return list;
            return null;
        }

        public void SendMessages(IChatId chatId, List<TransactionCommandMessage> tMessage)
        {
            if (!_messageToBots.TryGetValue(chatId, out var list))
            {
                list = new List<IMessageToBot>();
                _messageToBots.Add(chatId, list);
            }

            list.AddRange(tMessage.SelectMany(t => t));
        }

        public void DownloadResource(IBotMessage msg)
        {
            
        }
    }
}