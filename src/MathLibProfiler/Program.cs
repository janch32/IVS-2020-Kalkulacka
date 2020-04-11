using MathLib;
using MathLib.Expression;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MathLibProfiler
{
    public static class Program
    {
        private static readonly IMathLibrary Library = MathLibraryFactory.Build();

        public static void Main(string[] args)
        {
            // Priznak k pouziti matematicke knihovny, jinak je pouzit vypocet pres retezcove vyrazy.
            var useMath = args.Any(o => o.Equals("--use-math", StringComparison.InvariantCultureIgnoreCase));

            var numbers = ReadData(args);
            var result = ComputeStandardDeviation(!useMath, numbers);

            Console.WriteLine(result);
        }

        private static decimal[] ReadData(string[] args)
        {
            // Urceni, ze se jedna o spusteni z profilovaci aplikace JetBrains dotTrace.
            bool useFile = args.Length >= 2 && args[0] == "--use-file" && !string.IsNullOrEmpty(args[1]);

            var stream = useFile ? File.OpenRead(args[1]) : Console.OpenStandardInput();
            return ReadNumbersFromStream(stream).ToArray();
        }

        private static IEnumerable<decimal> ReadNumbersFromStream(Stream stream)
        {
            using var reader = new StreamReader(stream);

            while (!reader.EndOfStream)
                yield return decimal.Parse(reader.ReadLine());
        }

        private static decimal ComputeAverage(bool useParser, decimal[] numbers)
        {
            if (useParser)
            {
                decimal sum = numbers[0];

                for (int i = 1; i < numbers.Length; i++)
                    sum = new Parser(sum + " + " + numbers[i]).Evaluate();

                return new Parser("(1 / " + numbers.Length + ") * " + sum).Evaluate();
            }
            else
            {
                decimal sum = numbers[0];

                for (int i = 1; i < numbers.Length; i++)
                    sum = Library.Add(sum, numbers[i]);

                return Library.Mul(Library.Div(1, numbers.Length), sum);
            }
        }

        private static decimal ComputeStandardDeviation(bool useParser, decimal[] numbers)
        {
            var average = ComputeAverage(useParser, numbers);

            if (useParser)
                return ComputeStandardDeviationWithParser(numbers, average);

            return ComputeStandardDeviationWithMathFunctions(numbers, average);
        }

        private static decimal ComputeStandardDeviationWithParser(decimal[] numbers, decimal average)
        {
            decimal sumPart = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
                sumPart = new Parser(sumPart + " + (" + numbers[i] + " ^ 2)").Evaluate();

            return new Parser("2√((1 / (" + numbers.Length + " - 1)) * (" + sumPart + " - " + numbers.Length + " * " + average + " ^ 2))").Evaluate();
        }

        private static decimal ComputeStandardDeviationWithMathFunctions(decimal[] numbers, decimal average)
        {
            decimal sumPart = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
                sumPart = Library.Add(sumPart, Library.Power(numbers[i], 2));

            return Library.Root(Library.Mul(Library.Div(1, Library.Sub(numbers.Length, 1)), Library.Sub(sumPart, Library.Mul(numbers.Length, Library.Power(average, 2)))), 2);
        }
    }
}
