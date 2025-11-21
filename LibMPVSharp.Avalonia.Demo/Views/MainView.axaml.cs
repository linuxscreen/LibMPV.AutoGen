using System;
using Avalonia.Controls;
using Avalonia.Input;
using LibMPVSharp.Avalonia.Demo.ViewModels;

namespace LibMPVSharp.Avalonia.Demo.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void InputElement_OnKeyDown(object? sender, KeyEventArgs e)
    {
        Console.WriteLine("Key Down: " + e.Key);
        // ControlPanel;
        if (e.Key == Key.P)
        {
            MediaPlayerView.SetPanelVisible(!MediaPlayerView.GetPanelVisible());
        }
    }
}
