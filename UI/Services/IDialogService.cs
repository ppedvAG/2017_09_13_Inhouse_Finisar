using System.Windows;

namespace UI.Services
{
    internal interface IDialogService
    {
        MessageBoxResult ShowDialog(
            string message,
            string caption = "",
            MessageBoxButton button = MessageBoxButton.OK);
    }
}