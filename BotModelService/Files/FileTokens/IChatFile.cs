using System.IO;

namespace BotModel.Files.FileTokens
{
	public interface IChatFile : IChatFileToken
	{
		FileStream ReadStream();
		FileStream WriteStream(FileMode fileMode = FileMode.Create);
		T Read<T>();
		void Save<T>(T type);
		void Delete();
		bool Exists();
		void CopyFrom(IChatFileToken token);
	}
}