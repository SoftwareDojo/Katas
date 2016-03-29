using System;
using CSharpKatas.FearOfNumbers;
using NUnit.Framework;

namespace CSharpKataTests.FearOfNumbers
{
    [TestFixture]
    public class FearOfNumbersTest
    {
        private const string s_Karl = "Karl";
        private const string s_Lenny = "Lenny";

        [TestCase("montag", 12, TextKey.IsNotOk)]
        [TestCase("Montag", 12, TextKey.IsNotOk)]
        [TestCase("MONTAG", 12, TextKey.IsNotOk)]
        [TestCase("montag", 11, TextKey.IsOk)]
        [TestCase("Montag", 11, TextKey.IsOk)]
        [TestCase("MONTAG", 11, TextKey.IsOk)]
        public void CheckNumber_with_Upper_Lower_Strings(string dayOfWeek, int number, TextKey key)
        {
            CheckNumber(GetKarl(), new GermanLanguage(), GermanLanguage.DisplayName, dayOfWeek, number, key);
        }

        [TestCase("monday", 12, TextKey.IsNotOk)]
        [TestCase("Monday", 12, TextKey.IsNotOk)]
        [TestCase("MONDAY", 12, TextKey.IsNotOk)]
        [TestCase("monday", 11, TextKey.IsOk)]
        [TestCase("Monday", 11, TextKey.IsOk)]
        [TestCase("MONDAY", 11, TextKey.IsOk)]
        public void CheckNumber_with_Upper_Lower_Strings_English(string dayOfWeek, int number, TextKey key)
        {
            CheckNumber(GetKarl(), new EnglishLanguage(), EnglishLanguage.DisplayName, dayOfWeek, number, key);
        }

        [TestCase("Montag", 11)]
        [TestCase("Dienstag", 90)]
        [TestCase("Mittwoch", 35)]
        [TestCase("Donnerstag", -1)]
        [TestCase("Freitag", 9)]
        [TestCase("Samstag", 55)]
        [TestCase("Sonntag", -555)]
        public void CheckNumber_is_ok(string dayOfWeek, int number)
        {
            CheckNumber(GetKarl(), new GermanLanguage(), GermanLanguage.DisplayName, dayOfWeek, number, TextKey.IsOk);
        }

        [TestCase("Montag", 12)]
        [TestCase("Dienstag", 96)]
        [TestCase("Mittwoch", 34)]
        [TestCase("Donnerstag", 0)]
        [TestCase("Freitag", 10)]
        [TestCase("Samstag", 56)]
        [TestCase("Sonntag", -666)]
        public void CheckNumber_is_not_ok(string dayOfWeek, int number)
        {
            CheckNumber(GetKarl(), new GermanLanguage(), GermanLanguage.DisplayName, dayOfWeek, number, TextKey.IsNotOk);
        }

        [TestCase("Monday", 11)]
        [TestCase("Tuesday", 90)]
        [TestCase("Wednesday", 35)]
        [TestCase("Thursday", -1)]
        [TestCase("Friday", 11)]
        [TestCase("Saturday", 55)]
        [TestCase("Sunday", -555)]
        public void CheckNumber_is_ok_English(string dayOfWeek, int number)
        {
            CheckNumber(GetKarl(), new EnglishLanguage(), EnglishLanguage.DisplayName, dayOfWeek, number, TextKey.IsOk);
        }

        [TestCase("Monday", 12)]
        [TestCase("Tuesday", 96)]
        [TestCase("Wednesday", 34)]
        [TestCase("Thursday", 0)]
        [TestCase("Friday", 10)]
        [TestCase("Saturday", 56)]
        [TestCase("Sunday", -666)]
        public void CheckNumber_is_not_ok_English(string dayOfWeek, int number)
        {
            CheckNumber(GetKarl(), new EnglishLanguage(), EnglishLanguage.DisplayName, dayOfWeek, number, TextKey.IsNotOk);
        }

        [TestCase("Montag", 5)]
        [TestCase("Dienstag", 9)]
        [TestCase("Mittwoch", 35)]
        [TestCase("Donnerstag", -1)]
        [TestCase("Freitag", 11)]
        [TestCase("Samstag", 55)]
        [TestCase("Sonntag", -555)]
        public void CheckNumber_is_ok_with_Lenny(string dayOfWeek, int number)
        {
            CheckNumber(GetLenny(), new GermanLanguage(), GermanLanguage.DisplayName, dayOfWeek, number, TextKey.IsOk);
        }

        private void CheckNumber(IPatient patient, ILanguage language, string displayName, string dayOfWeek, int number, TextKey key)
        {
            // arrange
            var fears = new CSharpKatas.FearOfNumbers.FearOfNumbers(displayName);
            fears.AddPatient(patient);

            // act
            var actual = fears.CheckNumber(patient.Name, dayOfWeek, number);

            // assert
            Assert.AreEqual(language.GetText(key), actual);
        }

        [TestCase("01.01.2016", 10)]
        [TestCase("02.01.2016", 56)]
        [TestCase("04.01.2016", 12)]
        public void CheckNumber_with_Date_is_not_ok(string dateString, int number)
        {
            // arrange
            var language = new GermanLanguage();
            DateTime date;
            DateTime.TryParse(dateString, out date);
            var fears = new CSharpKatas.FearOfNumbers.FearOfNumbers(date);
            fears.AddPatient(GetKarl());

            // act
            var actual = fears.CheckNumber(s_Karl, number);

            // assert
            Assert.AreEqual(language.GetText(TextKey.IsNotOk), actual);
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
