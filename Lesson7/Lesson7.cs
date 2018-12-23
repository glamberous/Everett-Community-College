/*
Write a program that will prompt the user for their year number in school, 1 through 4. Based on this response, 
your program should display their class rank as Freshman (1), Sophomore (2), Junior (3), Senior (4), or Error (any other number).

To demonstrate your knowledge of the different selection structures, after prompting the user for their year 
number, also ask them if they want the program to use a nested if structure or a switch structure.

Make your program more organized by doing all the input and output in the Main function, and create 
two different value returning functions, getRankIf() and getRankSwitch().
*/

using System;

public static class Action
{
    public static int Choose()
    {
        string input = "";

        Console.WriteLine("Please enter the key for which action you would like to take.");
        Console.WriteLine("getRankIf:\t\"I\"");
        Console.WriteLine("getRankSwitch:\t\"S\"");

        while(true)
        {
            input = Console.ReadLine(); input = input.Trim(); input = input.ToUpper();

            switch(input[0])
            {
                case 'I': return 0;
                case 'S': return 1;
                default: Console.WriteLine("Error: Invalid Input."); break;
            }
        }
    }

    public delegate string ActionChoice(int YearsInSchool);

    public static ActionChoice[] Run = new ActionChoice[] 
    { 
        new ActionChoice(getRankIf), 
        new ActionChoice(getRankSwitch) 
    };

    public enum classrank 
    {
        Freshman = 1, Sophomore = 2, Junior = 3, Senior = 4
    }

    public static string getRankIf(int YearsInSchool)
    {
        if(YearsInSchool == (int)classrank.Freshman)
            return classrank.Freshman.ToString();
        else if(YearsInSchool == (int)classrank.Sophomore)
            return classrank.Sophomore.ToString();
        else if(YearsInSchool == (int)classrank.Junior)
            return classrank.Junior.ToString();
        else if(YearsInSchool == (int)classrank.Senior)
            return classrank.Senior.ToString();
        else
            return "Error: Not a valid year.";
    }

    public static string getRankSwitch(int YearsInSchool)
    {
        switch(YearsInSchool)
        {
            case 1: return classrank.Freshman.ToString();
            case 2: return classrank.Sophomore.ToString();
            case 3: return classrank.Junior.ToString();
            case 4: return classrank.Senior.ToString();
            default: return "Error: Not a valid year.";
        }
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

public static class Lesson7
{
    private static void Main()
    {
        int YearsInSchool = 0;

        Console.Write("Please enter in your year number in school: ");
        YearsInSchool = Toolbox.get_int();

        Console.WriteLine(Action.Run[Action.Choose()](YearsInSchool));
    } 
} 
