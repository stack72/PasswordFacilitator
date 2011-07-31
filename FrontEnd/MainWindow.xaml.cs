using System;
using System.Collections.Generic;
using System.Windows;
using PasswordGeneration;
using PasswordGeneration.Entities;
using PasswordGeneration.ExtensionMethods;

namespace PasswordFacility
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            CreatePasswordOptions();
        }

        private void CreatePasswordOptions()
        {
            var ListData = new List<PasswordCreationTypes>
                               {
                                   new PasswordCreationTypes {Value = "1", DisplayText = "Alpha Lower"},
                                   new PasswordCreationTypes {Value = "2", DisplayText = "Alpha Upper"},
                                   new PasswordCreationTypes {Value = "3", DisplayText = "Alpha Lower + Upper"},
                                   new PasswordCreationTypes {Value = "4", DisplayText = "Digit"},
                                   new PasswordCreationTypes {Value = "5", DisplayText = "Alpha Numeric Lower"},
                                   new PasswordCreationTypes {Value = "6", DisplayText = "Alpha Numeric Upper"},
                                   new PasswordCreationTypes {Value = "7", DisplayText = "Alpha Numeric Lower + Upper"},
                                   new PasswordCreationTypes {Value = "8", DisplayText = "Special"},
                                   new PasswordCreationTypes {Value = "15", DisplayText = "Alpha Numeric Special"}
                               };

            cmbPsswordOptions.ItemsSource = ListData;
            cmbPsswordOptions.DisplayMemberPath = "DisplayText";
            cmbPsswordOptions.SelectedValuePath = "Value";

            cmbPsswordOptions.SelectedValue = "1";
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            var passLength = cmbPasswordLength.Text;
            var passwordOptions = (CharacterTypes)Enum.Parse(typeof(CharacterTypes), cmbPsswordOptions.SelectedValue.ToString());

            var passwordGenerator = new RandomPasswordGenerator();
            var generatedPassword = passwordGenerator.Generate(int.Parse(passLength), passwordOptions);
            

            txtPasswordResult.Text = generatedPassword.ConvertToPlainTextString();
        }
    }

    public class PasswordCreationTypes
    {
        public string Value { get; set; }
        public string DisplayText { get; set; }
    }
}
