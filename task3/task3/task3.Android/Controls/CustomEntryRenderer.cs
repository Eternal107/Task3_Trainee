using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using task3.Controls;
using task3.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace task3.Droid
{
           public class CustomEntryRenderer : EntryRenderer
           {
           public CustomEntryRenderer(Context context): base(context)
           {
           }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
              {
                base.OnElementChanged(e);

                if (Control != null)
                {
                    GradientDrawable gd = new GradientDrawable();
                    gd.SetColor(global::Android.Graphics.Color.Transparent);
                    this.Control.Background=gd;
                    this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                   
                Control.SetTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Black));
                }
              }
           }
}
