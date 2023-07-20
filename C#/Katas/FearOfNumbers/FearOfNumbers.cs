using System;
using System.Collections.Generic;

namespace Katas.FearOfNumbers
{
    public class FearOfNumbers
    {
        private readonly IDictionary<string, IPatient> patients;
        private readonly IDictionary<string, ILanguage> languages;
        private readonly DateTime currentDate;
        private readonly string currentLanguage;

        public FearOfNumbers() : this(DateTime.Now, GermanLanguage.DisplayName) { }

        public FearOfNumbers(string language) : this(DateTime.Now, language) { }

        public FearOfNumbers(DateTime currentDate) : this(currentDate, GermanLanguage.DisplayName) { }

        public FearOfNumbers(DateTime currentDate, string language)
        {
            this.currentDate = currentDate;

            languages = new Dictionary<string, ILanguage>
            {
                { GermanLanguage.CultureName, new GermanLanguage() },
                { EnglishLanguage.CultureName, new EnglishLanguage() },
            };

            currentLanguage = language.ToLower() == EnglishLanguage.DisplayName
                ? EnglishLanguage.CultureName
                : GermanLanguage.CultureName;

            patients = new Dictionary<string, IPatient>();
        }

        public void AddPatient(IPatient patient)
        {
            if (patients.ContainsKey(patient.Name))
                throw new ArgumentException(languages[currentLanguage].GetText(TextKey.DuplicatePatient));

            patients.Add(patient.Name, patient);
        }

        public void RemovePatient(string name)
        {
            if (patients.ContainsKey(name))
                throw new ArgumentException(languages[currentLanguage].GetText(TextKey.UnknownPatient));

            patients.Remove(name);
        }

        public string CheckNumber(string patientName, string dayOfWeek, int number)
        {
            return CheckNumber(patientName, ConvertStringToDayOfWeek(dayOfWeek), number);
        }

        public string CheckNumber(string patientName, int number)
        {
            return CheckNumber(patientName, currentDate.DayOfWeek, number);
        }

        private string CheckNumber(string patientName, DayOfWeek dayOfWeek, int number)
        {
            if (!patients.ContainsKey(patientName))
                throw new ArgumentException(languages[currentLanguage].GetText(TextKey.UnknownPatient));

            bool isOk = patients[patientName].IsNumberOk(dayOfWeek, number);
            return isOk
                ? languages[currentLanguage].GetText(TextKey.IsOk)
                : languages[currentLanguage].GetText(TextKey.IsNotOk);
        }

        private bool TryGetNameIndex(string[] names, string dayOfWeek, out int index)
        {
            index = -1;

            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == dayOfWeek)
                {
                    index = i;
                    return true;
                }
            }

            return false;
        }

        private DayOfWeek ConvertStringToDayOfWeek(string dayOfWeek)
        {
            string name = dayOfWeek.ToLower();
            bool isDeDay = TryGetNameIndex(languages[GermanLanguage.CultureName].DayNames, name, out var deDayIndex);

            // source language requires the same order as the english culture
            if (isDeDay) name = languages[EnglishLanguage.CultureName].DayNames[deDayIndex];

            bool succeeded = Enum.TryParse(name, true, out DayOfWeek result);
            if (!succeeded) throw new ArgumentException(languages[currentLanguage].GetText(TextKey.UnknownDay));
            return result;
        }
    }
}
