using CrossPieCharts.UWP.PieCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace App1
{
    public class PieChartViewModel
    {
        public List<PieChartArgs> PieChartCollection { get; set; }

        public PieChartViewModel(List<Cryptocurrency> cryptocurrencyList)
        {
            changePieChartCollection(cryptocurrencyList);
        }

        public void changePieChartCollection(List<Cryptocurrency> cryptocurrencyList)
        {
            PieChartCollection = new List<PieChartArgs>();
            this.PieChartCollection.Clear();
            int valueCounter = 0;
            int currentValue = 0;

            foreach (Cryptocurrency cryptocurrency in cryptocurrencyList)
            {
                currentValue = (int)Convert.ToDouble(cryptocurrency.market_cap_usd);
                this.PieChartCollection.Add(new PieChartArgs
                {
                    Percentage = currentValue,
                    ColorBrush = new SolidColorBrush(Colors.DarkGreen),
                });
                valueCounter += currentValue;
                currentValue = 0;
            };

            this.PieChartCollection.Add(new PieChartArgs
            {
                Percentage = 100 - valueCounter,
                ColorBrush = new SolidColorBrush(Colors.CornflowerBlue),
            });

            valueCounter = 0;
        }

        public List<PieChartArgs> getPieChartCollection()
        {
            return this.PieChartCollection;
        }
    }
}
