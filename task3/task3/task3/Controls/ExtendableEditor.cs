using System;

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

        public ExtendableEditor()
        {
            TextChanged += OnTextChanged;
        }

        ~ExtendableEditor()
        {
            TextChanged -= OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsExpandable) InvalidateMeasure();
        }

    }
}
