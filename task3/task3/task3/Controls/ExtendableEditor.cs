using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace task3.Controls
{
    class ExtendableEditor:Editor
    {
        public static BindableProperty IsExpandableProperty
         = BindableProperty.Create(nameof(IsExpandable), typeof(bool), typeof(ExtendableEditor), false);

        public bool IsExpandable
        {
            get => (bool)GetValue(IsExpandableProperty); 
            set => SetValue(IsExpandableProperty, value); 
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)       
        {
            base.OnPropertyChanged(propertyName);
            if (IsExpandable) InvalidateMeasure();
        }

    }
}
