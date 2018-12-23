using System;
using System.Globalization;

public class Lesson3
{
  public static void Main()
  {
    int width = 0, length = 0;
    decimal cost = 0.00m;
    string input = String.Empty;

    do
    {
        Console.Write("Please enter in a width: ");
        input = Console.ReadLine();
    } while(!Int32.TryParse(input, out width));

    do
    {
        Console.Write("Please enter in a height: ");
        input = Console.ReadLine();
    } while(!Int32.TryParse(input, out length));

    do
    {
        Console.Write("Please enter in the cost per square foot: ");
        input = Console.ReadLine();
    } while(!Decimal.TryParse(input, NumberStyles.Currency, CultureInfo.CurrentCulture, out cost));

    Console.WriteLine("The area of the room is {0}sqft", width * length);
    Console.WriteLine("This would cost: ${0}", (decimal)(width * length) * cost);
  } 
} 