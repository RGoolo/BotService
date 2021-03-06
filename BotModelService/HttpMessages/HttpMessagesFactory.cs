﻿using System.Net;
using System.Text;
using BotModel.HttpMessages.Simple;

namespace BotModel.HttpMessages
{
	public class HttpMessagesFactory 
	{
		protected static IBasicHttpMessages Messages(Encoding encoding = null, DecompressionMethods decompressionMethods = DecompressionMethods.None)
		{
			return new BasicHttpMessages(encoding, decompressionMethods);
		}

		public static IHttpMessages GetMessages() => new HttpMessages(Messages());
	}
}