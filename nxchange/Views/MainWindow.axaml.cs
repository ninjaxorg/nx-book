using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace nxchange
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            
        }

        private void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            Console.WriteLine("CLICK");
        }
    }
    
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
}