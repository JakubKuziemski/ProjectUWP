using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MetroLog;
using MetroLog.Targets;
using CrossPieCharts.UWP.PieCharts;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //public List<PieChartArgs> PieChartCollection { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            //PieChartCollection = new List<PieChartArgs>();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            setTotalMarketCap();
            setCryptocurrencyList();
        }

        private async void setTotalMarketCap()
        {
            TotalMarketCap totalMarketCap = await OpenCoinMarketCapProxy.GetTotalMarketCap();
            ResultTextBlock.Text = "Total Market Cap: " +totalMarketCap.total_market_cap_usd.ToString() + "$";
        }

        private async void setCryptocurrencyList()
        {
            CryptocurrencyListView.Items.Clear();

            List<Cryptocurrency> cryptocurrencyList = await OpenCoinMarketCapProxy.GetCryptocurrencyList();
            foreach (Cryptocurrency cryptocurrency in cryptocurrencyList)
            {
                String cryptocurrencyRow = cryptocurrency.name + " Price: " + cryptocurrency.price_usd + "$" + "  Changes: [1h]: " + cryptocurrency.percent_change_1h + "%" + " [24h]: " + cryptocurrency.percent_change_24h + "%";
                CryptocurrencyListView.Items.Add(cryptocurrencyRow);
            }
            //PieChartViewModel pieChartViewModel = new PieChartViewModel(cryptocurrencyList);
            //PieChartCollection = pieChartViewModel.getPieChartCollection();
        }
    }
}
