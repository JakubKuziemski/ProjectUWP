using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public class OpenCoinMarketCapProxy
    {    
        public async static Task<TotalMarketCap> GetTotalMarketCap()
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://api.coinmarketcap.com/v1/global/");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(TotalMarketCap));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (TotalMarketCap)serializer.ReadObject(ms);

            return data;
        }

        public async static Task<List<Cryptocurrency>> GetCryptocurrencyList()
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://api.coinmarketcap.com/v1/ticker/?limit=10");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(List<Cryptocurrency>));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (List<Cryptocurrency>)serializer.ReadObject(ms);
            return data;
        }
    }

    [DataContract]
    public class Cryptocurrency
    {
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string symbol { get; set; }

        [DataMember]
        public string rank { get; set; }

        [DataMember]
        public string price_usd { get; set; }

        [DataMember]
        public string price_btc { get; set; }

        [DataMember]
        public string __invalid_name__24h_volume_usd { get; set; }

        [DataMember]
        public string market_cap_usd { get; set; }

        [DataMember]
        public string available_supply { get; set; }

        [DataMember]
        public string total_supply { get; set; }

        [DataMember]
        public string max_supply { get; set; }

        [DataMember]
        public string percent_change_1h { get; set; }

        [DataMember]
        public string percent_change_24h { get; set; }

        [DataMember]
        public string percent_change_7d { get; set; }

        [DataMember]
        public string last_updated { get; set; }
    }
    [DataContract]
    public class TotalMarketCap
    {
        [DataMember]
        public double total_market_cap_usd { get; set; }

        [DataMember]
        public double total_24h_volume_usd { get; set; }

        [DataMember]
        public double bitcoin_percentage_of_market_cap { get; set; }

        [DataMember]
        public int active_currencies { get; set; }

        [DataMember]
        public int active_assets { get; set; }

        [DataMember]
        public int active_markets { get; set; }

        [DataMember]
        public int last_updated { get; set; }
    }
}
