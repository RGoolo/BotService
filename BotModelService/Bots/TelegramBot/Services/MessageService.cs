using System.Collections.Generic;
using BotModel.Bots.BotTypes.Class;
using BotModel.Bots.BotTypes.Enums;
using BotModel.Bots.BotTypes.Interfaces.Ids;
using BotModel.Bots.TelegramBot.Entity;
using BotModel.Bots.TelegramBot.HtmlParse;
using BotModel.Settings;

namespace BotModel.Bots.TelegramBot.Services
{
	public static class MessageService
	{
		//Parce picture & voice
		public static List<IMessageToBot> ChildrenMessage(TelegramMessage telegramMessage, IMessageToBot msg, IChatId chatId)
		{
			var result = new List<IMessageToBot>();
			if (msg.Text?.Html != true || (!msg.TypeMessage.IsText())|| string.IsNullOrEmpty(msg.Text.Text))
				return result;

			var setting = SettingsHelper0.GetChatService0(chatId);
            var defaultUrl = ""; //ToDo setting.Web.DefaultUri;
			
			var links = TelegramHtml.GetLinks(msg.Text.Text, defaultUrl);
			if (links.Count == 0 || !msg.Text.ReplaceResources)
				return result;

			var str = TelegramHtml.ReplaceTagsToHref(msg.Text.Text, links);

			msg.Text.Replace(str, true);
			var img = 0;
			foreach (var link in links)
			{
				switch (link.TypeUrl)
				{
					case TypeUrl.Img:
						if (img++ > msg.Text.Settings.MaxParsePicture)
							continue;

						var file = link.Location == LocationFileType.Local
							? setting.FileChatFactory.GetExistFileByPath(link.Url)
							: setting.FileChatFactory.InternetFile(link.Url);

						result.Add(MessageToBot.GetPhototMsg(file, (Texter)link.Name));
						break;
					case TypeUrl.Sound:
						result.Add(MessageToBot.GetVoiceMsg(link.Url, link.Name));
						break;
				}
			}

            foreach (var messageToBot in result)
            {
                messageToBot.OnIdMessage = telegramMessage.MessageId;

            }

			return result;
		}
	}
}