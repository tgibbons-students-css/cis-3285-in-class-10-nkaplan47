﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTrader.Contracts
{
    interface ITradeDataUpdate
    {
        void UpdateTradeData(IEnumerable lines);
    }
}