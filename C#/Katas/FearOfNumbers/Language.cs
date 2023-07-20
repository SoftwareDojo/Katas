using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Katas.FearOfNumbers
{
    public interface ILanguage
    {
        string GetText(TextKey key);
        string[] DayNames { get; }
    }

    public enum TextKey
    {
        IsOk,
        IsNotOk,
        UnknownPatient,
        DuplicatePatient,
        UnknownDay,
    }

    public abstract class Language : ILanguage
    {
        public string[] DayNames { get; }

        protected IDictionary<TextKey, string> Messages;

        protected Language(string cultureName)
        {
            Messages = new Dictionary<TextKey, string>();

            DayNames = new CultureInfo(cultureName)
                .DateTimeFormat.DayNames.Select(day => day.ToLower())
                .ToArray();
        }

        public string GetText(TextKey key)
        {
            return Messages[key];
        }
    }

    public class GermanLanguage : Language
    {
        public const string CultureName = "de-DE";
        public const string DisplayName = "deutsch";

        public GermanLanguage() : base(CultureName)
        {
            Messages.Add(TextKey.IsOk, "In Ordnung!");
            Messages.Add(TextKey.IsNotOk, "Nicht in Ordnung!");
            Messages.Add(TextKey.UnknownPatient, "Der Patient ist unbekannt!");
            Messages.Add(TextKey.DuplicatePatient, "Eine Patient mit dem gleichen Namen existiert bereits!");
            Messages.Add(TextKey.UnknownDay, "Der Tag ist unbekannt!");
        }
    }

    public class EnglishLanguage : Language
    {
        public const string CultureName = "en-US";
        public const string DisplayName = "english";

        public EnglishLanguage() : base(CultureName)
        {
            Messages.Add(TextKey.IsOk, "Is ok!");
            Messages.Add(TextKey.IsNotOk, "Is not ok!");
            Messages.Add(TextKey.UnknownPatient, "Unknown patient name!");
            Messages.Add(TextKey.DuplicatePatient, "A patient with the same name already exists!");
            Messages.Add(TextKey.UnknownDay, "Unknown day!");
        }
    }
}
