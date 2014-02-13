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
			_client = new HttpClient ();
		}

		public async Task<string> DownloadString(string url)
		{
			return await _client.GetStringAsync (url);
		}
	}
}

