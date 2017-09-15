using System.Windows;

namespace UI.Services
{
    internal class DialogService : IDialogService
    {
        public MessageBoxResult ShowDialog(
            string message, 
            string caption = "",
            MessageBoxButton button = MessageBoxButton.OK) => MessageBox.Show(message, caption, button);
    }
}
