
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Forms
{
    using Tweetinvi.Models;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TweetDetail : ContentPage
    {
        public TweetDetail(ITweet detail)
        {
            InitializeComponent();

            Detail.BindingContext = detail;
        }
    }
}