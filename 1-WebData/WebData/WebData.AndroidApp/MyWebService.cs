using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebData.AndroidApp
{
	public class MyWebService
	{
		private HttpClient _client;
		public MyWebService()
		{
			//Don't forget to call dispose after you're completely done with this class.
			_client = new HttpClient ();
		}

		public async Task<string> DownloadString(string url)
		{
			return await _client.GetStringAsync (url);
		}
	}
}

