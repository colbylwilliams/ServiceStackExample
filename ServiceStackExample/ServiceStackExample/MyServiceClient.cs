using System;
using System.IO;
using System.Threading.Tasks;

using ServiceStack;

namespace ServiceStackExample
{
	public class MyServiceClient
	{
		static MyServiceClient _shared;

		public static MyServiceClient Shared => _shared ?? (_shared = new MyServiceClient ());


		JsonServiceClient _client;
		JsonServiceClient client => _client ?? (_client = new JsonServiceClient ());


		public void SetBasicAuthCredentials (string username, string password) => client.SetCredentials (username, password);


		public Task<T> GetAsync<T> (string relativeOrAbsoluteUrl)
		{
			try {

				return client.GetAsync<T> (relativeOrAbsoluteUrl);

			} catch (WebServiceException webEx) {

				System.Diagnostics.Debug.WriteLine ($"WebServiceException processing GET request for {typeof (T).Name}\n{webEx.Message}");
				throw;

			} catch (Exception ex) {

				System.Diagnostics.Debug.WriteLine ($"Exception processing GET request for {typeof (T).Name}\n{ex.Message}");
				throw;
			}
		}


		public Task<TResponse> PostAsync<TResponse> (string relativeOrAbsoluteUrl, object data)
		{
			try {

				return client.PostAsync<TResponse> (relativeOrAbsoluteUrl, data);

			} catch (WebServiceException webEx) {

				System.Diagnostics.Debug.WriteLine ($"WebServiceException processing POST request for {typeof (TResponse).Name}\n{webEx.Message}");
				throw;

			} catch (Exception ex) {

				System.Diagnostics.Debug.WriteLine ($"Exception processing POST request for {typeof (TResponse).Name}\n{ex.Message}");
				throw;
			}

		}



		public TResponse PostFile<TResponse> (string relativeOrAbsoluteUrl, Stream data, string filename, string mime)
		{
			try {

				return client.PostFile<TResponse> (relativeOrAbsoluteUrl, data, filename, mime);

			} catch (WebServiceException webEx) {

				System.Diagnostics.Debug.WriteLine ($"WebServiceException processing POST request for {typeof (TResponse).Name}\n{webEx.Message}");
				throw;

			} catch (Exception ex) {

				System.Diagnostics.Debug.WriteLine ($"Exception processing POST request for {typeof (TResponse).Name}\n{ex.Message}");
				throw;
			}
		}
	}
}
