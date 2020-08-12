using System.Net;
using System.Threading.Tasks;
using BotModel.HttpMessages.Simple;
using HtmlAgilityPack;

namespace BotModel.HttpMessages
{
	public interface IHttpFullMessages : IBasicHttpMessages, IHttpMessages
	{
		Task<HttpWebResponse> ResponseGet(string url);
		Task<HttpWebResponse> ResponsePost(string url, string context);
	}

	public interface IHttpMessages
	{
		Task Response(string url);
		Task Response(string url, string context);
		Task<string> GetText(string url);
		Task<string> GetText(string url, string context);

		Task<HtmlNode> GetDocumentNode(string url);

	}
}