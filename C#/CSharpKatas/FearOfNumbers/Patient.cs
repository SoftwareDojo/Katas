using System;
using System.Collections.Generic;

namespace CSharpKatas.FearOfNumbers
{
    public interface IPatient
    {
        string Name { get; }
        bool IsNumberOk(DayOfWeek day, int number);
    }

    public class Patient : IPatient
    {
        private readonly IDictionary<DayOfWeek, Func<int, bool>> m_Fears;

        public string Name { get; }

        public Patient(string name)
        {
            Name = name;
            m_Fears = new Dictionary<DayOfWeek, Func<int, bool>>();
        }

        public bool IsNumberOk(DayOfWeek day, int number)
        {
            return !m_Fears[day](number);
        }

        public void AddFear(DayOfWeek day, Func<int, bool> fear)
        {
            m_Fears.Add(day, fear);
        }
    }
}
