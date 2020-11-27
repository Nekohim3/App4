using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JsonView : ContentPage
    {
        public JsonView()
        {
            InitializeComponent();
        }

        public void SetInfo(Offer offer)
        {
            L.Text = offer.Data;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = g.Main;
        }
    }
}