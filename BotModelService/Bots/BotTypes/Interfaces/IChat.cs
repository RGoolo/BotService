using BotModel.Bots.BotTypes.Interfaces.Ids;

namespace BotModel.Bots.BotTypes.Interfaces
{
	public enum ChatType
	{
		Private, Group
	}

	public interface IChat
	{
		public string ChatName { get; }
		public ChatType Type { get; }
		public IChatId Id { get; }
	}
}
