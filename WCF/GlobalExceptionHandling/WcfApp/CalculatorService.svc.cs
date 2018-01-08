namespace WcfApp
{
    using System;
    using WcfApp.ErrorHandling;

    [DefaultErrorHandler]
    public class CalculatorService : ICalculatorService
    {
        public string GetData(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid number. Number must be >= 0");
            }

            return $"Number: {value}";
        }

        public decimal GetDataUsingDataContract(decimal a, decimal b)
        {
            return a / b;
        }
    }
}