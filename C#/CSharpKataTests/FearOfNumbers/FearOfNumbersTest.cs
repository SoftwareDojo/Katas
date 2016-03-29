using System;
using CSharpKatas.FearOfNumbers;
using NUnit.Framework;

namespace CSharpKataTests.FearOfNumbers
{
    [TestFixture]
    public class FearOfNumbersTest
    {
        private const string s_IsOkText = "In Ordnung!";
        private const string s_IsNotOkText = "Nicht in Ordnung!";
        private const string s_Karl = "Karl";
        private const string s_Lenny = "Lenny";

        [TestCase("montag", 12, s_IsNotOkText)]
        [TestCase("Montag", 12, s_IsNotOkText)]
        [TestCase("MONTAG", 12, s_IsNotOkText)]
        [TestCase("montag", 11, s_IsOkText)]
        [TestCase("Montag", 11, s_IsOkText)]
        [TestCase("MONTAG", 11, s_IsOkText)]
        public void Test_CheckNumber_with_Upper_Lower_Strings(string dayOfWeek, int number, string expected)
        {
            // arrange
            var fears = new CSharpKatas.FearOfNumbers.FearOfNumbers();
            fears.AddPatient(GetKarl());
            
            // act
            var actual = fears.CheckNumber(s_Karl, dayOfWeek, number);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Montag", 11)]
        [TestCase("Dienstag", 90)]
        [TestCase("Mittwoch", 35)]
        [TestCase("Donnerstag", -1)]
        [TestCase("Freitag", 9)]
        [TestCase("Samstag", 55)]
        [TestCase("Sonntag", -555)]
        public void Test_CheckNumber_is_ok(string dayOfWeek, int number)
        {
            // arrange
            var fears = new CSharpKatas.FearOfNumbers.FearOfNumbers();
            fears.AddPatient(GetKarl());

            // act
            var actual = fears.CheckNumber(s_Karl, dayOfWeek, number);

            // assert
            Assert.AreEqual(s_IsOkText, actual);
        }

        [TestCase("Montag", 12)]
        [TestCase("Dienstag", 96)]
        [TestCase("Mittwoch", 34)]
        [TestCase("Donnerstag", 0)]
        [TestCase("Freitag", 10)]
        [TestCase("Samstag", 56)]
        [TestCase("Sonntag", -666)]
        public void Test_CheckNumber_is_not_ok(string dayOfWeek, int number)
        {
            // arrange
            var fears = new CSharpKatas.FearOfNumbers.FearOfNumbers();
            fears.AddPatient(GetKarl());

            // act
            var actual = fears.CheckNumber(s_Karl, dayOfWeek, number);

            // assert
            Assert.AreEqual(s_IsNotOkText, actual);
        }

        [TestCase("01.01.2016", 10)]
        [TestCase("02.01.2016", 56)]
        [TestCase("04.01.2016", 12)]
        public void Test_CheckNumber_with_Date_is_not_ok(string dateString, int number)
        {
            // arrange
            DateTime date;
            DateTime.TryParse(dateString, out date);
            var fears = new CSharpKatas.FearOfNumbers.FearOfNumbers(date);
            fears.AddPatient(GetKarl());

            // act
            var actual = fears.CheckNumber(s_Karl, number);

            // assert
            Assert.AreEqual(s_IsNotOkText, actual);
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
