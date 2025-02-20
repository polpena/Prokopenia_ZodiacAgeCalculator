using System;
using System.ComponentModel;
using System.Windows;
using Prokopenia_ZodiacAgeCalculator.Models;

namespace Prokopenia_ZodiacAgeCalculator.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DateTime _birthDate = DateTime.Today;
        private string _ageText;
        private string _westernZodiac;
        private string _chineseZodiac;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
                CalculateAgeAndZodiac();
            }
        }

        public string AgeText
        {
            get => _ageText;
            set { _ageText = value; OnPropertyChanged(nameof(AgeText)); }
        }

        public string WesternZodiac
        {
            get => _westernZodiac;
            set { _westernZodiac = value; OnPropertyChanged(nameof(WesternZodiac)); }
        }

        public string ChineseZodiac
        {
            get => _chineseZodiac;
            set { _chineseZodiac = value; OnPropertyChanged(nameof(ChineseZodiac)); }
        }

        private void CalculateAgeAndZodiac()
        {
            int age = DateTime.Today.Year - BirthDate.Year;
            if (DateTime.Today < BirthDate.AddYears(age)) age--;

            if (age < 0 || age > 135)
            {
                MessageBox.Show("Invalid age! Please enter a valid birth date.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            AgeText = $"Your age: {age} years";

            if (BirthDate.Day == DateTime.Today.Day && BirthDate.Month == DateTime.Today.Month)
            {
                MessageBox.Show("Happy Birthday! 🎉", "Celebration", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            WesternZodiac = $"Western Zodiac: {ZodiacCalculator.GetWesternZodiac(BirthDate)}";
            ChineseZodiac = $"Chinese Zodiac: {ZodiacCalculator.GetChineseZodiac(BirthDate.Year)}";
        }

        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
