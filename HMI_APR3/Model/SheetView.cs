using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HMI_APR3.Model
{
    class SheetView : INotifyPropertyChanged
    {
        private string _number;
        private string _offset;
        private int _lenght;
        private int _position;
        private int _posNumber;
        private int _posLenght;

        public SheetView() { }

        public SheetView(string number, int lenght, int position, string offset, int posNumber, int posLenght)
        {
            Number = number;
            Lenght = lenght;
            Position = position;
            Offset = offset;
            PosNumber = posNumber;
            PosLenght = posLenght;
        }

        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }

        public string Offset
        {
            get { return _offset; }
            set
            {
                _offset = value;
                OnPropertyChanged("Offset");
            }
        }

        public int Lenght
        {
            get { return _lenght; }
            set
            {
                _lenght = value;
                OnPropertyChanged("Lenght");
            }
        }

        public int Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }

        public int PosNumber
        {
            get { return _posNumber; }
            set
            {
                _posNumber = value;
                OnPropertyChanged("PosNumber");
            }
        }

        public int PosLenght
        {
            get { return _posLenght; }
            set
            {
                _posLenght = value;
                OnPropertyChanged("PosLenght");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
