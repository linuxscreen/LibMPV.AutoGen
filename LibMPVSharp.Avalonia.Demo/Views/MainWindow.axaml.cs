using Avalonia.Controls;
using Avalonia.Input;

namespace LibMPVSharp.Avalonia.Demo.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void InputElement_OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.N)
        {
            WindowState = WindowState.Normal;
            e.Handled = true;
        }

        if (e.Key == Key.F)
        {
            WindowState = WindowState.FullScreen;
            e.Handled = true;
        }
    }
}
