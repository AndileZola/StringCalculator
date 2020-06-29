using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Input string
            var _strings = "//[*][%]1*2%3#1001";

            Console.WriteLine("=======================[SUM]===================");
            //Extrating all numeric values from the string and add them
            var sum = Add(_strings);

            Console.WriteLine("==================[PROVIDED INPUT]===================");
            //Display the input string to the user
            Console.WriteLine($@"=> {_strings} = {sum}");

            Console.WriteLine("=======================[EXIT]===================");

            Console.WriteLine("=> Press any key to exit");

            //Wait for user to press any key to dismis the screen
            Console.ReadKey();
        }

        public static List<int> ExtractNumbersFromString(string numbers)
        {
            List<int> _numbersList = new List<int>();

            //Regex pattern to extract numeric values from a string
            string regexNumericPattern = @"(-?[0-9]+)";
            Regex regex = new Regex(regexNumericPattern);

            //Extracting all numeric values from the string to collection of match objects.
            MatchCollection matches = regex.Matches(numbers);

            //Covert all the match object values to an int and add them into a list of intergers.
            matches.ToList().ForEach(x =>
            {
                _numbersList.Add(Convert.ToInt32(x.Value));
            });

            return _numbersList;
        }

        public static int Add(string numbers)
        {
            int sum = 0;
            List<int> extractedNumbers = new List<int>();

            try
            {
                //List of integers consisting of all numeric values extracted from the string.
                extractedNumbers = ExtractNumbersFromString(numbers);

                //Check if there's any negative number in the list
                var hasNegativeNumber = extractedNumbers.Any(x => (x < 0));

                if (hasNegativeNumber)
                {
                    //Get all negative values from the list of values and store them into an array.
                    var invalidNumbers = extractedNumbers.Where(x => (x < 0)).ToArray();

                    //Convert the arracy of negative values to a string of csv.
                    var invalidNumbersCsv = string.Join(",", invalidNumbers);

                    //Throw an exeption informing the user that negative values are not allowed
                    InvalidInputNumber(invalidNumbersCsv);
                }
                else
                {
                    //Loop through the list of numbers.
                    extractedNumbers.ForEach(number =>
                    {
                        //Add all mumbers that equal, or less than 1000.
                        sum += (number > 1000) ? 0 : number;
                    });
                }

                //Display all the numbers that were added and their sum.
                Console.WriteLine($"=> { string.Join(" + ", extractedNumbers)} = {sum}");
            }
            catch (Exception ex)
            {
                //Display errors to the user.
                Console.WriteLine($"=> {ex.Message}");
            }
            return sum;
        }

        public static void InvalidInputNumber(string invalidNumbers)
        {
            throw new Exception($"Negative numbers are not allowed. You entered ({invalidNumbers})");
        }
    }
}
