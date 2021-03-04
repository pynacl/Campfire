using System;
using Android.Content;
using Campfire.Mobile.Controls;
using Campfire.Mobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MinimalEntry), typeof(MinimalEntryRenderer))]
namespace Campfire.Mobile.Droid.Renderers
{
    public class MinimalEntryRenderer : EntryRenderer
    {
        public MinimalEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TextAlignment = Android.Views.TextAlignment.Center;
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                Control.Gravity = Android.Views.GravityFlags.CenterVertical;
            }
        }
    }
}
