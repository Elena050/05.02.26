public class Calculator
{
    public double Add(double a, double b) => ValidateAndExecute(a, b, (x, y) => x + y);
    public double Multiply(double a, double b) => ValidateAndExecute(a, b, (x, y) => x * y);

    private double ValidateAndExecute(double a, double b, Func<double, double, double> operation)
    {
        ValidateNumbers(a, b);
        return operation(a, b);
    }

    private void ValidateNumbers(double a, double b)
    {
        if (double.IsNaN(a) || double.IsNaN(b))
            throw new ArgumentException("Invalid number");
        if (double.IsInfinity(a) || double.IsInfinity(b))
            throw new ArgumentException("Number is infinity");
    }
}
