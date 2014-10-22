
using System;
using Antlr4.Runtime;

namespace ANTLR_Hometask2
{
    class Program
    {
        private static readonly IDataExchange _dataExchange = new DataExchange(new ConsoleReadWrite());

        static void Main()
        {
            var stream = _dataExchange.ReadData();

            var lexer = new CalculatorLexer(stream);
            var tokens = new CommonTokenStream(lexer);

            var parser = new CalculatorParser(tokens);
            var tree = parser.calc();

            var calculator = new Calculator();

            Console.WriteLine("Result: {0}", calculator.Visit(tree));
            Console.ReadKey();
        }
    }
}
