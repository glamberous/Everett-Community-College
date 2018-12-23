/*
Write a program that uses a loop to ask the user for a list of numbers. The program should 
stop looping when the user enters 999. When the user enters that value, your program should display 
the sum of all the values that were entered. Do not include the value 999 in the sum.
*/

using System;

public static class Toolbox
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

public static class Lesson7
{
    private static void Main()
    {
        int Sum = 0, CheckNum = 0;
        do
        {
            Sum += CheckNum;
            Console.WriteLine("Your Sum is currently at {0}.", Sum);
            Console.Write("Please enter in a number to be added: ");
            CheckNum = Toolbox.get_int();
            Console.WriteLine();
        } while(CheckNum != 999);
    } 
} 
