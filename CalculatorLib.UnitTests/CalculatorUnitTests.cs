using System.Security.AccessControl;
using Xunit.Abstractions;

namespace CalculatorLib.UnitTests;

public class CalculatorUnitTests(
    ITestOutputHelper output
) {
    [Fact]
    public void TestAdding2And2() {
        // Arrange
        var a = 2d;
        var b = 2d;
        var expected = 4d;
        var calc = new Calculator();

        // Act
        var actual = calc.Add(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestAdding2And3() {
        // Arrange
        var a = 2d;
        var b = 3d;
        var expected = 5d;
        var calc = new Calculator();

        // Act
        var actual = calc.Add(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Factorize4() {
        var a = 4d;
        var calc = new Calculator();
        var expected = new[] { 2d, 2d };

        var actual = calc.Factorize(a).ToList();

        ContainsEqualElements(expected, actual);
        output.WriteLine("Expected: {0}", string.Join(' ', expected));
        output.WriteLine("Actual: {0}", string.Join(' ', actual));
    }

    [Fact]
    public void Factorize30() {
        var a = 30d;
        var calc = new Calculator();
        var expected = new[] { 5d, 3d, 2d };

        var actual = calc.Factorize(a).ToList();

        ContainsEqualElements(expected, actual);
        output.WriteLine("Expected: {0}", string.Join(' ', expected));
        output.WriteLine("Actual: {0}", string.Join(' ', actual));
    }

    public static void ContainsEqualElements<T>(IEnumerable<T> expected, IEnumerable<T> actual) {
        if (expected == null) {
            Xunit.Assert.Null(actual);
        }
        else {
            Xunit.Assert.Equal(expected.Count(), actual.Count());
            foreach (var item in actual) {
                Xunit.Assert.Contains(item, expected);
            }
        }
    }
}