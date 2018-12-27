using System;


namespace Media
{
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
}