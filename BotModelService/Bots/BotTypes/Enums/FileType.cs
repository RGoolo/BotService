using System;

namespace BotModel.Bots.BotTypes.Enums
{
	[Flags]
	public enum FileType
	{
		Internet,
		Local,

		Chat,

		Resources,
		Settings,

		CustomFile,
	}
}