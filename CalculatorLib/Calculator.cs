namespace CalculatorLib;

public class Calculator {
    public double Add(double a, double b) {
        return a + b;
    }

    public double Multiply(double a, double b) {
        return a * b;
    }

    public IEnumerable<double> Factorize(double input) {
        var i = 2;
        while (i * i <= input) {
            if (input % i == 0) {
                yield return i;
                input /= i;
            }
            else {
                i++;
            }
        }

        if (input > 1) {
            yield return input;
        }
    }
}