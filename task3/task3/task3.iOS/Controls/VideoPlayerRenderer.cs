using System;
using System.ComponentModel;
using System.IO;

using AVFoundation;
using AVKit;
using CoreMedia;
using Foundation;
using task3.Controls;
using task3.iOS.Controls;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(VideoPlayer),
                          typeof(VideoPlayerRenderer))]

namespace task3.iOS.Controls
{
    public class VideoPlayerRenderer : ViewRenderer<VideoPlayer, UIView>
    {
        AVPlayer player;
        AVPlayerItem playerItem;
        AVPlayerViewController _playerViewController;

        public override UIViewController ViewController => _playerViewController;

        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> args)
        {
            base.OnElementChanged(args);

            if (args.NewElement != null)
            {
                if (Control == null)
                {

                    _playerViewController = new AVPlayerViewController();

                    player = new AVPlayer();
                    _playerViewController.Player = player;

                    var x = _playerViewController.View;


                    SetNativeControl(_playerViewController.View);
                }

            }
            ((AVPlayerViewController)ViewController).ShowsPlaybackControls = true;
            SetSource();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (player != null)
            {
                player.ReplaceCurrentItemWithPlayerItem(null);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == VideoPlayer.SourceProperty.PropertyName)
            {
                SetSource();
            }
        }

        void SetSource()
        {
            AVAsset asset = null;

            string uri = Element.Source;

            if (!String.IsNullOrWhiteSpace(uri))
            {
                asset = AVAsset.FromUrl(new NSUrl(uri));
            }

            if (asset != null)
            {
                playerItem = new AVPlayerItem(asset);
            }
            else
            {
                playerItem = null;
            }

            player.ReplaceCurrentItemWithPlayerItem(playerItem);

            if (playerItem != null && Element.AutoPlay)
            {
                player.Play();
            }

        }

    }
}