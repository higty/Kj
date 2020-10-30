using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DbAccessDatabase
{
    public class PaymentRecord : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private String _Title = "";
        private DateTime _Date;
        private Int32 _Price = 0;

        public Guid PaymentCD { get; set; }
        public String Title
        {
            get { return _Title; }
            set
            {
                if (_Title == value) return;
                _Title = value;
                this.OnPropertyChanged(nameof(this.Title));
            }
        }
        public DateTime Date
        {
            get { return _Date; }
            set
            {
                if (_Date == value) return;
                _Date = value;
                this.OnPropertyChanged(nameof(this.Date));
            }
        }
        public Int32 Price
        {
            get { return _Price; }
            set
            {
                if (_Price == value) return;
                _Price = value;
                this.OnPropertyChanged(nameof(this.Price));
            }
        }

        public override string ToString()
        {
            return this.Date.ToString("yyyy/MM/dd") + " " + this.Price + "円 " + this.Title;
        }
        public void OnPropertyChanged(String name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }


    /// <summary>
    /// INotifyPropertyChangedのサンプルのクラス
    /// </summary>
    public class TitleRecord : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private String _Title = "";
        public String Title
        {
            get { return _Title; }
            set
            {
                if (_Title == value) return;
                _Title = value;
                this.OnPropertyChanged(nameof(this.Title));
            }
        }
        protected void OnPropertyChanged(String propertyName)
        {
            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
