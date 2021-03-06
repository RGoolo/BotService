﻿using System;
using System.Threading;
using System.Threading.Tasks;
using BotModel.Bots.BotTypes.Enums;
using BotModel.Bots.BotTypes.Interfaces;
using BotModel.Bots.BotTypes.Interfaces.Ids;
using BotModel.Bots.BotTypes.Interfaces.Messages;
using BotModel.Bots.TelegramBot.Entity;
using BotModel.Files.FileTokens;
using BotModel.Logger;
using BotModel.Settings;
using Telegram.Bot;

namespace BotModel.Bots.TelegramBot.Services
{
	public class Downloader
	{
		private readonly TelegramBotClient _bot;
		private readonly CancellationToken _cancellationToken;
		private readonly ILogger _log;
		
		private IChatFileFactory _chatFileWorker(IChatId chatId) => SettingsHelper0.GetChatService0(chatId).FileChatFactory;
		
		public Downloader(TelegramBotClient bot, CancellationToken cancellationToken)
		{
			_log = Logger.Logger.CreateLogger(nameof(Downloader));
			
			_bot = bot;
			_cancellationToken = cancellationToken;
		}

		public Task<TelegramMessage> DownloadFileAsync(IBotMessage msg) => DownloadFileAsync(msg, msg);

		private async Task<TelegramMessage> DownloadFileAsync(string fileId, IChatFile token, IBotMessage msg, TypeResource type)
		{
			try
			{
				var tFile = await _bot.GetFileAsync(fileId, _cancellationToken);

				await using (var file = token.WriteStream())
				{
					var a = _bot.DownloadFileAsync(tFile.FilePath, file, _cancellationToken);
					a.Wait(_cancellationToken);
				}

				msg.Resource = new Resource(token, type);
				//ToDo
				return msg as TelegramMessage;
			}
			catch (System.Exception ex)
			{
				_log.Error(ex, "Error downloading: ");
			}
			return null;
		}

		private Task<TelegramMessage> DownloadFileAsync(IBotMessage msg, IBotMessage resourceMsg)
		{
			if (resourceMsg == null)
				return null;

			return resourceMsg.TypeMessage switch
			{
				MessageType.Photo => DownloadPhotoAsync(msg, resourceMsg),
				MessageType.Voice => DownloadVoiceAsync(msg, resourceMsg),
				MessageType.Document => DownloadDocumentAsync(msg, msg.ReplyToMessage),
				_ => DownloadFileAsync(msg, resourceMsg.ReplyToMessage),
			};
		}

		private Task<TelegramMessage> DownloadVoiceAsync(IBotMessage msg, IBotMessage resourceMsg)
		{
			var tMsg = (resourceMsg as TelegramMessage)?.Message;
			if (tMsg == null)
				return null;
            
			var file = tMsg.Type switch
            {
                Telegram.Bot.Types.Enums.MessageType.Audio => _chatFileWorker(msg.Chat.Id).NewResourcesFileByExt(".mp3"), //todo mimeType
                Telegram.Bot.Types.Enums.MessageType.Voice => _chatFileWorker(msg.Chat.Id).NewResourcesFileByExt(".ogg"),
                _ => throw new ArgumentOutOfRangeException()
            };

            var fileId = tMsg.Type switch
            {
                Telegram.Bot.Types.Enums.MessageType.Audio => tMsg.Audio.FileId, //todo mimeType
                Telegram.Bot.Types.Enums.MessageType.Voice => tMsg.Voice.FileId,
                _ => throw new ArgumentOutOfRangeException()
            };

			return DownloadFileAsync(fileId, file, msg, TypeResource.Voice);
		}

		private Task<TelegramMessage> DownloadPhotoAsync(IBotMessage msg, IBotMessage resourceMsg)
		{
			var tMsg = (resourceMsg as TelegramMessage)?.Message;
			if (tMsg == null)
				return null;

			//var filePath = SettingHelper.DontExistFile("jpg", resourceMsg.ChatId);
			var fileToken = _chatFileWorker(msg.Chat.Id).NewResourcesFileByExt(".jpg");
			return DownloadFileAsync(tMsg.Photo[^1].FileId, fileToken, msg, TypeResource.Photo);
		}

		private Task<TelegramMessage> DownloadDocumentAsync(IBotMessage msg, IBotMessage resourceMsg)
		{
			var tMsg = (resourceMsg as TelegramMessage)?.Message;
			if (tMsg == null)
				return null;

			//var filePath = SettingHelper.DontExistFile("jpg", resourceMsg.ChatId);
			var fileToken = _chatFileWorker(msg.Chat.Id).NewResourcesFileByExt(System.IO.Path.GetExtension(tMsg.Document.FileName));
			return DownloadFileAsync(tMsg.Document.FileId, fileToken, msg, TypeResource.Document);
		}
	}
}