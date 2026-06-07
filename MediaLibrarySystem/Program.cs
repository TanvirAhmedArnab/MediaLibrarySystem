using System;

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

            MediaLibraryManager manager = new MediaLibraryManager();

            Console.WriteLine("Adding Valid Media Items");
            Console.WriteLine("------------------------");
            Console.WriteLine(manager.AddBook("The Hobbit", 1937, "J.R.R. Tolkien", 310));
            Console.WriteLine(manager.AddBook("Clean Code", 2008, "Robert C. Martin", 464));
            Console.WriteLine(manager.AddDvd("The Matrix", 1999, "The Wachowskis", 136));
            Console.WriteLine(manager.AddDvd("Inception", 2010, "Christopher Nolan", 148));
            Console.WriteLine(manager.AddMusicAlbum("Thriller", 1982, "Michael Jackson", 9));
            Console.WriteLine(manager.AddMusicAlbum("The Dark Side of the Moon", 1973, "Pink Floyd", 10));

            Console.WriteLine();
            Console.WriteLine("Testing Friendly Error Handling");
            Console.WriteLine("-------------------------------");
            Console.WriteLine(manager.AddBook("", 2020, "Unknown Author", 100));
            Console.WriteLine(manager.AddDvd("Future Film", DateTime.Now.Year + 1, "Unknown Director", 90));
            Console.WriteLine(manager.AddMusicAlbum("Silent Album", 2020, "Unknown Artist", 0));

            Console.WriteLine();
            Console.WriteLine(manager.GetAllItemsDisplay());

            Console.WriteLine();
            Console.WriteLine(manager.GetDisplaySummary());

            Console.WriteLine();
            Console.WriteLine(manager.GetTitleSearchResult("inception"));
            Console.WriteLine(manager.GetTitleSearchResult("The Hobbit"));
            Console.WriteLine(manager.GetTitleSearchResult("Unknown Title"));

            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("tolkien"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("nolan"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("pink floyd"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("album"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("missing search term"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay(""));

            Console.WriteLine();
            Console.WriteLine(manager.GetDetailedReport());

            Console.WriteLine();
            Console.WriteLine("Advanced encapsulation and abstraction test completed successfully.");
            Console.WriteLine();

            Console.WriteLine("Thank you for using the Media Library System!");
        }
    }
}