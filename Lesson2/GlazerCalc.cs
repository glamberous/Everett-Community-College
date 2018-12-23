using System;

class GlazerCalc
{
    static void Main()
    {
        double width, height, woodLength, glassArea;
        string widthString, heightString;

        widthString = Console.ReadLine();
        width = double.Parse(widthString);

        heightString = Console.ReadLine();
        height = double.Parse(heightString);

        woodLength = 2 * (width + height) * 3.25;
        glassArea = 2 * (width * height);

        Console.WriteLine ("The length of wood is " + woodLength + " feet");
        Console.WriteLine ("The area of the glass is " + glassArea + " square metres");
    }
}

//;C:\Windows\Microsoft.NET\Framework64\v4.0.30319