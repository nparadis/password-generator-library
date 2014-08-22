using System;
using System.Collections.Generic;

namespace RandomPasswordGenerator
{
    public static class PasswordGenerator
    {
        private const string Alphabetical = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Numerical = "0123456789";
        private const string Special = "@%+!#$^? :.(){}[]~-_`";
        private const int IndicatesAlphabetical = 0;
        private const int IndicatesNumberical = 1;
        private const int IndicatesSpecial = 2;
        private static readonly Random random = new Random();

        public static string GeneratePassword(int numberOfAlphabetical, int numberOfNumerical, int numberOfSpecialCharacters)
        {
            IsInputValid(numberOfAlphabetical, numberOfNumerical, numberOfSpecialCharacters);
            
            // Note : I always start a password with an alphabetical letter as many 
            // systems do not allow special characters or numbers to begin a password
            var generatedPassword = SelectRandomCharacterFromCollection(Alphabetical); 

            var usedAlphabetical = 1;
            var usedNumerical = 0;
            var usedSpecial = 0;

            var charactersStillNeeded = new List<int>();
            if (usedAlphabetical < numberOfAlphabetical) charactersStillNeeded.Add(IndicatesAlphabetical);
            if (usedNumerical < numberOfNumerical) charactersStillNeeded.Add(IndicatesNumberical);
            if (usedSpecial < numberOfSpecialCharacters) charactersStillNeeded.Add(IndicatesSpecial);

            var passwordLength = numberOfAlphabetical + numberOfNumerical + numberOfSpecialCharacters;

            while (generatedPassword.Length < passwordLength)
            {
                var nextCharacter = random.Next(0, charactersStillNeeded.Count);
                nextCharacter = charactersStillNeeded[nextCharacter];

                if (nextCharacter == IndicatesAlphabetical)
                {
                    generatedPassword = generatedPassword + SelectRandomCharacterFromCollection(Alphabetical); 
                    usedAlphabetical++;
                    if (usedAlphabetical == numberOfAlphabetical) charactersStillNeeded.Remove(IndicatesAlphabetical);
                    continue;
                }
                if (nextCharacter == IndicatesNumberical)
                {
                    generatedPassword = generatedPassword + SelectRandomCharacterFromCollection(Numerical); 
                    usedNumerical++;
                    if (usedNumerical == numberOfNumerical) charactersStillNeeded.Remove(IndicatesNumberical); 
                    continue;
                }
                generatedPassword = generatedPassword + SelectRandomCharacterFromCollection(Special); 
                usedSpecial++;
                if (usedSpecial == numberOfSpecialCharacters) charactersStillNeeded.Remove(IndicatesSpecial);
            }

            return generatedPassword;
        }

        public static string GenerateStandardEightCharacterPassword()
        {
            const int alphabeticalCharacters = 5;
            const int numericalCharacters = 2;
            const int specialCharacters = 1;
            return GeneratePassword(alphabeticalCharacters, numericalCharacters, specialCharacters);
        }

        public static string GenerateStandardTwelveCharacterPassword()
        {
            const int alphabeticalCharacters = 6;
            const int numericalCharacters = 4;
            const int specialCharacters = 2;
            return GeneratePassword(alphabeticalCharacters, numericalCharacters, specialCharacters);
        }

        public static ICollection<String> GenerateXNumberOfPasswords(int numberOfPasswords,
            int numberOfAlphabetical, int numberOfNumerical, int numberOfSpecialCharacters)
        {
            IsAmountPositive(numberOfPasswords, "numberOfPasswords");

            var passwordList = new List<string>();

            for (int i = 0; i < numberOfPasswords; i++)
            {
                passwordList.Add(GeneratePassword(numberOfAlphabetical, numberOfNumerical, numberOfSpecialCharacters));
            }

            return passwordList;
        }

        public static string GenerateStandardPasswordPhrase()
        {
            var firstNoun = Words.Nouns[random.Next(0, Words.Nouns.Count)];
            var secondNoun = Words.Nouns[random.Next(0, Words.Nouns.Count)];
            var adjective = Words.Adjectives[random.Next(0, Words.Adjectives.Count)];
            var verb = Words.Verbs[random.Next(0, Words.Verbs.Count)];
            var specialCharacter = " ";
            return CreatePhrase(firstNoun, secondNoun, adjective, verb, specialCharacter);
        }

        public static string GeneratePasswordPhraseWithSpecialCharacterSeparator(string separator)
        {
            IsSeparatorValid(separator);
            var firstNoun = Words.Nouns[random.Next(0, Words.Nouns.Count)];
            var secondNoun = Words.Nouns[random.Next(0, Words.Nouns.Count)];
            var adjective = Words.Adjectives[random.Next(0, Words.Adjectives.Count)];
            var verb = Words.Verbs[random.Next(0, Words.Verbs.Count)];
            var specialCharacter = separator;
            return CreatePhrase(firstNoun, secondNoun, adjective, verb, specialCharacter);
        }

        public static string GeneratePasswordPhraseWithRandomSpecialCharacterSeparator()
        {
            var firstNoun = Words.Nouns[random.Next(0, Words.Nouns.Count)];
            var secondNoun = Words.Nouns[random.Next(0, Words.Nouns.Count)];
            var adjective = Words.Adjectives[random.Next(0, Words.Adjectives.Count)];
            var verb = Words.Verbs[random.Next(0, Words.Verbs.Count)];
            var specialCharacter = SelectRandomCharacterFromCollection(Special);
            return CreatePhrase(firstNoun, secondNoun, adjective, verb, specialCharacter);
        }

        public static ICollection<string> GenerateXNumberOfStandardPasswordPhrases(int numberOfPasswordPhrasesRequested)
        {
            IsAmountPositive(numberOfPasswordPhrasesRequested, "numberOfPasswordPhrasesRequested");
            var passwordPhraseList = new List<string>();

            for (int i = 0; i < numberOfPasswordPhrasesRequested; i++)
            {
                passwordPhraseList.Add(GenerateStandardPasswordPhrase());
            }

            return passwordPhraseList;
        }

        private static string CreatePhrase(string firstNoun, string secondNoun, string adjective, string verb, string specialCharacter)
        {
            return firstNoun + specialCharacter + verb + specialCharacter + adjective + specialCharacter + secondNoun;
        }

        private static string SelectRandomCharacterFromCollection(string collection)
        {
            return collection.Substring(random.Next(0, collection.Length), 1);
        }

        private static void IsInputValid(int numberOfAlphabetical, int numberOfNumerical, int numberOfSpecialCharacters)
        {
            if (numberOfAlphabetical < 1) throw new ArgumentOutOfRangeException("numberOfAlphabetical", "Must be greater than zero.");
            if (numberOfNumerical < 0) throw new ArgumentOutOfRangeException("numberOfNumerical", "Must be 0 or a positive number.");
            if (numberOfSpecialCharacters < 0) throw new ArgumentOutOfRangeException("numberOfSpecialCharacters", "Must be 0 or a positive number.");
        }

        private static void IsAmountPositive(int amountRequested, string parameterName)
        {
            if (amountRequested <= 0) throw new ArgumentOutOfRangeException(parameterName, "You must be request at least 1 or more!");
        }

        private static void IsSeparatorValid(string separator)
        {
            if (!Special.Contains(separator)) throw new ArgumentException("Separator", "Allowed values :   " + Special + "   : Supplied separator not allowed.");
        }

    }
}
