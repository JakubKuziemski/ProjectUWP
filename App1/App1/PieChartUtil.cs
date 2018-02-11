using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class PieChartUtil
    {
        private double marketCapRestValue;
        private double totalMarketCapValue;
        List<Cryptocurrency> cryptocurrencyList = new List<Cryptocurrency>();
        public async void init()
        {
            TotalMarketCap totalMarketCap = await OpenCoinMarketCapProxy.GetTotalMarketCap();
            cryptocurrencyList = await OpenCoinMarketCapProxy.GetCryptocurrencyList();
            totalMarketCapValue = totalMarketCap.total_market_cap_usd;
            calculateMarketCapRestValue();
        }

        public void calculateMarketCapRestValue()
        {
            double first5cryptoValue = 0;
            foreach (Cryptocurrency cryptocurrency in cryptocurrencyList)
            {
                first5cryptoValue += Convert.ToDouble(cryptocurrency.market_cap_usd);
            }
            marketCapRestValue = totalMarketCapValue - first5cryptoValue;
        }

        public double getMarketCapRestValue()
        {
            return marketCapRestValue;
        }

        public double getTotalMarketCapValue()
        {
            return totalMarketCapValue;
        }

        public List<Cryptocurrency> getCryptocurrencyList()
        {
            return cryptocurrencyList;
        }
    }
}
