using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Calculator
{
	class Operations
	{
		static string anyNumber = "^\\d+(.\\d+){0,1}$";

		//Get user's numbers
		public static string[] getNumbers(string userInput, char operand)
		{
			return Array.ConvertAll(userInput.Replace(',', '.').Split(operand), p => p.Trim());
		}

		//Do calculation with user's numbers and choose operation
		public static decimal Calc(decimal number1, decimal number2, char operand)
		{
			switch (operand)
			{
				case '*':
					return number1 * number2;
				case '/':
					return number1 / number2;
				case '+':
					return number1 + number2;
				case '-':
					return number1 - number2;
			}
			return decimal.MinValue;
		}

		//Get valid user's number
		public static decimal getNumber(string userInput)
		{
			if (Regex.IsMatch(userInput, anyNumber))
			{
				try
				{
					return decimal.Parse(userInput, CultureInfo.InvariantCulture);
				}
				catch
				{
					return decimal.MinValue;
				}
			}
			return decimal.MinValue;
		}

		//Get an operand from user's input
		public static char getOperand(string userInput)
		{
			char[] operators = { '+', '-', '/', '*' };

			int count = 0;
			char oper = ' ';

			foreach (char operand in operators)
			{
				if (userInput.IndexOf(operand) != -1)
				{
					oper = operand;
					count++;
				}
			}

			if (count != 1)
			{
				return ' ';
			}

			return oper;
		}
	}
}
