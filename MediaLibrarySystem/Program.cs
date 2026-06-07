using System;

/*
Media Library System Architecture Overview
------------------------------------------
This console application demonstrates a layered object-oriented design for a
simple media library system.

Architecture:
1. MediaItem is the abstract base class for all media records.
2. Book, Dvd, and MusicAlbum inherit from MediaItem and customize behavior.
3. IDisplayable defines display behavior that all media items must provide.
4. ISearchable defines search behavior that all media items must provide.
5. MediaLibrary owns the internal collection and performs storage, search, and reporting.
6. MediaLibraryManager hides object creation, validation exceptions, and collection details
   behind user-friendly methods.
7. Program demonstrates the current application behavior from the console boundary.

Inheritance and Polymorphism:
- Book, Dvd, and MusicAlbum share the MediaItem base type.
- The library stores different derived types in one collection.
- Calls such as GetDisplayInfo(), GetShortDescription(), GetEstimatedValue(),
  GetCategoryInfo(), MatchesSearch(), and GetSearchableTerms() are resolved at runtime.
- This allows the application to process different media types uniformly while preserving
  type-specific behavior.

AI Assistance Used:
- AI assistance was used to review XML documentation coverage for public members.
- AI assistance suggested documenting not only what each method does, but also why the
  abstraction exists.
- AI assistance suggested improving search from a single substring comparison into a
  token-based search where all query words must match searchable terms.
- AI assistance suggested enabling XML documentation generation in the project file.

Evaluation of AI Assistance:
- The XML documentation suggestion was accepted because it improves maintainability and
  makes the public API easier to understand.
- The token-based search suggestion was accepted because it improves search behavior while
  remaining simple enough to understand and debug.
- More complex suggestions, such as fuzzy matching, scoring, ranking, and external indexing,
  were not implemented because they would add unnecessary complexity for this course stage.
*/

namespace MediaLibrarySystem
{
    /// <summary>
    /// Contains the console application entry point and demonstration workflow.
    /// </summary>
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
            Console.WriteLine(manager.GetSearchResultsDisplay("hobbit tolkien"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("dark side pink"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("album"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("missing search term"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay(""));

            Console.WriteLine();
            Console.WriteLine(manager.GetDetailedReport());

            Console.WriteLine();
            Console.WriteLine("AI-assisted documentation and code quality test completed successfully.");
            Console.WriteLine();

            Console.WriteLine("Thank you for using the Media Library System!");
        }
    }
}