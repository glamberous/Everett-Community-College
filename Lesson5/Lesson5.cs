/*
Write a program that will help to balance your checkbook. To help practice the ability to pass variables 
by reference, you should write the following methods:

A method that reads in a double from the keyboard. Remember, all input is read in as a string, and 
then it must be converted to the appropriate data type. This method should be a void method that 
takes a reference to a double variable as a parameter.

A void method that takes the beginning balance, the total deposits, the total withdrawals, 
and a reference to the variable containing the ending balance.
*/

using System;
using System.Globalization;

public class Lesson5
{
    public static void Main()
    {
        decimal beg_balance = 0.00m, total_deposits = 0.00m, total_withdrawals = 0.00m;

        Console.Write("Please enter in your beginning balance: ");
        get_decimal(out beg_balance);
        Console.Write("Please enter in your total deposits: ");
        get_decimal(out total_deposits);
        Console.Write("Please enter in your total withdrawals: ");
        get_decimal(out total_withdrawals);
        
        calc_balance(beg_balance, total_deposits, total_withdrawals);
    } 

    public static void calc_balance(decimal cur_balance, decimal total_deposits, decimal total_withdrawals)
    {
        cur_balance += total_deposits;
        cur_balance -= total_withdrawals;

        Console.Write("Your final balance is: {0:C2}", cur_balance);
    }

    public static void get_decimal(out decimal new_decimal)
    {
        string input = String.Empty;

        do
        {
            input = Console.ReadLine();
        } while(!Decimal.TryParse(input, out new_decimal));
    }
} 