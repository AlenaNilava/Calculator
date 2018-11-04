using System;
using System.Text.RegularExpressions;

namespace Calculator
{
    class App
    {
        static string anyLetter = "[a-zA-Z]";

		static void Main(string[] args)
		{
			//Welcome to Calculator
			Console.WriteLine("Hello user! Welcome to calculator.");
			Start:
			Console.WriteLine("Enter your operation (for instance: 2 + 2):");

			//Read user's input
			string userInput = Console.ReadLine();

			//Validate user's input
			Error:
			while (string.IsNullOrEmpty(userInput) || Regex.IsMatch(userInput, anyLetter)
				|| string.IsNullOrWhiteSpace(userInput)
				|| Operations.getOperand(userInput) == ' ')
			{
				Console.WriteLine();

				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Input is incorrect, enter 2 numbers with operations: " +
					"\nMultiplication: *\nAddition: +\nDivision: /\nSubstraction: -");

				Console.ResetColor();

				Console.WriteLine("Enter your operation (for instance: 2 + 2):");
				userInput = Console.ReadLine();
			}

			//Get user's operation
			char operand = Operations.getOperand(userInput);
			//Get user's numbers
			string[] numbers = Operations.getNumbers(userInput, operand);
			//Get user's first number
			decimal number1 = Operations.getNumber(numbers[0]);
			//Get user's Second number
			decimal number2 = Operations.getNumber(numbers[1]);

			//Check that we do not divide by 0
			if (number2 == 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("You cannot divide on zero");
				userInput = null;
				goto Error;
			}

			//Do calculation with numbers
			if (number1 != decimal.MinValue && number2 != decimal.MinValue)
			{
				Console.WriteLine("Answer is: {0}", Operations.Calc(number1, number2, operand));
				Console.WriteLine();
				Console.WriteLine("If you want to continue calculations, press Enter");
				if (Console.ReadKey(true).Key == ConsoleKey.Enter)
				{
					goto Start;
				}

			}
			else
			{
				userInput = null;
				goto Error;
			}
			Console.WriteLine("Thank you for using calculator. Bye!");
		}
    }
}

