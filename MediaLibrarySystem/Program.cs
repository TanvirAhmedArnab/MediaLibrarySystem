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
7. Program demonstrates the final application behavior from the console boundary.

Inheritance and Polymorphism:
- Book, Dvd, and MusicAlbum share the MediaItem base type.
- The library stores different derived types in one collection.
- Calls such as GetDisplayInfo(), GetShortDescription(), GetEstimatedValue(),
  GetCategoryInfo(), MatchesSearch(), and GetSearchableTerms() are resolved at runtime.
- This allows the application to process different media types uniformly while preserving
  type-specific behavior.

Encapsulation and Abstraction:
- MediaItem protects shared state through private fields and validated properties.
- Derived classes protect their own specialized fields through validated properties.
- MediaLibrary hides the internal List<MediaItem> collection.
- MediaLibraryManager hides object creation, collection management, and expected validation
  exceptions behind simple methods.

AI Assistance Used:
- AI assistance was used to review XML documentation coverage for public members.
- AI assistance suggested documenting not only what each method does, but also why the
  abstraction exists.
- AI assistance suggested improving search from a single substring comparison into a
  token-based search where all query words must match searchable terms.
- AI assistance suggested making the final console demonstration explicitly show validation,
  polymorphism, interfaces, abstraction, and reporting.

Evaluation of AI Assistance:
- The XML documentation suggestion was accepted because it improves maintainability and
  makes the public API easier to understand.
- The token-based search suggestion was accepted because it improves search behavior while
  remaining simple enough to understand and debug.
- The final demonstration suggestion was accepted because it makes the course learning
  outcomes visible from one application run.
- More complex suggestions, such as fuzzy matching, scoring, ranking, persistence, and
  external indexing, were not implemented because they would add unnecessary complexity
  for this course stage.
*/

namespace MediaLibrarySystem
{
    /// <summary>
    /// Contains the console application entry point and final demonstration workflow.
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

            DisplaySectionHeader("1. Adding Valid Media Items");
            AddValidMediaItems(manager);

            DisplaySectionHeader("2. Testing Validation and Friendly Error Handling");
            TestValidationAndErrorHandling(manager);

            DisplaySectionHeader("3. Confirming Encapsulation Protects Library State");
            Console.WriteLine($"Valid media items currently stored: {manager.ItemCount}");
            Console.WriteLine("Invalid creation attempts were rejected and were not added to the library.");

            DisplaySectionHeader("4. Displaying Polymorphic Collection");
            Console.WriteLine(manager.GetAllItemsDisplay());

            DisplaySectionHeader("5. Displaying Interface-Based Summary");
            Console.WriteLine(manager.GetDisplaySummary());

            DisplaySectionHeader("6. Testing Direct Title Search");
            DemonstrateTitleSearch(manager);

            DisplaySectionHeader("7. Testing Interface-Based Flexible Search");
            DemonstrateInterfaceSearch(manager);

            DisplaySectionHeader("8. Displaying Detailed Polymorphic Report");
            Console.WriteLine(manager.GetDetailedReport());

            DisplaySectionHeader("9. OOP Principles Demonstrated");
            DisplayOopPrincipleSummary();

            DisplaySectionHeader("10. Debugging Demonstration Guide");
            DisplayDebuggingGuide();

            DisplaySectionHeader("11. Project Reflection");
            DisplayProjectReflection();

            Console.WriteLine();
            Console.WriteLine("Complete OOP demonstration finished successfully.");
            Console.WriteLine();
            Console.WriteLine("Thank you for using the Media Library System!");
        }

        private static void AddValidMediaItems(MediaLibraryManager manager)
        {
            Console.WriteLine(manager.AddBook("The Hobbit", 1937, "J.R.R. Tolkien", 310));
            Console.WriteLine(manager.AddBook("Clean Code", 2008, "Robert C. Martin", 464));
            Console.WriteLine(manager.AddBook("The Pragmatic Programmer", 1999, "Andrew Hunt and David Thomas", 352));

            Console.WriteLine(manager.AddDvd("The Matrix", 1999, "The Wachowskis", 136));
            Console.WriteLine(manager.AddDvd("Inception", 2010, "Christopher Nolan", 148));
            Console.WriteLine(manager.AddDvd("Spirited Away", 2001, "Hayao Miyazaki", 125));

            Console.WriteLine(manager.AddMusicAlbum("Thriller", 1982, "Michael Jackson", 9));
            Console.WriteLine(manager.AddMusicAlbum("The Dark Side of the Moon", 1973, "Pink Floyd", 10));
            Console.WriteLine(manager.AddMusicAlbum("Master of Puppets", 1986, "Metallica", 8));
        }

        private static void TestValidationAndErrorHandling(MediaLibraryManager manager)
        {
            int countBeforeInvalidAttempts = manager.ItemCount;

            Console.WriteLine(manager.AddBook("", 2020, "Unknown Author", 100));
            Console.WriteLine(manager.AddBook("Invalid Future Book", DateTime.Now.Year + 1, "Unknown Author", 100));
            Console.WriteLine(manager.AddBook("Invalid Page Book", 2020, "Unknown Author", 0));
            Console.WriteLine(manager.AddDvd("Invalid Runtime DVD", 2020, "Unknown Director", 0));
            Console.WriteLine(manager.AddMusicAlbum("Invalid Track Album", 2020, "Unknown Artist", 0));
            Console.WriteLine(manager.AddMusicAlbum("Invalid Artist Album", 2020, "", 10));

            int countAfterInvalidAttempts = manager.ItemCount;

            Console.WriteLine();
            Console.WriteLine($"Item count before invalid attempts: {countBeforeInvalidAttempts}");
            Console.WriteLine($"Item count after invalid attempts: {countAfterInvalidAttempts}");

            if (countBeforeInvalidAttempts == countAfterInvalidAttempts)
            {
                Console.WriteLine("Validation test passed: invalid items did not corrupt the library state.");
            }
            else
            {
                Console.WriteLine("Validation test failed: item count changed after invalid attempts.");
            }
        }

        private static void DemonstrateTitleSearch(MediaLibraryManager manager)
        {
            Console.WriteLine(manager.GetTitleSearchResult("inception"));
            Console.WriteLine(manager.GetTitleSearchResult("The Hobbit"));
            Console.WriteLine(manager.GetTitleSearchResult("Master of Puppets"));
            Console.WriteLine(manager.GetTitleSearchResult("Unknown Title"));
            Console.WriteLine(manager.GetTitleSearchResult(""));
        }

        private static void DemonstrateInterfaceSearch(MediaLibraryManager manager)
        {
            Console.WriteLine(manager.GetSearchResultsDisplay("tolkien"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("nolan"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("pink floyd"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("metallica"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("book"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("dvd"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("album"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("hobbit tolkien"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("dark side pink"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay("missing search term"));
            Console.WriteLine();
            Console.WriteLine(manager.GetSearchResultsDisplay(""));
        }

        private static void DisplayOopPrincipleSummary()
        {
            Console.WriteLine("Inheritance:");
            Console.WriteLine("- Book, Dvd, and MusicAlbum inherit from MediaItem.");
            Console.WriteLine();

            Console.WriteLine("Polymorphism:");
            Console.WriteLine("- Different media types are stored and processed through MediaItem, IDisplayable, and ISearchable references.");
            Console.WriteLine("- Overridden methods provide type-specific behavior at runtime.");
            Console.WriteLine();

            Console.WriteLine("Encapsulation:");
            Console.WriteLine("- Private fields are protected by validated properties.");
            Console.WriteLine("- MediaLibrary hides its internal collection.");
            Console.WriteLine("- Invalid media items are rejected before they can enter the library.");
            Console.WriteLine();

            Console.WriteLine("Abstraction:");
            Console.WriteLine("- MediaItem defines shared behavior without being directly instantiated.");
            Console.WriteLine("- IDisplayable and ISearchable define focused behavior contracts.");
            Console.WriteLine("- MediaLibraryManager hides creation, validation, and collection complexity from Program.");
        }

        private static void DisplayDebuggingGuide()
        {
            Console.WriteLine("To demonstrate constructor chaining:");
            Console.WriteLine("- Set breakpoints inside MediaItem, Book, Dvd, and MusicAlbum constructors.");
            Console.WriteLine("- Create a derived object and observe that the base constructor runs first.");
            Console.WriteLine();

            Console.WriteLine("To demonstrate polymorphism:");
            Console.WriteLine("- Set breakpoints in GetDisplayInfo(), GetShortDescription(), GetEstimatedValue(), and GetCategoryInfo().");
            Console.WriteLine("- Step through display, summary, search, and detailed report calls.");
            Console.WriteLine("- Observe that the runtime selects the correct override based on the actual object type.");
            Console.WriteLine();

            Console.WriteLine("To demonstrate interface method execution:");
            Console.WriteLine("- Set breakpoints in MatchesSearch() and GetSearchableTerms().");
            Console.WriteLine("- Step through interface-based search results.");
            Console.WriteLine("- Watch how ISearchable references call media-specific implementations.");
            Console.WriteLine();

            Console.WriteLine("To demonstrate encapsulation:");
            Console.WriteLine("- Try to access private fields such as _title, _year, or _mediaItems from Program.");
            Console.WriteLine("- Confirm that fields are inaccessible and controlled through public methods or properties.");
        }

        private static void DisplayProjectReflection()
        {
            Console.WriteLine("This project demonstrates mastery of core OOP principles by building a small but structured system around a real media-library problem. Inheritance is shown through the MediaItem base class and its Book, Dvd, and MusicAlbum derived classes. Polymorphism is shown when different media types are stored in one collection and processed through shared base-class and interface references. Encapsulation is shown through private fields, validated properties, read-only IDs, copied collections, and controlled manager methods. Abstraction is shown through the abstract MediaItem class, the IDisplayable and ISearchable interfaces, and the MediaLibraryManager layer.");
            Console.WriteLine();

            Console.WriteLine("The most challenging part of the inheritance design was deciding which behavior belongs in the base class and which behavior belongs in derived classes. Shared rules such as title validation, year validation, media identity, and basic search terms belong in MediaItem. Type-specific details such as author, director, artist, page count, runtime, and track count belong in the derived classes. Keeping those responsibilities separated made the design cleaner and easier to extend.");
            Console.WriteLine();

            Console.WriteLine("AI assistance was useful for reviewing documentation quality, improving search behavior, and checking whether the design clearly demonstrated the required OOP principles. The most useful suggestions were XML documentation, token-based search, and a clearer final demonstration workflow. Suggestions that would have added unnecessary complexity, such as fuzzy search, scoring, persistence, or external indexing, were intentionally not implemented. Future improvements could include a fully interactive menu, saving and loading from files, borrowing and returning media, due dates, categories, and automated unit tests.");
        }

        private static void DisplaySectionHeader(string title)
        {
            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine(new string('-', title.Length));
        }
    }
}