/*
Finish the Time class that was started in this lesson. Do this by completing the following methods:

SetMinute(int m)

SetSecond(int s)

GetMinute()

GetSecond()

AddSecond() - This method should add 1 to the second variable stored in the current object. If the second becomes 60, be sure to set the second equal to 0 and increment the minute by one.

AddMinute() - This method should add 1 to the minute variable stored in the current object. If the minute becomes 60, be sure to set the minute equal to 0 and increment the hour variable by one.

AddHour() - This method should add 1 to the hour variable stored in the current object. If the hour becomes 24, be sure to set the hour equal to 0.

DisplayCivilian() - This method should display the time stored in the object as civilian time.

DisplayMilitary() - This method should display the time stored in the object as military time.

Equals(Time t) - This method should compare the time stored in the current object to the time stored in the Time object t that is passed into the method.
*/

using System;
using TimeNamespace;
using Toolbox;

public class UsingTime
{
    public static void Main()
    {
        int hour = 0, minute = 0, second = 0;

        Console.Out.Write("myTime - hour: ");
        hour = Tools.get_int();
        Console.Out.Write("myTime - minutes: ");
        minute = Tools.get_int();
        Console.Out.Write("myTime - seconds: ");
        second = Tools.get_int();
        Time myTime = new Time(hour, minute, second);
        myTime.DisplayCivilian();
        myTime.DisplayMilitary();

        Console.Out.Write("yourTime - hour: ");
        hour = Tools.get_int();
        Console.Out.Write("yourTime - minutes: ");
        minute = Tools.get_int();
        Console.Out.Write("yourTime - seconds: ");
        second = Tools.get_int();
        Time yourTime = new Time(hour, minute, second);
        yourTime.DisplayCivilian();
        yourTime.DisplayMilitary();

        if(myTime.Equals(yourTime))
        {
            Console.Out.WriteLine("Both times are equal.");
        }
        else
        {
            Console.Out.WriteLine("Both times are not equal.");
        }

        Console.Out.WriteLine("Added 1 second to yourTime.");
        yourTime.AddSecond();
        yourTime.DisplayCivilian();
        yourTime.DisplayMilitary();
        
    }
 }