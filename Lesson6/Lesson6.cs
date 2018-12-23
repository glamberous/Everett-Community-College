/*
Write a program that will display the user's letter grade based on their numerical average. 
Prompt the user for a number, and then display the corresponding letter grade based on the 10-point scale:
A 90 - 100
B 80 - 89.9
C 70 - 79.9
D 60 - 69.9
F < 60.0
*/

using System;
using System.Globalization;
using test;

namespace lessons
{
    public class Lesson6
    {
        public static void Main()
        {
            int side1 = 2, side2 = 5;
            Console.WriteLine("The hypotenuse is {0}.", toolbox.calcHypotenuse(side1, side2));

            double num_grade = 0.00;
            char letter_grade = '\0';

            Console.Write("Please enter in your grade (number): ");
            num_grade = get_double();
            
            if(num_grade > 90)
                letter_grade = 'A';
            else if(num_grade > 80)
                letter_grade = 'B';
            else if(num_grade > 70)
                letter_grade = 'C';
            else if(num_grade > 60)
                letter_grade = 'D';
            else
                letter_grade = 'F';

            Console.Write("Your letter grade is {0}.", letter_grade);
        } 

        public static double get_double()
        {
            string input = String.Empty;
            double variable = 0.00;

            do
            {
                input = Console.ReadLine();
            } while(!Double.TryParse(input, out variable));

            return variable;
        }
    } 
}