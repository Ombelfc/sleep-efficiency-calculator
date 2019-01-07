using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using System.Windows.Media;

namespace SleepEfficiencyCalculator.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Privates

        private TimeSpan total;
        private TimeSpan toFallAsleep;
        private TimeSpan spentAwake;

        private SolidColorBrush fillColor;
        private string percentage;

        #endregion

        #region Publics

        public TimeSpan Total
        {
            get => total;
            set
            {
                total = value;
                RaisePropertyChanged("Total");
            }
        }

        public TimeSpan ToFallAsleep
        {
            get => toFallAsleep;
            set
            {
                toFallAsleep = value;
                RaisePropertyChanged("ToFallAsleep");
            }
        }

        public TimeSpan SpentAwake
        {
            get => spentAwake;
            set
            {
                spentAwake = value;
                RaisePropertyChanged("SpentAwake");
            }
        }

        public SolidColorBrush FillColor
        {
            get => fillColor;
            set
            {
                fillColor = value;
                RaisePropertyChanged("FillColor");
            }
        }

        public string Percentage
        {
            get => percentage;
            set
            {
                percentage = value;
                RaisePropertyChanged("Percentage");
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        public ICommand Calculate => new RelayCommand(() =>
        {
            var totalMinutes = Total.TotalMinutes;
            var toSleep = ToFallAsleep.TotalMinutes;
            var awake = SpentAwake.TotalMinutes;

            var totalSlept = totalMinutes - toSleep - awake;
            var percentage = totalSlept / totalMinutes;

            if(percentage > 0.8)
            {
                FillColor = new SolidColorBrush(Color.FromRgb(102, 255, 51));
            }
            else if(percentage <= 0.8 && percentage >= 0.6)
            {
                FillColor = new SolidColorBrush(Color.FromRgb(255, 153, 0));
            }
            else if(percentage < 0.6)
            {
                FillColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }

            Percentage = String.Format("{0:P2}", percentage);
        });
    }
}