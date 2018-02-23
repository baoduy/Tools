using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace ConfigEncryption.Controls
{
    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for FileBrowser.xaml
    /// </summary>
    public partial class FileBrowser : UserControl
    {
        public static readonly DependencyProperty FileNameProperty = DependencyProperty.Register(nameof(FileName), typeof(string), typeof(FileBrowser));

        public string FileName
        {
            get => GetValue(FileNameProperty)as string;
            set => SetValue(FileNameProperty, value);
        }

        private readonly OpenFileDialog _openFileDialog;
        public FileBrowser()
        {
            InitializeComponent();

            _openFileDialog = new OpenFileDialog
            {
                Filter = "Config Files|*.config"
            };
        }

        public event EventHandler Opened;

        protected virtual void OnOpen(EventArgs e) => this.Opened?.Invoke(this,e);

        private void Open_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FileName))
                _openFileDialog.FileName = this.FileName;

            if (_openFileDialog.ShowDialog() != true) return;

            this.FileName = _openFileDialog.FileName;
            this.OnOpen(EventArgs.Empty);
        }

        private void TextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FileName))
                Open_OnClick(sender, e);
            else ((TextBox)sender).SelectAll();
        }
    }
}
