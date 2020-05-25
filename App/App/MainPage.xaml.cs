namespace Forms
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Tweetinvi;
    using Tweetinvi.Models;
    using Xamarin.Forms;

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly ITwitterCredentials credentials;
        private IEnumerable<ITweet> _tweets;

        public MainPage()
        {
            InitializeComponent();

            credentials = Auth.SetUserCredentials(Constants.ConsumerKey,
                    Constants.ConsumerSecret,
                    Constants.UserAccessToken,
                    Constants.UserAccessSecret);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_tweets == null)
            {
                _tweets = Timeline.GetHomeTimeline();
                if (_tweets != null)
                {
                    TimeLine.ItemsSource = _tweets;
                }
            }
        }

        private async void TimeLine_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TimeLine.SelectedItem is null)
                return;

            var selected = (ITweet)e.CurrentSelection[0];

            var detail = new TweetDetail(selected);

            await Navigation.PushAsync(detail);

            TimeLine.SelectedItem = null;
        }
    }
}