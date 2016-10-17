using System;
using System.Collections.Generic;

namespace Katas.FearOfNumbers
{
    public class FearOfNumbers
    {
        private readonly IDictionary<string, IPatient> m_Patients;
        private readonly IDictionary<string, ILanguage> m_Languages;
        private readonly DateTime m_CurrentDate;
        private readonly string m_CurrentLanguage;

        public FearOfNumbers() : this(DateTime.Now, GermanLanguage.DisplayName) { }

        public FearOfNumbers(string language) : this(DateTime.Now, language) { }

        public FearOfNumbers(DateTime currentDate) : this(currentDate, GermanLanguage.DisplayName) { }

        public FearOfNumbers(DateTime currentDate, string language)
        {
            m_CurrentDate = currentDate;

            m_Languages = new Dictionary<string, ILanguage>();
            m_Languages.Add(GermanLanguage.CultureName, new GermanLanguage());
            m_Languages.Add(EnglishLanguage.CultureName, new EnglishLanguage());

            m_CurrentLanguage = language.ToLower() == EnglishLanguage.DisplayName
                ? EnglishLanguage.CultureName
                : GermanLanguage.CultureName;

            m_Patients = new Dictionary<string, IPatient>();
        }

        public void AddPatient(IPatient patient)
        {
            if (m_Patients.ContainsKey(patient.Name))
                throw new ArgumentException(m_Languages[m_CurrentLanguage].GetText(TextKey.DuplicatePatient));

            m_Patients.Add(patient.Name, patient);
        }

        public void RemovePatient(string name)
        {
            if (m_Patients.ContainsKey(name))
                throw new ArgumentException(m_Languages[m_CurrentLanguage].GetText(TextKey.UnknownPatient));

            m_Patients.Remove(name);
        }

        public string CheckNumber(string patientName, string dayOfWeek, int number)
        {
            return CheckNumber(patientName, ConvertStringToDayOfWeek(dayOfWeek), number);
        }

        public string CheckNumber(string patientName, int number)
        {
            return CheckNumber(patientName, m_CurrentDate.DayOfWeek, number);
        }

        private string CheckNumber(string patientName, DayOfWeek dayOfWeek, int number)
        {
            if (!m_Patients.ContainsKey(patientName))
                throw new ArgumentException(m_Languages[m_CurrentLanguage].GetText(TextKey.UnknownPatient));

            bool isOk = m_Patients[patientName].IsNumberOk(dayOfWeek, number);
            return isOk
                ? m_Languages[m_CurrentLanguage].GetText(TextKey.IsOk)
                : m_Languages[m_CurrentLanguage].GetText(TextKey.IsNotOk);
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
            int deDayIndex;
            bool isDeDay = TryGetNameIndex(m_Languages[GermanLanguage.CultureName].DayNames, name, out deDayIndex);
            DayOfWeek result;

            // source language requires the same order as the english culture
            if (isDeDay) name = m_Languages[EnglishLanguage.CultureName].DayNames[deDayIndex];

            bool succeeded = Enum.TryParse(name, true, out result);
            if (!succeeded) throw new ArgumentException(m_Languages[m_CurrentLanguage].GetText(TextKey.UnknownDay));
            return result;
        }
    }
}
