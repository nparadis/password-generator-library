using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RandomPasswordGenerator;

namespace WPF_PasswordGeneratorSampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> PasswordList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            cbox_generatemethods.ItemsSource = Enum.GetValues(typeof (GenerateMethods)).Cast<GenerateMethods>();
            Passwords.ItemsSource = PasswordList;
        }

        private void btn_generate_Click(object sender, RoutedEventArgs e)
        {
            var selected = cbox_generatemethods.SelectedValue;

            if (selected.ToString() == GenerateMethods.GenerateStandardEightCharacterPassword.ToString())
            {
                PasswordList.Clear();
                PasswordList.Add(PasswordGenerator.GenerateStandardEightCharacterPassword());
                Passwords.Items.Refresh();
            }

            if (selected.ToString() == GenerateMethods.GenerateTwentyTwelveCharacterPasswords.ToString())
            {
                PasswordList.Clear();
                PasswordList.AddRange(PasswordGenerator.GenerateXNumberOfPasswords(20,6,4,2));
                Passwords.Items.Refresh();
            }

            if (selected.ToString() == GenerateMethods.GenerateTwentyRandomPasswordPhrases.ToString())
            {
                PasswordList.Clear();
                PasswordList.AddRange(PasswordGenerator.GenerateXNumberOfStandardPasswordPhrases(20, SizeOfWords.Random));
                Passwords.Items.Refresh();
            }

            if (selected.ToString() == GenerateMethods.GenerateTwentyFourLetterWordPasswordPhrases.ToString())
            {
                PasswordList.Clear();
                PasswordList.AddRange(PasswordGenerator.GenerateXNumberOfStandardPasswordPhrases(20, SizeOfWords.FourLetter));
                Passwords.Items.Refresh();
            }


        }

        public enum GenerateMethods
        {
            GeneratePasswordAllAlphabetical,
            GeneratePassword4Alpha4Numerical2Special,
            GenerateStandardEightCharacterPassword,
            GenerateStandardTwelveCharacterPassword,
            GenerateTwentyTwelveCharacterPasswords,
            GenerateStandardPasswordPhrase,
            GeneratePasswordPhraseWith3LetterWords,
            GeneratePasswordPhraseWith4LetterWords,
            GeneratePasswordPhraseWith5LetterWords,
            GeneratePasswordPhraseWithNumberSignSeparator,
            GeneratePasswordPhraseWithAsteriskSeparator,
            GeneratePasswordPhraseWithRandomSpecialSeparator,
            GenerateTwentyRandomPasswordPhrases,
            GenerateTwentyFourLetterWordPasswordPhrases
        }


    }
}
