using System;
using System.ComponentModel;
using System.IO;

using Android.Content;
using Android.Widget;
using ARelativeLayout = Android.Widget.RelativeLayout;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Android.Media;
using task3.Controls;

[assembly: ExportRenderer(typeof(VideoPlayer),
                          typeof(task3.Droid.Controls.VideoPlayerRenderer))]


namespace task3.Droid.Controls
{
    public class VideoPlayerRenderer : ViewRenderer<VideoPlayer, ARelativeLayout>
    {

        private MediaController mediaController;
        private VideoView videoView;

        public VideoPlayerRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> args)
        {
            base.OnElementChanged(args);

            if (args.NewElement != null)
            {
                if (Control == null)
                {
                    videoView = new VideoView(Context);

                    ARelativeLayout relativeLayout = new ARelativeLayout(Context);
                    relativeLayout.AddView(videoView);

                    ARelativeLayout.LayoutParams layoutParams =
                        new ARelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                    layoutParams.AddRule(LayoutRules.CenterInParent);
                    videoView.LayoutParameters = layoutParams;

                    mediaController = new MediaController(Context);
                    mediaController.SetMediaPlayer(videoView);
                    videoView.SetMediaController(mediaController);

                    SetNativeControl(relativeLayout);
                    videoView.Prepared += OnVideoViewPrepared;
                }
            }

            SetTransportControls();
            SetSource();

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == VideoPlayer.SourceProperty.PropertyName)
            {
                SetSource();
            }
        }

        private void SetTransportControls()
        {
            mediaController = new MediaController(Context);
            mediaController.SetMediaPlayer(videoView);
            videoView.SetMediaController(mediaController);
        }
        private void SetSource()
        {
            string uri = Element.Source;

            if (!String.IsNullOrWhiteSpace(uri))
                videoView.SetVideoURI(Android.Net.Uri.Parse(uri));
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null && videoView != null)
            {
                videoView.Prepared -= OnVideoViewPrepared;
            }
            base.Dispose(disposing);
        }

        private void OnVideoViewPrepared(object sender, EventArgs args)
        {
            if (Element.AutoPlay)
                videoView.Start();
        }
    }
}