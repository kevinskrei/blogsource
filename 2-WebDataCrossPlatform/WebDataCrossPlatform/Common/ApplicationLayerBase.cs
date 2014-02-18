using System;
using System.Threading.Tasks;

namespace Common
{
	public abstract class ApplicationLayerBase
	{
		private MyWebService _service;
		protected ApplicationLayerBase()
		{
			_service = new MyWebService ();
		}

		public abstract void ShowProgressDialog(string message);
		public abstract void DismissProgressDialog();
		public abstract void ShowNotification(string message);

		protected async Task<string> ExecuteRequestAsync(string progressText, Func<MyWebService, Task<string>> serviceOperation)
		{
			ShowProgressDialog(progressText);
			try
			{
				string response = (string)await serviceOperation(_service);
				DismissProgressDialog();
				return response;
			}
			catch (System.Net.WebException e) {
				DismissProgressDialog ();
				ShowNotification ("Error! " + e.ToString ());
				return "Error!";
			}
		}

		public async Task<string> SimulatedDownload()
		{
			return await ExecuteRequestAsync ("Simulating...", (service) => service.SimulatedDownload ());
		}

		//Or pass in string here to some url
		public async Task<string> RealDownload()
		{
			return await ExecuteRequestAsync ("Downloading...", (service) => service.RealDownload ("http://date.jsontest.com/"));
		}
	}
}

