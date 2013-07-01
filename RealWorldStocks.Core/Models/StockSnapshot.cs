namespace RealWorldStocks.Core.Models
{
    public class StockSnapshot : NotifyObject
    {
        public StockSnapshot()
        {
            
        }

        public StockSnapshot(string symbol)
        {
            Symbol = symbol;
        }

        private string _symbol;
        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                NotifyOfPropertyChange(() => Symbol);
            }
        }

        private string _company;
        public string Company
        {
            get { return _company; }
            set
            {
                _company = value;
                NotifyOfPropertyChange(() => Company);
            }
        }

        private decimal _openingPrice;
        public decimal OpeningPrice
        {
            get { return _openingPrice; }
            set
            {
                _openingPrice = value;
                NotifyOfPropertyChange(() => OpeningPrice);
            }
        }

        private decimal _lowPrice;
        public decimal LowPrice
        {
            get { return _lowPrice; }
            set
            {
                _lowPrice = value;
                NotifyOfPropertyChange(() => LowPrice);
            }
        }

        private decimal _highPrice;
        public decimal HighPrice
        {
            get { return _highPrice; }
            set
            {
                _highPrice = value;
                NotifyOfPropertyChange(() => HighPrice);
            }
        }



        private decimal _lastPrice;
        public decimal LastPrice
        {
            get { return _lastPrice; }
            set
            {
                _lastPrice = decimal.Parse(value.ToString("F"));
                NotifyOfPropertyChange(() => LastPrice);
            }
        }

        private string _divAndYield;
        public string DivAndYield
        {
            get { return _divAndYield; }
            set
            {
                _divAndYield = value;
                NotifyOfPropertyChange(() => DivAndYield);
            }
        }

        private decimal _pERatio;
        public decimal PERatio
        {
            get { return _pERatio; }
            set
            {
                _pERatio = value;
                NotifyOfPropertyChange(() => PERatio);
            }
        }

        private int _averageVolume;
        public int AverageVolume
        {
            get { return _averageVolume; }
            set
            {
                _averageVolume = value;
                NotifyOfPropertyChange(() => AverageVolume);
            }
        }

        private string _marketCap;
        public string MarketCap
        {
            get { return _marketCap; }
            set
            {
                _marketCap = value;
                NotifyOfPropertyChange(() => MarketCap);
            }
        }

        private string _ask;
        public string Ask
        {
            get { return _ask; }
            set
            {
                _ask = value;
                NotifyOfPropertyChange(() => Ask);
            }
        }

        private string _bid;
        public string Bid
        {
            get { return _bid; }
            set
            {
                _bid = value;
                NotifyOfPropertyChange(() => Bid);
            }
        }

        private decimal _oneYearEstimate;
        public decimal OneYearEstimate
        {
            get { return _oneYearEstimate; }
            set
            {
                _oneYearEstimate = value;
                NotifyOfPropertyChange(() => OneYearEstimate);
            }
        }


        private decimal _daysChange;
        public decimal DaysChange
        {
            get { return _daysChange; }
            set
            {
                _daysChange = value;
                NotifyOfPropertyChange(() => DaysChange);
                NotifyOfPropertyChange(() => DaysChangeFormatted);
            }
        }

        private string _daysChangePercentFormatted;
        public string DaysChangePercentFormatted
        {
            get { return _daysChangePercentFormatted; }
            set
            {
                _daysChangePercentFormatted = value;
                NotifyOfPropertyChange(() => DaysChangePercentFormatted);
            }
        }

        private int _volume;
        public int Volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
                NotifyOfPropertyChange(() => Volume);
            }
        }

        private decimal _previousClose;
        public decimal PreviousClose
        {
            get { return _previousClose; }
            set
            {
                _previousClose = value;
                NotifyOfPropertyChange(() => PreviousClose);
            }
        }


        public string DaysChangeFormatted
        {
            get { return DaysChange > 0 ? string.Format("+{0:0.00}", DaysChange) : DaysChange.ToString("0.00"); }
        }
    }
}