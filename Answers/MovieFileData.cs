// Lesson 11 - Assignment
// Author - Mike Orsega
using System;
using System.IO;

public class MovieFileData
{

  public static void Main()
  {
	String [] name = new String[20];
	int [] rating = new int[20];
	int numOfMovies = 0;
	int choice = 0;

	numOfMovies = readData(name, rating);

	do
	{
	   choice = menu();
	   switch(choice)
	   {
		case 1: display(name, rating, numOfMovies);
			break;
		case 2: numOfMovies = add(name, rating, numOfMovies);
			break;
		case 3: quit(name, rating, numOfMovies);
			break;
		default: Console.Out.WriteLine("\nNOT A VALID CHOICE... try again");
			choice = 0;
			break;
	   }
	} while (choice != 3);
	
  }

  public static int readData(string [] _name, int [] _rating)
  {
	String strNum, strRating;
	int i, num= 0;

	try
	{
	   StreamReader inFile = File.OpenText("movieData.txt");
	   strNum = inFile.ReadLine();
	   try
	   {
	  	num = Convert.ToInt32(strNum);
	   }
	   catch (FormatException)
	   {
	  	Console.Out.WriteLine("\n\nCOULD NOT READ DATA FILE!");
	  	num = 0;
	   }

	   for (i = 0; i < num; i++)
	   {
	  	_name[i] = inFile.ReadLine();
	  	strRating = inFile.ReadLine();
	   	try
	  	{
	     	   _rating[i] = Convert.ToInt32(strRating);
	  	}
	  	catch	(FormatException)
	  	{
	    	   Console.Out.Write("\nInvalid Rating Format for " + _name[i]);
	     	   Console.Out.WriteLine(", using 0");
	     	   _rating[i] = 0;
	  	}
	   }

	   inFile.Close();
	   return num;
	}
	catch(FileNotFoundException)
	{
	   return 0;
	}
  }

  public static void display(string [] _name, int [] _rating, int _num)
  {
	int i;

	Console.Out.WriteLine("\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
	Console.Out.WriteLine("Current Movie Data");

	for (i = 0; i < _num; i++)
	   Console.Out.WriteLine(_name[i] + " with " + _rating[i] + " stars.");	
  }

  public static int add(string [] _name, int [] _rating, int _num)
  {
	String strRating;

	Console.Out.WriteLine("\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
	Console.Out.WriteLine("Adding Movie Data");

	Console.Out.Write("\n\nWhat is the name of the movie to be entered?  ");
	_name[_num] = Console.ReadLine();

	Console.Out.Write("\n\nWhat is the rating for this movie?  ");
	strRating = Console.ReadLine();
	try
	{
	   _rating[_num] = Convert.ToInt32(strRating);
	}
	catch(FormatException)
	{
	   Console.Out.WriteLine("\nNOT A VALID RATING... rating set to 0");
	   _rating[_num] = 0;
	}
	
	_num++;
	return _num;
  }

  public static void quit(string [] _name, int [] _rating, int _num)
  {
	int i;

	Console.Out.WriteLine("\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
	Console.Out.WriteLine("Saving Movie Data");

	StreamWriter outFile = File.CreateText("movieData.txt");
	outFile.WriteLine(_num);
	
	for(i = 0; i < _num; i++)
	{
		outFile.WriteLine(_name[i]);
		outFile.WriteLine(_rating[i]);
	}

	outFile.Close();

	Console.Out.WriteLine("\n\nYour data was saved!");
	Console.Out.WriteLine("Goodbye!");	
  }

  public static int menu()
  {
	String strChoice;
	int choice;

	Console.Out.WriteLine("\n\n");
	Console.Out.WriteLine("**************************");
	Console.Out.WriteLine("* 1 - Display Movie Data *");
	Console.Out.WriteLine("* 2 - Add Movie Data     *");
	Console.Out.WriteLine("* 3 - Quit               *");
	Console.Out.WriteLine("**************************");
	Console.Out.Write("\nEnter your choice: ");

	strChoice = Console.ReadLine();
	try
	{ 
	   choice = Convert.ToInt32(strChoice);
	}
	catch (FormatException)
	{
	   Console.Out.WriteLine("\nNOT A VALID CHOICE... try again");
	   choice = 0;
	}
	
	return choice;
   }

}