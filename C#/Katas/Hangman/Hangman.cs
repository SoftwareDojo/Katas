using System;
using System.IO;


namespace Katas.Hangman
{
    public class Hangman
    {
        private readonly int myMaxChances;
        public string Result => new string(myResult);

        private readonly char[] myResult;
        private readonly char[] myWord;

        public Hangman(string word) : this(word, 6)
        {

        }

        public Hangman(string word, int maxChances)
        {
            myMaxChances = maxChances;
            myWord = word.ToCharArray();
            myResult = new char[myWord.Length];
            InitializeResult();
        }

        public bool Guess(char value)
        {
            bool foundValue = false;
            for (int i = 0; i < myWord.Length; i++)
            {
                if (myWord[i] != value) continue;

                foundValue = true;
                myResult[i] = value;
            }

            return foundValue;
        }

        private void InitializeResult()
        {
            for (var i = 0; i < myResult.Length; i++)
            {
                myResult[i] = '-';
            }
        }
    }

    public class HangmanException : Exception
    {
        public HangmanException() : base()
        {

        }

        public HangmanException(string message) : base(message)
        {

        }
    }
}
