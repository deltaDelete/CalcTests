using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using CalculatorLib;
using ReactiveUI;

namespace CalculatorApp.ViewModels;

public class MainWindowViewModel : ViewModelBase {
    private double _firstNumber = 0;
    private double _secondNumber = 0;
    private Calculator _calculator = new Calculator();
    private double _result;
    private ObservableAsPropertyHelper<string> _resultString;
    private ObservableAsPropertyHelper<string> _factorized;
    private double _factorizeNumber;

    public double? FirstNumber {
        get => _firstNumber;
        set => this.RaiseAndSetIfChanged(ref _firstNumber, value ?? 0);
    }

    public double? SecondNumber {
        get => _secondNumber;
        set => this.RaiseAndSetIfChanged(ref _secondNumber, value ?? 0);
    }

    public double Result {
        get => _result;
        set => this.RaiseAndSetIfChanged(ref _result, value);
    }
    
    public double? FactorizeNumber {
        get => _factorizeNumber;
        set => this.RaiseAndSetIfChanged(ref _factorizeNumber, value ?? 0);
    }

    public string ResultString => _resultString.Value;
    public string Factorized => _factorized.Value;

    public ReactiveCommand<Unit, Unit> MultiplyCommand { get; }

    public MainWindowViewModel() {
        MultiplyCommand = ReactiveCommand.Create(Multiply);
        _resultString = this.WhenAnyValue(x => x.FirstNumber, x => x.SecondNumber)
            .Where(x => x is { Item1: not null, Item2: not null })
            .Select(x => $"Результат: {_calculator.Multiply(x.Item1 ?? 0, x.Item2 ?? 0)}")
            .ToProperty(this, x => x.ResultString, true);
        
        _factorized = this.WhenAnyValue(x => x.FactorizeNumber)
            .Select(x => $"Результат: {string.Join('*', _calculator.Factorize(x ?? 0).ToList())}")
            .ToProperty(this, x => x.Factorized, true);
    }

    private void Multiply() {
        Result = _calculator.Multiply(FirstNumber ?? 0, SecondNumber ?? 0);
    }
}