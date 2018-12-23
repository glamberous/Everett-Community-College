
namespace Toolbox
{
    using System;

    public static class Tools
    {
        public static int get_int()
        {
            string input = String.Empty;
            int variable = 0;

            do
            {
                input = Console.ReadLine();
            } while(!Int32.TryParse(input, out variable));

            return variable;
        }
    }
}