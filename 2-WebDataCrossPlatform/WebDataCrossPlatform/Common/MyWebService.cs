using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace Common
{
	public class MyWebService
	{
		private HttpClient _client;
		public MyWebService()
		{
			_client = new HttpClient ();
		}

		public async Task<string> SimulatedDownload()
		{
			await Task.Delay (2000);
			return "Hello from the web service";
		}

		public async Task<string> RealDownload(string url)
		{
			return await _client.GetStringAsync (url);
		}
	}
}

