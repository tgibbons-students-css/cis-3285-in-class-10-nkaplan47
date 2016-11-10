using CurrencyTrader.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTrader
{
    public class AsynchURLTradeDataProvider : ITradeDataProvider
    {
        private readonly String url;
        UrlTradeDataProvider SynchTradeProvider;
        TradeDataUpdate tradeUpdater;

        public AsynchURLTradeDataProvider(String url, TradeDataUpdate newTradeUpdater)
        {
            this.url = url;
            tradeUpdater = newTradeUpdater;
            SynchTradeProvider = new UrlTradeDataProvider(url);
        }

        public void GetTradeData()
        {
            //Task.Run(() => SynchTradeProvider.GetTradeData());
            WebClient client = new WebClient();
            Uri uri = new Uri(url);
            client.DownloadStringCompleted += DownloadStringCompleted;
            client.DownloadStringAsync(new Uri(url));
        }

        static void DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string[] lines = e.Result.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            tradeUpdater.UpdateTradeData(lines);
        }
    }
}
