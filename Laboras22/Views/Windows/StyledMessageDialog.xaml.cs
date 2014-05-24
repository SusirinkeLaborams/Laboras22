using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace Laboras22.Views.Windows
{
    /// <summary>
    /// Interaction logic for StyledMessageDialog.xaml
    /// </summary>
    public partial class StyledMessageDialog : MetroWindow
    {
        static StyledMessageDialog()
        {
        }

        public StyledMessageDialog(string message, string title, MessageBoxButton buttons)
        {
            InitializeComponent();

            Title = title;
            messageTextBlock.Text = message;

            switch (buttons)
            {
                case MessageBoxButton.OK:
                    VisualStateManager.GoToElementState(this.LayoutRoot, "StateOK", false);
                    break;
                case MessageBoxButton.YesNo:
                    VisualStateManager.GoToElementState(this.LayoutRoot, "StateYesNo", false);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Close();
        }

        public static bool? Show(string message, string title, MessageBoxButton buttons = MessageBoxButton.OK)
        {
            var dialog = new StyledMessageDialog(message, title, buttons);
            var result = dialog.ShowDialog();

            return result;
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
