﻿namespace BotModel.Exception
{
	public class ModelException : System.Exception
	{
		public ModelException() { }
		public ModelException(string s) : base(s) { }
	}

	public class GameException : ModelException
	{
		public GameException() { }
		public GameException(string s) : base(s) { }
		public GameException(System.Exception e) : base(e.Message) { }
	}
}