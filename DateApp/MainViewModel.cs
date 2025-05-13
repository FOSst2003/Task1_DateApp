using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace DateApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Date _currentDate;
        private int _daysToAdd;
        private int _monthsToAdd;
        private int _yearsToAdd;
        private int _dayInput = 1;
        private int _monthInput = 1;
        private int _yearInput = 2000;

        public int CurrentDay => _currentDate.Day;
        public int CurrentMonth => _currentDate.Month;
        public int CurrentYear => _currentDate.Year;
        public string CurrentDayOfWeek => _currentDate.DayOfWeek.ToString();

        public int DayInput
        {
            get => _dayInput;
            set
            {
                _dayInput = value;
                OnPropertyChanged();
            }
        }

        public int MonthInput
        {
            get => _monthInput;
            set
            {
                _monthInput = value;
                OnPropertyChanged();
            }
        }

        public int YearInput
        {
            get => _yearInput;
            set
            {
                _yearInput = value;
                OnPropertyChanged();
            }
        }

        public int DaysToAdd
        {
            get => _daysToAdd;
            set
            {
                _daysToAdd = value;
                OnPropertyChanged();
            }
        }

        public int MonthsToAdd
        {
            get => _monthsToAdd;
            set
            {
                _monthsToAdd = value;
                OnPropertyChanged();
            }
        }

        public int YearsToAdd
        {
            get => _yearsToAdd;
            set
            {
                _yearsToAdd = value;
                OnPropertyChanged();
            }
        }

        public ICommand SetDateCommand { get; }
        public ICommand AddDaysCommand { get; }
        public ICommand AddMonthsCommand { get; }
        public ICommand AddYearsCommand { get; }

        public MainViewModel()
        {
            _currentDate = new Date(DayInput, MonthInput, YearInput);
            SetDateCommand = new RelayCommand(OnSetDate);
            AddDaysCommand = new RelayCommand(OnAddDays);
            AddMonthsCommand = new RelayCommand(OnAddMonths);
            AddYearsCommand = new RelayCommand(OnAddYears);
        }

        private void OnSetDate()
        {
            try
            {
                _currentDate = new Date(DayInput, MonthInput, YearInput);
                OnPropertyChanged(nameof(CurrentDay));
                OnPropertyChanged(nameof(CurrentMonth));
                OnPropertyChanged(nameof(CurrentYear));
                OnPropertyChanged(nameof(CurrentDayOfWeek));
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Invalid date entered.");
            }
        }

        private void OnAddDays()
        {
            try
            {
                _currentDate.AddDays(DaysToAdd);
                OnPropertyChanged(nameof(CurrentDay));
                OnPropertyChanged(nameof(CurrentMonth));
                OnPropertyChanged(nameof(CurrentYear));
                OnPropertyChanged(nameof(CurrentDayOfWeek));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding days: {ex.Message}");
            }
        }

        private void OnAddMonths()
        {
            try
            {
                _currentDate.AddMonths(MonthsToAdd);
                OnPropertyChanged(nameof(CurrentDay));
                OnPropertyChanged(nameof(CurrentMonth));
                OnPropertyChanged(nameof(CurrentYear));
                OnPropertyChanged(nameof(CurrentDayOfWeek));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding months: {ex.Message}");
            }
        }

        private void OnAddYears()
        {
            try
            {
                _currentDate.AddYears(YearsToAdd);
                OnPropertyChanged(nameof(CurrentDay));
                OnPropertyChanged(nameof(CurrentMonth));
                OnPropertyChanged(nameof(CurrentYear));
                OnPropertyChanged(nameof(CurrentDayOfWeek));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding years: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}