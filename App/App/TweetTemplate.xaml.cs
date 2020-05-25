using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TweetTemplate : ContentView
    {
        public TweetTemplate()
        {
            InitializeComponent();
        }

        private void UserProfileImageContainer_OnSizeChanged(object sender, EventArgs e)
        {
            if (Width < 0 || Height < 0)
                return;

            var imageWidth = Width * 0.16;
            UserProfileImageContainer.HeightRequest = imageWidth;
            UserProfileImageContainer.WidthRequest = imageWidth;
            UserProfileImageContainer.CornerRadius = (float)(imageWidth / 2);

            var margin = Width * 0.02;
            UserProfileImageContainer.Margin = new Thickness(margin);
        }
    }
}