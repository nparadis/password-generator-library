using System;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using RandomPasswordGenerator;

namespace Tests.RandomPasswordGenerator
{
    [TestFixture]
    public class PasswordGeneratorTests
    {
        [Test]
        public void GeneratePasswordReturnsAPasswordOfTheProperLength()
        {
            // Arrange
            const int numberOfAlphabetical = 7;
            const int numberOfNumberical = 3;
            const int numberOfSpecialCharacters = 2;
            const int passwordLength = 12;
            const int expected = passwordLength;

            // Act
            var testPassword = PasswordGenerator.GeneratePassword(numberOfAlphabetical, numberOfNumberical, numberOfSpecialCharacters);
            var actual = testPassword.Length;
            var actualNumberOfAlphabetical = GetAlphabeticalOnlyCount(testPassword);
            var actualNumberOfNumerical = GetDigitsOnlyCount(testPassword);
            var actualNumberofSpecialCharacters = testPassword.Length - (actualNumberOfAlphabetical + actualNumberOfNumerical);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(numberOfAlphabetical, actualNumberOfAlphabetical);
            Assert.AreEqual(numberOfNumberical, actualNumberOfNumerical);
            Assert.AreEqual(numberOfSpecialCharacters, actualNumberofSpecialCharacters);
        }



        [Test]
        public void GeneratePasswordWithZeroNumericalWorks()
        {
            // Arrange
            const int numberOfAlphabetical = 10;
            const int numberOfNumberical = 0;
            const int numberOfSpecialCharacters = 2;
            const int passwordLength = 12;
            const int expected = passwordLength;

            // Act
            var testPassword = PasswordGenerator.GeneratePassword(numberOfAlphabetical, numberOfNumberical, numberOfSpecialCharacters);
            var actual = testPassword.Length;
            var actualNumberOfAlphabetical = GetAlphabeticalOnlyCount(testPassword);
            var actualNumberOfNumerical = GetDigitsOnlyCount(testPassword);
            var actualNumberofSpecialCharacters = testPassword.Length - (actualNumberOfAlphabetical + actualNumberOfNumerical);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(numberOfAlphabetical, actualNumberOfAlphabetical);
            Assert.AreEqual(numberOfNumberical, actualNumberOfNumerical);
            Assert.AreEqual(numberOfSpecialCharacters, actualNumberofSpecialCharacters);
        }

        [Test]
        public void GeneratePasswordWithZeroSpecialCharactersWorks()
        {
            // Arrange
            const int numberOfAlphabetical = 8;
            const int numberOfNumberical = 4;
            const int numberOfSpecialCharacters = 0;
            const int passwordLength = 12;
            const int expected = passwordLength;

            // Act
            var testPassword = PasswordGenerator.GeneratePassword(numberOfAlphabetical, numberOfNumberical, numberOfSpecialCharacters);
            var actual = testPassword.Length;
            var actualNumberOfAlphabetical = GetAlphabeticalOnlyCount(testPassword);
            var actualNumberOfNumerical = GetDigitsOnlyCount(testPassword);
            var actualNumberofSpecialCharacters = testPassword.Length - (actualNumberOfAlphabetical + actualNumberOfNumerical);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(numberOfAlphabetical, actualNumberOfAlphabetical);
            Assert.AreEqual(numberOfNumberical, actualNumberOfNumerical);
            Assert.AreEqual(numberOfSpecialCharacters, actualNumberofSpecialCharacters);
        }

        [Test]
        public void GeneratePasswordWithZeroNumericalAndZeroSpecialCharactersWorks()
        {
            // Arrange
            const int numberOfAlphabetical = 12;
            const int numberOfNumberical = 0;
            const int numberOfSpecialCharacters = 0;
            const int passwordLength = 12;
            const int expected = passwordLength;

            // Act
            var testPassword = PasswordGenerator.GeneratePassword(numberOfAlphabetical, numberOfNumberical, numberOfSpecialCharacters);
            var actual = testPassword.Length;
            var actualNumberOfAlphabetical = GetAlphabeticalOnlyCount(testPassword);
            var actualNumberOfNumerical = GetDigitsOnlyCount(testPassword);
            var actualNumberofSpecialCharacters = testPassword.Length - (actualNumberOfAlphabetical + actualNumberOfNumerical);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(numberOfAlphabetical, actualNumberOfAlphabetical);
            Assert.AreEqual(numberOfNumberical, actualNumberOfNumerical);
            Assert.AreEqual(numberOfSpecialCharacters, actualNumberofSpecialCharacters);
        }

        [Test]
        public void GeneratePasswordOfOnlyOneAlphabeticalCharacterWorks()
        {
            // Arrange
            const int numberOfAlphabetical = 1;
            const int numberOfNumberical = 0;
            const int numberOfSpecialCharacters = 0;
            const int passwordLength = 1;
            const int expected = passwordLength;

            // Act
            var testPassword = PasswordGenerator.GeneratePassword(numberOfAlphabetical, numberOfNumberical, numberOfSpecialCharacters);
            var actual = testPassword.Length;
            var actualNumberOfAlphabetical = GetAlphabeticalOnlyCount(testPassword);
            var actualNumberOfNumerical = GetDigitsOnlyCount(testPassword);
            var actualNumberofSpecialCharacters = testPassword.Length - (actualNumberOfAlphabetical + actualNumberOfNumerical);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(numberOfAlphabetical, actualNumberOfAlphabetical);
            Assert.AreEqual(numberOfNumberical, actualNumberOfNumerical);
            Assert.AreEqual(numberOfSpecialCharacters, actualNumberofSpecialCharacters);
        }

        [Test]
        public void GeneratePasswordWith1024CharactersWorks()
        {
            // Arrange
            const int numberOfAlphabetical = 800;
            const int numberOfNumberical = 200;
            const int numberOfSpecialCharacters = 24;
            const int passwordLength = 1024;
            const int expected = passwordLength;

            // Act
            var testPassword = PasswordGenerator.GeneratePassword(numberOfAlphabetical, numberOfNumberical, numberOfSpecialCharacters);
            var actual = testPassword.Length;
            var actualNumberOfAlphabetical = GetAlphabeticalOnlyCount(testPassword);
            var actualNumberOfNumerical = GetDigitsOnlyCount(testPassword);
            var actualNumberofSpecialCharacters = testPassword.Length - (actualNumberOfAlphabetical + actualNumberOfNumerical);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(numberOfAlphabetical, actualNumberOfAlphabetical);
            Assert.AreEqual(numberOfNumberical, actualNumberOfNumerical);
            Assert.AreEqual(numberOfSpecialCharacters, actualNumberofSpecialCharacters);
        }

        [Test]
        public void GeneratePasswordUsingGenerateStandardEightCharacterPassword()
        {
            // Arrange
            const int expectedNumberOfAlphabetical = 5;
            const int expectedNumberOfNumberical = 2;
            const int expectedNumberOfSpecialCharacters = 1;
            const int passwordLength = 8;
            const int expected = passwordLength;

            // Act
            var testPassword = PasswordGenerator.GenerateStandardEightCharacterPassword();
            var actualNumberOfAlphabetical = GetAlphabeticalOnlyCount(testPassword);
            var actualNumberOfNumerical = GetDigitsOnlyCount(testPassword);
            var actualNumberOfSpecialCharacters = testPassword.Length - (actualNumberOfAlphabetical + actualNumberOfNumerical);
            var actual = actualNumberOfAlphabetical + actualNumberOfNumerical + actualNumberOfSpecialCharacters;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedNumberOfAlphabetical, actualNumberOfAlphabetical);
            Assert.AreEqual(expectedNumberOfNumberical, actualNumberOfNumerical);
            Assert.AreEqual(expectedNumberOfSpecialCharacters, actualNumberOfSpecialCharacters);
        }

        [Test]
        public void GeneratePasswordUsingGenerateStandardTwelveCharacterPassword()
        {
            // Arrange
            const int expectedNumberOfAlphabetical = 6;
            const int expectedNumberOfNumberical = 4;
            const int expectedNumberOfSpecialCharacters = 2;
            const int passwordLength = 12;
            const int expected = passwordLength;

            // Act
            var testPassword = PasswordGenerator.GenerateStandardTwelveCharacterPassword();
            var actualNumberOfAlphabetical = GetAlphabeticalOnlyCount(testPassword);
            var actualNumberOfNumerical = GetDigitsOnlyCount(testPassword);
            var actualNumberOfSpecialCharacters = testPassword.Length - (actualNumberOfAlphabetical + actualNumberOfNumerical);
            var actual = actualNumberOfAlphabetical + actualNumberOfNumerical + actualNumberOfSpecialCharacters;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedNumberOfAlphabetical, actualNumberOfAlphabetical);
            Assert.AreEqual(expectedNumberOfNumberical, actualNumberOfNumerical);
            Assert.AreEqual(expectedNumberOfSpecialCharacters, actualNumberOfSpecialCharacters);
        }

        [Test]
        public void GenerateFiftyPasswordsReturnsAListOfPasswordsOfTheProperAmountAndType()
        {
            // Arrange
            const int numberOfPasswords = 50;
            const int numberOfAlphabetical = 7;
            const int numberOfNumberical = 3;
            const int numberOfSpecialCharacters = 2;
            const int passwordLength = 12;
            const bool expectedAllPasswordsMatchedRequirements = true;
            var actualAllPasswordsMatchedRequirements = true;

            // Act
            var testPasswordList = PasswordGenerator.GenerateXNumberOfPasswords(numberOfPasswords, numberOfAlphabetical, numberOfNumberical, numberOfSpecialCharacters);
            foreach (var testPassword in testPasswordList)
            {
                if (testPassword.Length != passwordLength) actualAllPasswordsMatchedRequirements = false;
                if (GetAlphabeticalOnlyCount(testPassword) != numberOfAlphabetical) actualAllPasswordsMatchedRequirements = false;
                if (GetDigitsOnlyCount(testPassword) != numberOfNumberical) actualAllPasswordsMatchedRequirements = false;
                var testPasswordsNumberOfSpecialCharacters = testPassword.Length -
                                                             (GetAlphabeticalOnlyCount(testPassword) +
                                                              GetDigitsOnlyCount(testPassword));
                if (testPasswordsNumberOfSpecialCharacters != numberOfSpecialCharacters) actualAllPasswordsMatchedRequirements = false;
            }
            var actualNumberOfPasswords = testPasswordList.Count();

            // Assert
            Assert.AreEqual(actualNumberOfPasswords, numberOfPasswords);
            Assert.AreEqual(expectedAllPasswordsMatchedRequirements, actualAllPasswordsMatchedRequirements);
        }

        [Test]
        public void GenerateStandardPasswordPhraseValid()
        {
            // Arrange
            const int expected = 4;

            // Act
            var testPasswordPhrase = PasswordGenerator.GenerateStandardPasswordPhrase();
            var words = testPasswordPhrase.Split(' ');
            var actual = words.Count();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GeneratePasswordPhraseWithSpecialCharacterSeparatorValid()
        {
            // Arrange
            const int expected = 4;
            const string specialCharacter = "^";

            // Act
            var testPasswordPhrase =
                PasswordGenerator.GeneratePasswordPhraseWithSpecialCharacterSeparator(specialCharacter);
            var words = testPasswordPhrase.Split('^');
            var actual = words.Count();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GeneratePasswordPhraseWithSpecialCharacterSeparatorSpace()
        {
            // Arrange
            const int expected = 4;
            const string specialCharacter = " ";

            // Act
            var testPasswordPhrase =
                PasswordGenerator.GeneratePasswordPhraseWithSpecialCharacterSeparator(specialCharacter);
            var words = testPasswordPhrase.Split(' ');
            var actual = words.Count();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GeneratePasswordPhraseWithRandomSpecialCharacterSeparatorValid()
        {
            // Arrange
            const int expected = 4;

            // Act
            var testPasswordPhrase = PasswordGenerator.GeneratePasswordPhraseWithRandomSpecialCharacterSeparator();
            
            // Assert
            Assert.IsNotNullOrEmpty(testPasswordPhrase);
        }

        [Test]
        public void GeneratePasswordPhraseWithThreeLetterWordsReturnsAThreeLetterWordPasswordPhraseValid()
        {
            // Arrange
            const bool expectedAllThreeLetterWords = true;

            // Act
            var actualWordsAreAllThreeLetterWords = true;
            var testPasswordPhrase = PasswordGenerator.GenerateStandardPasswordPhraseWithThreeLetterWords();
            var words = testPasswordPhrase.Split(' ');
            foreach (var word in words)
            {
                if (word.Length != 3) actualWordsAreAllThreeLetterWords = false;
            }

            // Assert
            Assert.AreEqual(expectedAllThreeLetterWords, actualWordsAreAllThreeLetterWords);
        }

        [Test]
        public void GeneratePasswordPhraseWithFourLetterWordsReturnsAFourLetterWordPasswordPhraseValid()
        {
            // Arrange
            const bool expectedAllFourLetterWords = true;

            // Act
            var actualWordsAreAllFourLetterWords = true;
            var testPasswordPhrase = PasswordGenerator.GenerateStandardPasswordPhraseWithFourLetterWords();
            var words = testPasswordPhrase.Split(' ');
            foreach (var word in words)
            {
                if (word.Length != 4) actualWordsAreAllFourLetterWords = false;
            }

            // Assert
            Assert.AreEqual(expectedAllFourLetterWords, actualWordsAreAllFourLetterWords);
        }

        [Test]
        public void GeneratePasswordPhraseWithFiveLetterWordsReturnsAFiveLetterWordPasswordPhraseValid()
        {
            // Arrange
            const bool expectedAllFiveLetterWords = true;

            // Act
            var actualWordsAreAllFiveLetterWords = true;
            var testPasswordPhrase = PasswordGenerator.GenerateStandardPasswordPhraseWithFiveLetterWords();
            var words = testPasswordPhrase.Split(' ');
            foreach (var word in words)
            {
                if (word.Length != 5) actualWordsAreAllFiveLetterWords = false;
            }

            // Assert
            Assert.AreEqual(expectedAllFiveLetterWords, actualWordsAreAllFiveLetterWords);
        }

        [Test]
        public void GenerateXNumberOfPasswordPhrasesReturnsAListOfTheRightAmountOfRandomPasswordPhrasesValid()
        {
            // Arrange
            const int expected = 25;

            // Act
            var testPasswordPhrases = PasswordGenerator.GenerateXNumberOfStandardPasswordPhrases(25, SizeOfWords.Random);
            var actual = testPasswordPhrases.Count();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GenerateXNumberOfPasswordPhrasesReturnsAListOfTheRightAmountOfThreeLetterPasswordPhrasesValid()
        {
            // Arrange
            const int expected = 25;
            const bool expectedAllThreeLetterWords = true;

            // Act
            var actualWordsAreAllThreeLetterWords = true;
            var testPasswordPhrases = PasswordGenerator.GenerateXNumberOfStandardPasswordPhrases(25, SizeOfWords.ThreeLetter);
            foreach (var phrase in testPasswordPhrases)
            {
                var words = phrase.Split(' ');
                foreach (var word in words)
                {
                    if (word.Length != 3) actualWordsAreAllThreeLetterWords = false;
                }
            }
            var actual = testPasswordPhrases.Count();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedAllThreeLetterWords, actualWordsAreAllThreeLetterWords);
        }

        [Test]
        public void GenerateXNumberOfPasswordPhrasesReturnsAListOfTheRightAmountOfFourLetterPasswordPhrasesValid()
        {
            // Arrange
            const int expected = 25;
            const bool expectedAllFourLetterWords = true;

            // Act
            var actualWordsAreAllFourLetterWords = true;
            var testPasswordPhrases = PasswordGenerator.GenerateXNumberOfStandardPasswordPhrases(25, SizeOfWords.FourLetter);
            foreach (var phrase in testPasswordPhrases)
            {
                var words = phrase.Split(' ');
                foreach (var word in words)
                {
                    if (word.Length != 4) actualWordsAreAllFourLetterWords = false;
                }
            }
            var actual = testPasswordPhrases.Count();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedAllFourLetterWords, actualWordsAreAllFourLetterWords);
        }

        [Test]
        public void GenerateXNumberOfPasswordPhrasesReturnsAListOfTheRightAmountOfFiveLetterPasswordPhrasesValid()
        {
            // Arrange
            const int expected = 25;
            const bool expectedAllFiveLetterWords = true;

            // Act
            var actualWordsAreAllFiveLetterWords = true;
            var testPasswordPhrases = PasswordGenerator.GenerateXNumberOfStandardPasswordPhrases(25, SizeOfWords.FiveLetter);
            foreach (var phrase in testPasswordPhrases)
            {
                var words = phrase.Split(' ');
                foreach (var word in words)
                {
                    if (word.Length != 5) actualWordsAreAllFiveLetterWords = false;
                }
            }
            var actual = testPasswordPhrases.Count();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedAllFiveLetterWords, actualWordsAreAllFiveLetterWords);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GeneratePasswordWithZeroAlphabeticalCausesArgumentOutOfRangeException()
        {
            // Arrange
            const int numberOfAlphabetical = 0;
            const int numberOfNumberical = 12;
            const int numberOfSpecialCharacters = 0;

            // Act
            var testPassword = PasswordGenerator.GeneratePassword(numberOfAlphabetical, numberOfNumberical, numberOfSpecialCharacters);

            // Assert is Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GeneratePasswordWithNegatieAlphabeticalCausesArgumentOutOfRangeException()
        {
            // Arrange
            const int numberOfAlphabetical = -5;
            const int numberOfNumberical = 12;
            const int numberOfSpecialCharacters = 5;

            // Act
            var testPassword = PasswordGenerator.GeneratePassword(numberOfAlphabetical, numberOfNumberical, numberOfSpecialCharacters);


            // Assert is Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GeneratePasswordWithNegativeNumericalCausesArgumentOutOfRangeException()
        {
            // Arrange
            const int numberOfAlphabetical = 10;
            const int numberOfNumberical = -4;
            const int numberOfSpecialCharacters = 6;

            // Act
            var testPassword = PasswordGenerator.GeneratePassword(numberOfAlphabetical, numberOfNumberical, numberOfSpecialCharacters);

            // Assert is Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GeneratePasswordWithNegativeSpecialCausesArgumentOutOfRangeException()
        {
            // Arrange
            const int numberOfAlphabetical = 12;
            const int numberOfNumberical = 6;
            const int numberOfSpecialCharacters = -6;

            // Act
            var testPassword = PasswordGenerator.GeneratePassword(numberOfAlphabetical, numberOfNumberical, numberOfSpecialCharacters);

            // Assert is Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateXNumberOfPasswordsWithZeroQuantityThrowsArgumentOutOfRangeException()
        {
            // Arrange
            const int numberOfPasswords = 0;
            const int numberOfAlphabetical = 12;
            const int numberOfNumberical = 6;
            const int numberOfSpecialCharacters = 2;

            // Act
            var testPassword = PasswordGenerator.GenerateXNumberOfPasswords(numberOfPasswords, numberOfAlphabetical, numberOfNumberical, numberOfSpecialCharacters);

            // Assert is Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateXNumberOfPasswordsWithNegativeQuantityThrowsArgumentOutOfRangeException()
        {
            // Arrange
            const int numberOfPasswords = -10;
            const int numberOfAlphabetical = 12;
            const int numberOfNumberical = 6;
            const int numberOfSpecialCharacters = 2;

            // Act
            var testPassword = PasswordGenerator.GenerateXNumberOfPasswords(numberOfPasswords, numberOfAlphabetical, numberOfNumberical, numberOfSpecialCharacters);

            // Assert is Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GeneratePasswordPhraseWithSpecialCharacterSeparatorInvalidSeparatorThrowsException()
        {
            // Arrange
            const string specialCharacter = "|";

            // Act
            var testPasswordPhrase =
                PasswordGenerator.GeneratePasswordPhraseWithSpecialCharacterSeparator(specialCharacter);

            // Assert
            // Assert is Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateXNumberOfPasswordPhrasesWithNegativeQuantityThrowsArgumentOutOfRangeException()
        {
            // Arrange
            const int numberOfPasswordPhrases = -10;

            // Act
            var testPassword = PasswordGenerator.GenerateXNumberOfStandardPasswordPhrases(numberOfPasswordPhrases, SizeOfWords.Random);

            // Assert is Exception
        }

        private int GetAlphabeticalOnlyCount(string password)
        {
            const string lettersOnly = "^[a-zA-Z]$";
            var characters = password.ToCharArray();
            return characters.Count(x => Regex.IsMatch(x.ToString(), lettersOnly));
        }

        private int GetDigitsOnlyCount(string password)
        {
            var digitsOnly = Regex.Replace(password, @"\D", string.Empty);
            return digitsOnly.Count();
        }
    }
}
