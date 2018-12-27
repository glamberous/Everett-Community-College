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
using System.Windows.Forms;
using System.Drawing;

public class MyMovieGUI : Form
{

    private Button DisplayButton;
    private Button AddMovieButton;
    private Button QuitButton;
    private Label DataLabel;
    private Label NameLabel;
    private TextBox NameTextbox;
    private Label RatingLabel;
    private TextBox RatingTextbox;
    private Button AddDataButton;
    private bool toggle = false;

    private List<Movie> Movies = new List<Movie>();

    public MyMovieGUI()
    {
        Text = "My Movie Ratings";
        Width = 310;
        Height = 400;
        BackColor = Color.Black;
        ForeColor = Color.White;

        // Data Label
        DataLabel = new Label();
        DataLabel.BackColor = Color.Gray;
        DataLabel.ForeColor = Color.White;
        DataLabel.Top = 10;
        DataLabel.Left = 10;
        DataLabel.Width = 275;
        DataLabel.Height = 300;
        DataLabel.Font = new Font(FontFamily.GenericMonospace, DataLabel.Font.Size);
        Controls.Add(DataLabel);

        //Display Info Button
        DisplayButton = new Button();
        DisplayButton.Left = 10;
        DisplayButton.Top = 325;
        DisplayButton.Text = "Display";
        DisplayButton.BackColor = Color.Blue;
	    DisplayButton.ForeColor = Color.White;
        DisplayButton.Click += new System.EventHandler(Display);
        Controls.Add(DisplayButton);

        //Add Movie Button
        AddMovieButton = new Button();
        AddMovieButton.Left = 110;
        AddMovieButton.Top = 325;
        AddMovieButton.Text = "Add";
        AddMovieButton.BackColor = Color.Blue;
	    AddMovieButton.ForeColor = Color.White;
        AddMovieButton.Click += new System.EventHandler(ButtonAddMovie);
        Controls.Add(AddMovieButton);

        //Quit Button
        QuitButton = new Button();
        QuitButton.Left = 210;
        QuitButton.Top = 325;
        QuitButton.Text = "Quit";
        QuitButton.BackColor = Color.Blue;
	    QuitButton.ForeColor = Color.White;
        QuitButton.Click += new System.EventHandler(Quit);
        Controls.Add(QuitButton);



        // Name Prompt Label
        NameLabel = new Label();
        NameLabel.Top = 50;
        NameLabel.Left = 40;
        NameLabel.Width = 102;
        NameLabel.Text = "Enter Movie Name:";
        Controls.Add(NameLabel);

        // Name TextBox
        NameTextbox = new TextBox();
        NameTextbox.Top = 50;
        NameTextbox.Left = 148;
        NameTextbox.Text = "";
        Controls.Add(NameTextbox);

        // Rating Prompt Label
        RatingLabel = new Label();
        RatingLabel.Top = 90;
        RatingLabel.Left = 40;
        RatingLabel.Width = 108;
        RatingLabel.Text = "Enter Movie Rating:";
        RatingLabel.Visible = false;
        Controls.Add(RatingLabel);

        // Rating TextBox
        RatingTextbox = new TextBox();
        RatingTextbox.Top = 90;
        RatingTextbox.Left = 148;
        RatingTextbox.Text = "";
        RatingTextbox.Visible = false;
        Controls.Add(RatingTextbox);

        // AddData Button
        AddDataButton = new Button();
        AddDataButton.Left = 110;
        AddDataButton.Top = 130;
        AddDataButton.Text = "Add Data";
        AddDataButton.BackColor = Color.White;
        AddDataButton.ForeColor = Color.Black;
        AddDataButton.Click += new System.EventHandler(AddMovie);
        AddDataButton.Visible = false;	
        Controls.Add(AddDataButton);

    }
    private void ButtonAddMovie(object sender, System.EventArgs e) => toggleVisibility();
    
    private void toggleVisibility()
   {
	DataLabel.Visible = toggle;
	AddMovieButton.Visible = toggle;
	DisplayButton.Visible = toggle;
	QuitButton.Visible = toggle;

	if (toggle)
	   toggle = false;
	else
	   toggle = true;

	NameLabel.Visible = toggle;
	NameTextbox.Visible = toggle;
	RatingLabel.Visible = toggle;
	RatingTextbox.Visible = toggle;
	AddDataButton.Visible = toggle;
   }
    public static void Main()
    {
        MyMovieGUI Test = new MyMovieGUI();
        Test.LoadMovies();
        Application.Run(Test);
        /* 
        switch(Choose())
            {
                case 'D': Display(Movies); break;
                case 'A': NewMovie(Movies); NumberOfMovies++; break;
                case 'Q': SaveMovies(Movies); WantToQuit = true; break;
                default: Console.WriteLine("Invalid Option, Try again."); break;
            }
        } while(WantToQuit != true);*/
    }

    public int LoadMovies()
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
            SaveMovies();
        }

        return movieCount;
    }

    public void Quit (object sender, System.EventArgs e)
    {
        SaveMovies();
        this.Close();
    }
    public void SaveMovies()
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

    public void Display(object sender, System.EventArgs e)
    {
        string displayText = "Name                          Rating\n";

        foreach(Movie Movie in Movies)
        {
            displayText += ($"{Movie.Name.PadRight(30)}{Movie.Rating} stars\n");
        }

        DataLabel.Text = displayText;
    }

    public void AddMovie(object sender, System.EventArgs e)
    {
        string NewMovieName = NameTextbox.Text;
        int NewMovieRating = -1;

        try
        {
            NewMovieRating = Convert.ToInt32(RatingTextbox.Text);
        }
        catch
        {
            MessageBox.Show("Rating must be a whole number!");
	        return;
        }
        
        if (NewMovieRating < 1 || 5 < NewMovieRating)
        {
            MessageBox.Show("Ratings can only be 1-5");
            return;
        }

        Movies.Add(new Movie(NewMovieName, NewMovieRating));
        Console.WriteLine($"{NewMovieName} successfully added to the list!");

        NameTextbox.Text = "";
        RatingTextbox.Text = "";
        toggleVisibility();
        DataLabel.Text = "";
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