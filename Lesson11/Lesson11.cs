/*
Write a program that will keep track of movies you have seen using files. In addition to storing the name of the movie (a string), 
also keep track of the movie's rating (int) as a number of stars between 1 and 5. To make your program more flexible, use a file 
to keep track of the data so that it can be added to in the future. Here is a suggestion on how to make your program work:

When Main starts, it should open the data file and read in the movie data into two arrays, one for the name and one for the 
rating. Next have your program display a menu with choices to

display movie data
add movie data
quit

When the user chooses to quit, copy the data from the arrays to the data file. To make your program more flexible, be sure 
to handle any exceptions that may be thrown from invalid input.

If you want to practice more of your C# skills, write a class called Movie with two instance variables. Change your Main 
program so that it keeps track of the data using a Movie array variable. You could also add an option to the menu to delete a 
movie. You now have the knowledge to make very useful programs. Have fun with this!
*/

using System;
using Toolbox;
using System.IO;
using System.Collections.Generic;

public class Lesson11
{
    public static void Main()
    {
        List<Movie> Movies = new List<Movie>();
        int NumberOfMovies = LoadMovies(Movies);

        bool WantToQuit = false;
        do
        {
        switch(Choose())
            {
                case 'D': Display(Movies); break;
                case 'A': NewMovie(Movies); NumberOfMovies++; break;
                case 'Q': SaveMovies(Movies); WantToQuit = true; break;
                default: Console.WriteLine("Invalid Option, Try again."); break;
            }
        } while(WantToQuit != true);
    }

    public static char Choose()
    {
        Console.WriteLine("D = Display movie data.");
        Console.WriteLine("A = Add movie data.");
        Console.WriteLine("Q = Quit.");
        Console.Write("Choose one of the above options: ");

        char choice = Tools.get_char();

        return choice;
    }

    public static int LoadMovies(List<Movie> Movies)
    {
        int movieCount = 0;

        try
        {
            using (StreamReader InputFile = new StreamReader("output1.txt")) 
            {
                string line;

                while ((line = InputFile.ReadLine()) != null) 
                {
                    string[] tokens = line.Split(',');

                    string moviename = tokens[0];
                    int movierating = Convert.ToInt32(tokens[1]);

                    Movies.Add(new Movie(moviename, movierating));
                    movieCount++;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
            Console.WriteLine("****** Created file Output1.txt ******");
            Console.WriteLine();
            SaveMovies(Movies);
        }

        return movieCount;
    }

    public static void SaveMovies(List<Movie> Movies)
    {
        try
        {
            using (StreamWriter OutputFile = new StreamWriter("output1.txt")) 
            {
                foreach(Movie Movie in Movies)
                {
                    OutputFile.WriteLine($"{Movie.Name},{Movie.Rating}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An Error Occurred: {e.Message}");
            throw e;
        }
    }

    public static void Display(List<Movie> Movies)
    {
        Console.WriteLine();
        Console.WriteLine("Name                                    Rating");
        foreach(Movie Movie in Movies)
        {
            Console.WriteLine($"{Movie.Name.PadRight(40)}{Movie.Rating} stars");
        }
        Console.WriteLine();
    }

    public static bool NewMovie(List<Movie> Movies)
    {
        Console.Write("Please enter the name of a movie: ");
        string NewMovieName = Console.ReadLine();

        int NewMovieRating = -1;
        bool ValidMovieRating = false;

        do
        {
            Console.Write("Please enter your rating for this movie (1-5): ");
            NewMovieRating = Tools.get_int();
            if(5 >= NewMovieRating && NewMovieRating >= 1)
                ValidMovieRating = true;
            else
                Console.WriteLine("Incorrect entry, Try again.");
        } while(ValidMovieRating != true);

        Movies.Add(new Movie(NewMovieName, NewMovieRating));
        Console.WriteLine($"{NewMovieName} successfully added to the list!");
        Console.WriteLine();

        return true;
    }
}

public class Movie
{
    private string name;
    private int rating;

    public Movie(string name, int rating)
    {
        this.Name = name;
        this.Rating = rating;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Rating
    {
        get => rating;
        set 
        {
            if (1 > value || value > 5 )
            {
                Console.WriteLine("Rating for " + this.name + " was not valid. Set to -1.");
                rating = -1;
            }
            else
            {
                rating = value;
            }
        }
    }
}