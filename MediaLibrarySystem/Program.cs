using System;
using System.Collections.Generic;

namespace MediaLibrarySystem
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Media Library Management System!");
            Console.WriteLine("=============================================");
            Console.WriteLine();

            List<MediaItem> mediaItems = new List<MediaItem>
            {
                new Book("The Hobbit", 1937, "J.R.R. Tolkien", 310),
                new Dvd("The Matrix", 1999, "The Wachowskis", 136),
                new MusicAlbum("Thriller", 1982, "Michael Jackson", 9)
            };

            Console.WriteLine("Basic Media Information");
            Console.WriteLine("-----------------------");

            foreach (MediaItem mediaItem in mediaItems)
            {
                Console.WriteLine(mediaItem.GetBasicInfo());
            }

            Console.WriteLine();
            Console.WriteLine("Detailed Media Information");
            Console.WriteLine("--------------------------");

            foreach (MediaItem mediaItem in mediaItems)
            {
                Console.WriteLine(mediaItem.GetDisplayInfo());
            }

            Console.WriteLine();
            Console.WriteLine("Inheritance hierarchy test completed successfully.");
            Console.WriteLine();

            Console.WriteLine("Thank you for using the Media Library System!");
            Console.WriteLine("Press Enter to close the application.");
            Console.ReadLine();
        }
    }
}