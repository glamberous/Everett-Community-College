using System;
using System.Globalization;

namespace lessons
{
    public class Lesson4
    {
    public static void Main()
    {
        int side1 = 0, side2 = 0;
        string input = String.Empty;

        do
        {
            Console.Write("Please enter in the length of side one: ");
            input = Console.ReadLine();
        } while(!Int32.TryParse(input, out side1));

        do
        {
            Console.Write("Please enter in a height: ");
            input = Console.ReadLine();
        } while(!Int32.TryParse(input, out side2));

        Console.WriteLine("The hypotenuse is {0}.", calcHypotenuse(side1, side2));
    } 

    public static double calcHypotenuse (double side1, double side2)
    {
        return Math.Sqrt((side1 * side1) + (side2 * side2));
    }
    } 
}