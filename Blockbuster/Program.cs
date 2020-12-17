using System;
using System.Collections.Generic;

namespace Blockbuster
{
    class Program
    {
        static void Main(string[] args)
        {
            var myBlock = new Blockbuster();
            myBlock.Checkout();
        }
    }

    public enum Genre
    {
        Drama = 0,
        Comedy = 1,
        Horror = 2,
        Romance = 3,
        Action = 4
    }

    public abstract class Movie
    {
        public Movie()
        {

        }
        public Movie(string title, Genre category, int runTime, List<string> scenes)
        {
            Title = title;
            Category = category;
            RunTime = runTime;
            Scenes = scenes;
        }
        public string Title { get; set; }
        public Genre Category { get; set; }
        public int RunTime { get; set; }
        public List<string> Scenes { get; set; }
        public virtual void PrintInfo()
        {
            Console.WriteLine($"{Title}\n{Category}\nRun Time: {RunTime}");
            PrintScenes();
        }
        public void PrintScenes()
        {
            for (int i = 0; i < Scenes.Count - 1; i++)
            {
                Console.WriteLine($"{i+1}: {Scenes[i]}");
            }
        }
        public abstract void Play();
    }
    public class VHS : Movie
    {
        public VHS(string title, Genre category, int runTime, List<string> scenes)
        {
            Title = title;
            Category = category;
            RunTime = runTime;
            Scenes = scenes;
        }
        public double CurrentTime { get; set; }
        public override void Play()
        {
            var rnd = new Random();
            double increment = rnd.Next(1, 101);
            CurrentTime += increment;
        }
        public void Rewind()
        {
            CurrentTime = 0;
        }
    }
    public class DVD : Movie
    {
        public DVD(string title, Genre category, int runTime, List<string> scenes)
        {
            Title = title;
            Category = category;
            RunTime = runTime;
            Scenes = scenes;
        }
        public override void Play()
        {
            Console.WriteLine("What scene would you like to watch?");
            PrintScenes();
            if (int.TryParse(Console.ReadLine(), out int selection))
            {
                Console.WriteLine($"{Scenes[selection]}");
            }
            else
            {
                Console.WriteLine("Not a valid selection");
            }
        }
    }

    public class Blockbuster
    {
        public List<Movie> Movies { get; set; }
        public Blockbuster()
        {
            var myMovies = new List<Movie>();
            myMovies.Add(new VHS("Happy Gilmore", Genre.Drama, 90, new List<string>() { "You\'re gonna DIE CLOWN!!", "Go to your HOME!!", "Play it as it lies!" }));
            myMovies.Add(new VHS("Pulp Fiction", Genre.Action, 90, new List<string>() { "What aint no mutha lovin country i\'ve ever heard of.", "ENGLISH MOTHA LOVA DO YOU SPEAK IT" }));
            myMovies.Add(new VHS("Rounders", Genre.Drama, 90, new List<string>() { "Pay dat man his money.", "ALL NIGHT WIHT YOU. Check check check" }));
            myMovies.Add(new DVD("Scary Movie 3", Genre.Comedy, 90, new List<string>() { "Hello? Is this block blister?", "Yes. Block Blister" }));
            myMovies.Add(new DVD("IT", Genre.Horror, 90, new List<string>() { "AH i\'m a scary doll", "Here\'s johnny" }));
            myMovies.Add(new DVD("Brokeback Mountain", Genre.Romance, 90, new List<string>() { "Just two dudes having a good time", "Whoops we thought this was a family movie" }));
            Movies = myMovies;
        }
        public void PrintMovies()
        {
            var acc = 1;
            foreach (Movie movie in Movies)
            {
                Console.WriteLine($"{acc}: {movie.Title}\n");
                acc++;
            }
        }
        public Movie Checkout()
        {
            PrintMovies();
            while (true)
            {
                Console.WriteLine("Which Movie would you like to checkout?");
                if (int.TryParse(Console.ReadLine(), out int selection))
                {
                    Movies[selection - 1].PrintInfo();
                    return Movies[selection - 1 ];
                }
            }
            
        }
    }
}
