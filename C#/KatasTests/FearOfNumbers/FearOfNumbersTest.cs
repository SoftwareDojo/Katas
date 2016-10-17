using System;
using Xunit;
using Katas.FearOfNumbers;

namespace KatasTests.FearOfNumbers
{
    public class FearOfNumbersTest
    {
        private const string s_Karl = "Karl";
        private const string s_Lenny = "Lenny";

        [Theory]
        [InlineData("montag", 12, TextKey.IsNotOk)]
        [InlineData("Montag", 12, TextKey.IsNotOk)]
        [InlineData("MONTAG", 12, TextKey.IsNotOk)]
        [InlineData("montag", 11, TextKey.IsOk)]
        [InlineData("Montag", 11, TextKey.IsOk)]
        [InlineData("MONTAG", 11, TextKey.IsOk)]
        public void CheckNumber_with_Upper_Lower_Strings(string dayOfWeek, int number, TextKey key)
        {
            CheckNumber(GetKarl(), new GermanLanguage(), GermanLanguage.DisplayName, dayOfWeek, number, key);
        }

        [Theory]
        [InlineData("monday", 12, TextKey.IsNotOk)]
        [InlineData("Monday", 12, TextKey.IsNotOk)]
        [InlineData("MONDAY", 12, TextKey.IsNotOk)]
        [InlineData("monday", 11, TextKey.IsOk)]
        [InlineData("Monday", 11, TextKey.IsOk)]
        [InlineData("MONDAY", 11, TextKey.IsOk)]
        public void CheckNumber_with_Upper_Lower_Strings_English(string dayOfWeek, int number, TextKey key)
        {
            CheckNumber(GetKarl(), new EnglishLanguage(), EnglishLanguage.DisplayName, dayOfWeek, number, key);
        }

        [Theory]
        [InlineData("Montag", 11)]
        [InlineData("Dienstag", 90)]
        [InlineData("Mittwoch", 35)]
        [InlineData("Donnerstag", -1)]
        [InlineData("Freitag", 9)]
        [InlineData("Samstag", 55)]
        [InlineData("Sonntag", -555)]
        public void CheckNumber_is_ok(string dayOfWeek, int number)
        {
            CheckNumber(GetKarl(), new GermanLanguage(), GermanLanguage.DisplayName, dayOfWeek, number, TextKey.IsOk);
        }

        [Theory]
        [InlineData("Montag", 12)]
        [InlineData("Dienstag", 96)]
        [InlineData("Mittwoch", 34)]
        [InlineData("Donnerstag", 0)]
        [InlineData("Freitag", 10)]
        [InlineData("Samstag", 56)]
        [InlineData("Sonntag", -666)]
        public void CheckNumber_is_not_ok(string dayOfWeek, int number)
        {
            CheckNumber(GetKarl(), new GermanLanguage(), GermanLanguage.DisplayName, dayOfWeek, number, TextKey.IsNotOk);
        }

        [Theory]
        [InlineData("Monday", 11)]
        [InlineData("Tuesday", 90)]
        [InlineData("Wednesday", 35)]
        [InlineData("Thursday", -1)]
        [InlineData("Friday", 11)]
        [InlineData("Saturday", 55)]
        [InlineData("Sunday", -555)]
        public void CheckNumber_is_ok_English(string dayOfWeek, int number)
        {
            CheckNumber(GetKarl(), new EnglishLanguage(), EnglishLanguage.DisplayName, dayOfWeek, number, TextKey.IsOk);
        }

        [Theory]
        [InlineData("Monday", 12)]
        [InlineData("Tuesday", 96)]
        [InlineData("Wednesday", 34)]
        [InlineData("Thursday", 0)]
        [InlineData("Friday", 10)]
        [InlineData("Saturday", 56)]
        [InlineData("Sunday", -666)]
        public void CheckNumber_is_not_ok_English(string dayOfWeek, int number)
        {
            CheckNumber(GetKarl(), new EnglishLanguage(), EnglishLanguage.DisplayName, dayOfWeek, number, TextKey.IsNotOk);
        }

        [Theory]
        [InlineData("Montag", 5)]
        [InlineData("Dienstag", 9)]
        [InlineData("Mittwoch", 35)]
        [InlineData("Donnerstag", -1)]
        [InlineData("Freitag", 11)]
        [InlineData("Samstag", 55)]
        [InlineData("Sonntag", -555)]
        public void CheckNumber_is_ok_with_Lenny(string dayOfWeek, int number)
        {
            CheckNumber(GetLenny(), new GermanLanguage(), GermanLanguage.DisplayName, dayOfWeek, number, TextKey.IsOk);
        }

        private void CheckNumber(IPatient patient, ILanguage language, string displayName, string dayOfWeek, int number, TextKey key)
        {
            // arrange
            var fears = new Katas.FearOfNumbers.FearOfNumbers(displayName);
            fears.AddPatient(patient);

            // act
            var actual = fears.CheckNumber(patient.Name, dayOfWeek, number);

            // assert
            Assert.Equal(language.GetText(key), actual);
        }

        [Theory]
        [InlineData("01.01.2016", 10)]
        [InlineData("02.01.2016", 56)]
        [InlineData("04.01.2016", 12)]
        public void CheckNumber_with_Date_is_not_ok(string dateString, int number)
        {
            // arrange
            var language = new GermanLanguage();
            DateTime date;
            DateTime.TryParse(dateString, out date);
            var fears = new Katas.FearOfNumbers.FearOfNumbers(date);
            fears.AddPatient(GetKarl());

            // act
            var actual = fears.CheckNumber(s_Karl, number);

            // assert
            Assert.Equal(language.GetText(TextKey.IsNotOk), actual);
        }

        private IPatient GetKarl()
        {
            var patient = new Patient(s_Karl);
            patient.AddFear(DayOfWeek.Monday, number => number == 12);
            patient.AddFear(DayOfWeek.Tuesday, number => number > 95);
            patient.AddFear(DayOfWeek.Wednesday, number => number == 34);
            patient.AddFear(DayOfWeek.Thursday, number => number == 0);
            patient.AddFear(DayOfWeek.Friday, number => number % 2 == 0);
            patient.AddFear(DayOfWeek.Saturday, number => number == 56);
            patient.AddFear(DayOfWeek.Sunday, number => number == 666 || number == -666);

            return patient;
        }

        private IPatient GetLenny()
        {
            var patient = new Patient(s_Lenny);
            patient.AddFear(DayOfWeek.Monday, number => number % 3 == 0);
            patient.AddFear(DayOfWeek.Tuesday, number => number > 10);
            patient.AddFear(DayOfWeek.Wednesday, number => number == 22);
            patient.AddFear(DayOfWeek.Thursday, number => number == 0);
            patient.AddFear(DayOfWeek.Friday, number => number <= 10);
            patient.AddFear(DayOfWeek.Saturday, number => number == 56);
            patient.AddFear(DayOfWeek.Sunday, number => number == 666 || number == -666);

            return patient;
        }
    }
}
