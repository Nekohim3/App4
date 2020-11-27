using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Newtonsoft.Json;

using Xamarin.Forms;

using Formatting = Newtonsoft.Json.Formatting;

namespace App4
{
    public partial class MainPage : ContentPage
    {
        private string _link = "http://partner.market.yandex.ru/pages/help/YML.xml";
        private ObservableCollection<Offer> _offerList;
        public MainPage()
        {
            g.Main = this;
            g.Info = new JsonView();
            InitializeComponent();
            _offerList     = new ObservableCollection<Offer>();
            LV.ItemsSource = _offerList;
            LoadXml();
        }

        public async void LoadXml()
        {
            var wc   = new WebClient {Encoding = Encoding.GetEncoding(1251)};
            var data = await wc.DownloadStringTaskAsync(_link);
            var doc  = new XmlDocument();
            doc.LoadXml(data);
             
            var offers = doc.DocumentElement?["shop"]?["offers"];

            if (offers != null)
                foreach (XmlNode node in offers.ChildNodes)
                    _offerList.Add(new Offer(node.Attributes?["id"].Value, node));

        }

        private void LV_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            (g.Info as JsonView).SetInfo((Offer)LV.SelectedItem);
            Application.Current.MainPage = g.Info;
        }
    }


}
