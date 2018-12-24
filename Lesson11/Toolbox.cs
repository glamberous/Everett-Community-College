
namespace Toolbox
{
    using System;

    public static class Tools
    {
        public static int get_int()
        {
            string input = String.Empty;
            int variable = 0;

            input = Console.ReadLine();
            try
            {
                Int32.TryParse(input, out variable);
            }
            catch
            {
                Console.WriteLine("Invalid Input. Set variable to 0");
                variable = 0;
            }
            
            return variable;
        }

        public static char get_char()
        {
            string input = String.Empty;
            char variable = '\0';

            input = Console.ReadLine();
            input = input.Trim();
            input = input.ToUpper();
            variable = input[0];

            return variable;
        }
    }
}