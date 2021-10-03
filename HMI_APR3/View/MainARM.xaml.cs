using HMI_APR3.Model;
using HMI_APR3.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HMI_APR3.View
{
    /// <summary>
    /// Логика взаимодействия для MainARM.xaml
    /// </summary>
    public partial class MainARM : Window
    {
        private ArmViewModel ArmViewModel;
        public MainARM()
        {
            InitializeComponent();
            ArmViewModel = new ArmViewModel();
            DataContext = ArmViewModel;
            InitTimerView();
            InitTimerSimul();

            this.SizeChanged += ChangeWindowsSize;
            this.StateChanged += MaximisedWindow;
        }

        private void InitTimerView()
        {
            ViewRefreshLogic vrl = new ViewRefreshLogic(ArmViewModel);
            DispatcherTimer viewTimer = new DispatcherTimer();
            viewTimer.Interval = TimeSpan.FromMilliseconds(100);
            viewTimer.Tick += vrl.ViewRefresh;
            viewTimer.Start();
        }

        private void InitTimerSimul()
        {
            Simul simul = new Simul(rootCanvas);
            DispatcherTimer simTimer = new DispatcherTimer();
            simTimer.Interval = TimeSpan.FromMilliseconds(25);
            simTimer.Tick += simul.Cycle20ms;
            simTimer.Start();
        }

        private void MaximisedWindow(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                ChangeSize(this.ActualWidth / 1415);
            }
        }

        private void ChangeWindowsSize(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width > 1415)
            {
                ChangeSize(this.ActualWidth / 1415);
            }
        }

        private void ChangeSize(double coeff)
        {
            ArmViewModel.ScaleX = coeff;
            ArmViewModel.ScaleY = coeff;
        }
    }
}
