using Foundation;
using System;
using UIKit;

namespace XamarinMapsiOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
            goMkMapsButton.TouchUpInside += (s, e) =>
            {
                PerformSegue("goMkMapView", null);
            };
            goGMapsButton.TouchUpInside += (s, e) =>
            {
                PerformSegue("goGoogleMaps", null);
            };
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
