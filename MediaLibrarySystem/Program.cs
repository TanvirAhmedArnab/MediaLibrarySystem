using System;
using System.Collections.Generic;

namespace MediaLibrarySystem
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                RunApplication();
            }
            catch (Exception exception)
            {
                Console.WriteLine();
                Console.WriteLine("The application encountered an unexpected error.");
                Console.WriteLine($"Error: {exception.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to close the application.");
            Console.ReadLine();
        }

        private static void RunApplication()
        {
            Console.WriteLine("Welcome to the Media Library Management System!");
            Console.WriteLine("=============================================");
            Console.WriteLine();

            MediaLibrary library = new MediaLibrary();

            library.AddItem(new Book("The Hobbit", 1937, "J.R.R. Tolkien", 310));
            library.AddItem(new Book("Clean Code", 2008, "Robert C. Martin", 464));
            library.AddItem(new Dvd("The Matrix", 1999, "The Wachowskis", 136));
            library.AddItem(new Dvd("Inception", 2010, "Christopher Nolan", 148));
            library.AddItem(new MusicAlbum("Thriller", 1982, "Michael Jackson", 9));
            library.AddItem(new MusicAlbum("The Dark Side of the Moon", 1973, "Pink Floyd", 10));

            Console.WriteLine("All Media Items");
            Console.WriteLine("---------------");
            library.DisplayAllItems();

            Console.WriteLine();
            Console.WriteLine(library.GetDisplaySummary());

            Console.WriteLine();
            SearchAndDisplaySingleResult(library, "inception");
            SearchAndDisplaySingleResult(library, "The Hobbit");
            SearchAndDisplaySingleResult(library, "Unknown Title");

            Console.WriteLine();
            DisplaySearchResults(library, "tolkien");
            DisplaySearchResults(library, "nolan");
            DisplaySearchResults(library, "pink floyd");
            DisplaySearchResults(library, "album");
            DisplaySearchResults(library, "missing search term");

            Console.WriteLine();
            library.DisplayDetailedReport();

            Console.WriteLine();
            Console.WriteLine("Interface-based abstraction test completed successfully.");
            Console.WriteLine();

            Console.WriteLine("Thank you for using the Media Library System!");
        }

        private static void SearchAndDisplaySingleResult(MediaLibrary library, string title)
        {
            MediaItem? foundItem = library.FindByTitle(title);

            if (foundItem is null)
            {
                Console.WriteLine($"Title search result for \"{title}\": No matching media item found.");
                return;
            }

            Console.WriteLine($"Title search result for \"{title}\": {foundItem.GetDisplayInfo()}");
        }

        private static void DisplaySearchResults(MediaLibrary library, string searchTerm)
        {
            List<MediaItem> matchingItems = library.SearchItems(searchTerm);

            Console.WriteLine($"Interface search results for \"{searchTerm}\":");

            if (matchingItems.Count == 0)
            {
                Console.WriteLine("- No matching media items found.");
                return;
            }

            foreach (MediaItem item in matchingItems)
            {
                IDisplayable displayableItem = item;
                Console.WriteLine($"- {displayableItem.GetShortDescription()}");
            }
        }
    }
}