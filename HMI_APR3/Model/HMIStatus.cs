using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HMI_APR3.Model
{
    class HMIStatus : INotifyPropertyChanged
    {
        private string _transpCounter;
        private string _lu1Counter;
        private string _lu2Counter;
        private string _lu3Counter;
        private string _shSpeed;
        private string _lu1Speed;
        private string _lu2Speed;
        private string _lu3Speed;
        private string _inPacket1;
        private string _inPacket2;
        private string _inPacket3;
        private string _actSheetNumber;

        public string TranspCounter
        {
            get { return _transpCounter; }
            set
            {
                _transpCounter = value;
                OnPropertyChanged("TranspCounter");
            }
        }

        public string Lu1Counter
        {
            get { return _lu1Counter; }
            set
            {
                _lu1Counter = value;
                OnPropertyChanged("Lu1Counter");
            }
        }

        public string Lu2Counter
        {
            get { return _lu2Counter; }
            set
            {
                _lu2Counter = value;
                OnPropertyChanged("Lu2Counter");
            }
        }

        public string Lu3Counter
        {
            get { return _lu3Counter; }
            set
            {
                _lu3Counter = value;
                OnPropertyChanged("Lu3Counter");
            }
        }

        public string ShSpeed
        {
            get { return _shSpeed; }
            set
            {
                _shSpeed = value;
                OnPropertyChanged("ShSpeed");
            }
        }

        public string Lu1Speed
        {
            get { return _lu1Speed; }
            set
            {
                _lu1Speed = value;
                OnPropertyChanged("Lu1Speed");
            }
        }

        public string Lu2Speed
        {
            get { return _lu2Speed; }
            set
            {
                _lu2Speed = value;
                OnPropertyChanged("Lu2Speed");
            }
        }

        public string Lu3Speed
        {
            get { return _lu3Speed; }
            set
            {
                _lu3Speed = value;
                OnPropertyChanged("Lu3Speed");
            }
        }

        public string InPacket1
        {
            get { return _inPacket1; }
            set
            {
                _inPacket1 = value;
                OnPropertyChanged("InPacket1");
            }
        }

        public string InPacket2
        {
            get { return _inPacket2; }
            set
            {
                _inPacket2 = value;
                OnPropertyChanged("InPacket2");
            }
        }

        public string InPacket3
        {
            get { return _inPacket3; }
            set
            {
                _inPacket3 = value;
                OnPropertyChanged("InPacket3");
            }
        }

        public string ActSheetNumber
        {
            get { return _actSheetNumber; }
            set
            {
                _actSheetNumber = value;
                OnPropertyChanged("ActSheetNumber");
            }
        }

        private void OnPropertyChanged(string propertyChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
