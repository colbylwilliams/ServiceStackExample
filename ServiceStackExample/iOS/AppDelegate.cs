using Foundation;
using UIKit;

using ServiceStack;

namespace ServiceStackExample.iOS
{
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow Window { get; set; }

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{

			IosPclExportClient.Configure ();

			JsonHttpClient.GlobalHttpMessageHandlerFactory = () => new ModernHttpClient.NativeMessageHandler ();


			return true;
		}
	}
}