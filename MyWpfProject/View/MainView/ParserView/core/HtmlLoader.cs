using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace MyWpfProject.View.MainView.ParserView.core
{
	class HtmlLoader
	{
		private readonly HttpClient client;
		private readonly string url;

		public HtmlLoader(IParserSettings settings)
		{
			client = new HttpClient();
			this.url = $"{settings.BaseUrl}/{settings.Prefix}/";
		}

		public async Task<string> GetSourceByPage(int id)
		{
			var currentUrl = url.Replace("{CurrentId}",id.ToString());
			var respone = await client.GetAsync(currentUrl);
			string source = null;

			if (respone != null && respone.StatusCode == HttpStatusCode.OK)
			{
				source = await respone.Content.ReadAsStringAsync();
			}

			return source;
		}
	}
}