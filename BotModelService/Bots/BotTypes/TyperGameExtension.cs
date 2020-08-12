using BotModel.Bots.BotTypes.Enums;

namespace BotModel.Bots.BotTypes
{
	public static class TyperGameExtension
	{
		public static bool IsDummy(this TypeGame type)
		{
			return (type & TypeGame.Dummy) != TypeGame.Unknown;
		}
	}
}
