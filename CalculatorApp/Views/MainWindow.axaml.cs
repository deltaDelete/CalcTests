using Avalonia.Controls;
using Avalonia.ReactiveUI;
using CalculatorApp.ViewModels;

namespace CalculatorApp.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel> {
    public MainWindow() {
        InitializeComponent();
        ViewModel = new();
    }
}