using System;
using Campfire.Mobile.Controls;
using Campfire.Mobile.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MinimalEntry), typeof(MinimalEntryRenderer))]
namespace Campfire.Mobile.iOS.Renderers
{
    public class MinimalEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                this.Control.BorderStyle = UIKit.UITextBorderStyle.None;
                this.Control.KeyboardType = UIKit.UIKeyboardType.NamePhonePad;
            }
        }
    }
}
