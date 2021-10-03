using HMI_APR3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HMI_APR3.View
{
    class ArmViewModel : INotifyPropertyChanged
    {
        private SheetView[] _transpSheets;
        private SheetView[] _lu1Sheets;
        private SheetView[] _lu2Sheets;
        private SheetView[] _lu3Sheets;
        private SheetView[] _throws;
        private string _actSheetNumber;
        private HMIStatus _status;

        private double _scaleX;
        private double _scaleY;

        public ArmViewModel()
        {
            _transpSheets = new SheetView[15];
            _lu1Sheets = new SheetView[7];
            _lu2Sheets = new SheetView[7];
            _lu3Sheets = new SheetView[7];
            _throws = new SheetView[10];
            _status = new HMIStatus();
            _scaleX = 1.0;
            _scaleY = 1.0;

            for (int i = 0; i < _transpSheets.Length || i < _lu1Sheets.Length || i < _lu2Sheets.Length || i < _lu3Sheets.Length || i < _throws.Length; i++)
            {
                if (i < _transpSheets.Length)
                    _transpSheets[i] = new SheetView();

                if (i < _lu1Sheets.Length)
                    _lu1Sheets[i] = new SheetView();

                if (i < _lu2Sheets.Length)
                    _lu2Sheets[i] = new SheetView();

                if (i < _lu3Sheets.Length)
                    _lu3Sheets[i] = new SheetView();

                if (i < _throws.Length)
                    _throws[i] = new SheetView();
            }
        }

        public SheetView[] TranspSheets
        {
            get { return _transpSheets; }
            set
            {
                _transpSheets = value;
                OnPropertyChanged("TranspSheets");
            }
        }

        public SheetView[] Lu1Sheets
        {
            get { return _lu1Sheets; }
            set
            {
                _lu1Sheets = value;
                OnPropertyChanged("Lu1Sheets");
            }
        }

        public SheetView[] Lu2Sheets
        {
            get { return _lu2Sheets; }
            set
            {
                _lu2Sheets = value;
                OnPropertyChanged("Lu2Sheets");
            }
        }

        public SheetView[] Lu3Sheets
        {
            get { return _lu3Sheets; }
            set
            {
                _lu3Sheets = value;
                OnPropertyChanged("Lu3Sheets");
            }
        }

        public SheetView[] Throws
        {
            get { return _throws; }
            set
            {
                _throws = value;
                OnPropertyChanged("Throws");
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

        public HMIStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public double ScaleX
        {
            get { return _scaleX; }
            set
            {
                _scaleX = value;
                OnPropertyChanged("ScaleX");
            }
        }

        public double ScaleY
        {
            get { return _scaleY; }
            set
            {
                _scaleY = value;
                OnPropertyChanged("ScaleY");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }
    }
}
