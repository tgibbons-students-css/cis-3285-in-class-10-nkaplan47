using CurrencyTrader.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTrader
{
    public class AsynchURLTradeDataProvider : ITradeDataProvider
    {
        private readonly String url;
        UrlTradeDataProvider SynchTradeProvider;

        public AsynchURLTradeDataProvider(String url)
        {
            this.url = url;
            SynchTradeProvider = new UrlTradeDataProvider(url);
        }

        public IEnumerable<string> GetTradeData()
        {
            Task.Run(() => SynchTradeProvider.GetTradeData());
            //return SynchTradeProvider.GetTradeData();
        }
    }
}
