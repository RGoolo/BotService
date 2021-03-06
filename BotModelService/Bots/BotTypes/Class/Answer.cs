﻿using BotModel.Bots.BotTypes.Enums;
using BotModel.Bots.BotTypes.Interfaces.Messages;

namespace BotModel.Bots.BotTypes.Class
{
	public class Answer
	{
		public TypeGame TypeGame { get; set; }
		public string Game { get; set; }
		public string Lvl { get; set; }
		public string Code { get; set; }
		public IUser User { get; set; }
		public string Sectors { get; set; }
		public int Number { get; set; }
	}
}
