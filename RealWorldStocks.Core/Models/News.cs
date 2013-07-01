using System;

namespace RealWorldStocks.Core.Models
{
    public class News : NotifyObject
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        private DateTime _articleDate;

        public DateTime ArticleDate
        {
            get { return _articleDate; }
            set
            {
                _articleDate = value;
                NotifyOfPropertyChange(() => ArticleDate);
            }
        }

        private string _url;

        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                NotifyOfPropertyChange(() => Url);
            }
        }
    }
}