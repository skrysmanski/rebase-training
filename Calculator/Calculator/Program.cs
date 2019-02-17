using System;
using System.Globalization;
using JetBrains.Annotations;

namespace Calculator
{
    internal static class Program
    {
        private enum Operator
        {
            Add,
            Subtract,
            Multiply,
            Divide,
        }

        private static void Main()
        {
            Console.WriteLine("Welcome to Calculator. Please enter your calculation.");
            Console.WriteLine();

            decimal operand1 = ReadNumber("Number 1");
            Operator @operator = ReadOperator("Operator");
            decimal operand2 = ReadNumber("Number 2");

            decimal result;

            switch (@operator)
            {
                case Operator.Add:
                    result = RunAdd(operand1, operand2);
                    break;

                case Operator.Multiply:
                    result = RunMultiply(operand1, operand2);
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine($"ERROR: Operator '{@operator}' is not yet implemented.");
                    return;
            }

            Console.WriteLine();
            Console.WriteLine("Result: " + result.ToString(CultureInfo.InvariantCulture));
        }

        [Pure]
        private static decimal RunAdd(decimal operand1, decimal operand2)
        {
            return operand1 + operand2;
        }

        [Pure]
        private static decimal RunMultiply(decimal operand1, decimal operand2)
        {
            return operand1 * operand2;
        }

        [Pure]
        private static decimal ReadNumber([NotNull] string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                string line = Console.ReadLine();
                if (decimal.TryParse(line, NumberStyles.Any, CultureInfo.InvariantCulture, out var number))
                {
                    return number;
                }

                Console.WriteLine($"ERROR: '{line}' is not a number.");
            }
        }

        [Pure]
        private static Operator ReadOperator([NotNull] string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                string line = Console.ReadLine();

                switch (line?.Trim())
                {
                    case "+":
                        return Operator.Add;

                    case "-":
                        return Operator.Subtract;

                    case "*":
                        return Operator.Multiply;

                    case "/":
                        return Operator.Divide;
                }

                Console.WriteLine($"ERROR: '{line}' is not a valid operation. Only + - * / are supported.");
            }
        }

    }
}
