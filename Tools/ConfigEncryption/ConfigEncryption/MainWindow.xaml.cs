using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Win32;

namespace ConfigEncryption
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool Check()
        {
            var type = GetEncryptionType();

            if (string.IsNullOrWhiteSpace(FileBrowser.FileName))
            {
                MessageBox.Show("Config file is not found.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.FileBrowser.Focus();
                return false;
            }

            if (type == EncryptionType.Custom && string.IsNullOrWhiteSpace(TextBox.Text))
            {
                MessageBox.Show("Please specify the section name.", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                this.TextBox.Focus();
                return false;
            }

            return true;
        }

        private EncryptionType GetEncryptionType()
        {
            if (this.ComboBox.SelectedValue == null)
                return EncryptionType.All;

            switch (this.ComboBox.SelectedIndex)
            {
                case 1: return EncryptionType.AppSettings;
                case 2: return EncryptionType.ConnectionStrings;
                case 3: return EncryptionType.Custom;
                default: return EncryptionType.All;
            }
        }

        private Configuration GetConfiguration()
        {
            var configFileMap =
                new ExeConfigurationFileMap { ExeConfigFilename = this.FileBrowser.FileName };

            var config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            return config;
        }

        private void Decrypt_OnClick(object sender, RoutedEventArgs e)
        {
            if (!Check())
                return;

            try
            {
                var type = GetEncryptionType();
                var config = GetConfiguration();
                var customName = this.TextBox.Text;

                var sections = config.GetSections(type, customName).ToList();
                if (sections.Count <= 0)
                {
                    MessageBox.Show("There is no Section found.", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                foreach (var section in sections)
                {
                    if (!section.SectionInformation.IsProtected) continue;

                    section.SectionInformation.UnprotectSection();
                }

                config.Save();

                MessageBox.Show("The file had been unprotected successfully.", "Decryption", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                OpenFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot decrypt the config file: {ex.Message}", "Decryption", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void Encrypt_OnClick(object sender, RoutedEventArgs e)
        {
            if (!Check())
                return;

            try
            {
                var type = GetEncryptionType();
                var config = GetConfiguration();
                var customName = this.TextBox.Text;

                var sections = config.GetSections(type, customName).ToList();
                if (sections.Count <= 0)
                {
                    MessageBox.Show("There is no Section found.", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                foreach (var section in sections)
                {
                    if (section.SectionInformation.IsProtected) continue;

                    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                }

                config.Save();

                MessageBox.Show("The file had been protected successfully.", "Decryption", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                OpenFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot encrypt the config file: {ex.Message}", "Decryption", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void OpenFile()
        {
            var directory = Path.GetDirectoryName(this.FileBrowser.FileName);
            Process.Start(directory ?? throw new InvalidOperationException());
        }
    }
}
