using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace task3.Controls
{
    public class VideoPlayer : View
    {

        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(nameof(Source), typeof(string), typeof(VideoPlayer), null);

        public string Source
        {
            set { SetValue(SourceProperty, value); }
            get { return (string)GetValue(SourceProperty); }
        }

        public static readonly BindableProperty AutoPlayProperty =
            BindableProperty.Create(nameof(AutoPlay), typeof(bool), typeof(VideoPlayer), false);

        public bool AutoPlay
        {
            set { SetValue(AutoPlayProperty, value); }
            get { return (bool)GetValue(AutoPlayProperty); }
        }
    }
}
