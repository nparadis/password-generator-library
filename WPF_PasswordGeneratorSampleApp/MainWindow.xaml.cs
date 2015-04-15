using RandomPasswordGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WPF_PasswordGeneratorSampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> _passwordList;

        public List<string> PasswordList
        {
            get { return _passwordList; }
            set
            {
                _passwordList = value;
                NotifyPropertyChanged();
            }
        }

        private GenerateMethod _selectedMethod;

        public GenerateMethod SelectedMethod
        {
            get { return _selectedMethod; }
            set
            {
                _selectedMethod = value;
                NotifyPropertyChanged();
            }
        }


        private List<GenerateMethod> _generateMethods;

        public List<GenerateMethod> GenerateMethods
        {
            get { return _generateMethods; }
            set
            {
                _generateMethods = value;
                NotifyPropertyChanged();
            }
        }



        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            
            PasswordList = new List<string>();
            
            GenerateMethods = new List<GenerateMethod>();
            SetGenerateMethods();
        }

        private void btn_generate_Click(object sender, RoutedEventArgs e)
        {
            PasswordList.Clear();

            switch (SelectedMethod.Id)
            {
                case 0:
                    {
                        PasswordList.Add(PasswordGenerator.GeneratePassword(8, 0, 0));
                    }
                    break;
                case 1:
                    {
                        PasswordList.Add(PasswordGenerator.GeneratePassword(4, 4, 2));
                    }
                    break;
                case 2:
                    {
                        PasswordList.Add(PasswordGenerator.GenerateStandardEightCharacterPassword());
                    }
                    break;
                case 3:
                    {
                        PasswordList.Add(PasswordGenerator.GenerateStandardTwelveCharacterPassword());
                    }
                    break;
                case 4:
                    {
                        PasswordList.Add(PasswordGenerator.GeneratePassword(6, 2, 0));
                    }
                    break;
                case 5:
                    {
                        PasswordList.Add(PasswordGenerator.GeneratePassword(8, 4, 0));
                    }
                    break;
                case 6:
                    {
                        PasswordList.Add(PasswordGenerator.GenerateStandardPasswordPhrase());
                    }
                    break;
                case 7:
                    {
                        PasswordList.Add(PasswordGenerator.GenerateStandardPasswordPhraseWithThreeLetterWords());
                    }
                    break;
                case 8:
                    {
                        PasswordList.Add(PasswordGenerator.GenerateStandardPasswordPhraseWithFourLetterWords());
                    }
                    break;
                case 9:
                    {
                        PasswordList.Add(PasswordGenerator.GenerateStandardPasswordPhraseWithFiveLetterWords());
                    }
                    break;
                case 10:
                    {
                        PasswordList.Add(PasswordGenerator.GeneratePasswordPhraseWithSpecialCharacterSeparator("#"));
                    }
                    break;
                case 11:
                {
                    PasswordList.Add(PasswordGenerator.GeneratePasswordPhraseWithSpecialCharacterSeparator("^"));
                }
                    break;
                case 12:
                {
                    PasswordList.Add(PasswordGenerator.GeneratePasswordPhraseWithRandomSpecialCharacterSeparator());
                }
                    break;
                case 13:
                    {
                        PasswordList.AddRange(PasswordGenerator.GenerateXNumberOfPasswords(10,5,2,1));
                    }
                    break;
                case 14:
                    {
                        PasswordList.AddRange(PasswordGenerator.GenerateXNumberOfPasswords(10, 7, 3, 2));
                    }
                    break;
            }

            Passwords.Items.Refresh();
        }

        private void SetGenerateMethods()
        {
            GenerateMethods.Add(new GenerateMethod { Id = 0, Name  = "Generate 1 All Alphabetical Password"});
            GenerateMethods.Add(new GenerateMethod { Id = 1, Name  = "Generate 1 Password Alpha:4 Num:4 Special:2"});
            GenerateMethods.Add(new GenerateMethod { Id = 2, Name  = "Generate Standard Eight Character Password"});
            GenerateMethods.Add(new GenerateMethod { Id = 3, Name  = "Generate Standard Twelve Character Password"});
            GenerateMethods.Add(new GenerateMethod { Id = 4, Name  = "Generate 1 x 8 Char AlphaNumeric Password"});
            GenerateMethods.Add(new GenerateMethod { Id = 5, Name  = "Generate 1 x 12 Char AlphaNumeric Password"});
            GenerateMethods.Add(new GenerateMethod { Id = 6, Name  = "Generate Standard Password Phrase"});
            GenerateMethods.Add(new GenerateMethod { Id = 7, Name  = "Generate Password Phrase with 3 Letter Words"});
            GenerateMethods.Add(new GenerateMethod { Id = 8, Name = "Generate Password Phrase with 4 Letter Words"});
            GenerateMethods.Add(new GenerateMethod { Id = 9, Name = "Generate Password Phrase with 5 Letter Words"});
            GenerateMethods.Add(new GenerateMethod { Id = 10, Name = "Generate Password Phrase with # Separator"});
            GenerateMethods.Add(new GenerateMethod { Id = 11, Name = "Generate Password Phrase with ^ Separator"});
            GenerateMethods.Add(new GenerateMethod { Id = 12, Name = "Generate Password Phrase with Random Separator"});
            GenerateMethods.Add(new GenerateMethod { Id = 13, Name = "Generate 10 x Standard Eight Character Passwords" });
            GenerateMethods.Add(new GenerateMethod { Id = 14, Name = "Generate 10 x Standard Twelve Character Passwords" });
        }

        public class GenerateMethod
        {
            public byte Id { get; set; }
            public string Name { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Passwords.SelectedItem == null) return;
            Clipboard.SetText(Passwords.SelectedItem.ToString());
        }

        #region INotifyPropertyChanged

        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

    }
}
