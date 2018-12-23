/*
Write a program that prompts the user for a list of up to 100 numbers to be stored in an array. 
The program should stop asking for numbers if the user enters the value 999 or if the array is 
full. When the user is finished entering values, calculate the average of only those numbers entered.
*/

using System;

public static class Lesson9
{
    private static void Main()
    {
        int NumbersEntered = 0, TestInput = 0;
        int [] NumberArray = new int [100];
        
        for(NumbersEntered = 0; NumbersEntered < NumberArray.Length; NumbersEntered++)
        {
            Console.Write("Please enter in an int to add to the array: ");
            if ((TestInput = Toolbox.get_int()) == 999)
                break;
            
            NumberArray[NumbersEntered] = TestInput;
        }

        Console.WriteLine("The average of all the numbers entered was: {0}", CalcAverage(NumberArray, NumbersEntered));
    }

    public static int CalcAverage(int [] Array, int NumbersEntered)
    {
        int sum = 0;
        
        foreach(int number in Array)
            sum += number;

        return sum / NumbersEntered;
    } 
} 

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
