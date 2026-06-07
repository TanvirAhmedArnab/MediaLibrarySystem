using System;

namespace MediaLibrarySystem
{
    public static class Program
    {
        private static void Main(string[] args)
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
            SearchAndDisplay(library, "inception");
            SearchAndDisplay(library, "The Hobbit");
            SearchAndDisplay(library, "Unknown Title");

            Console.WriteLine();
            Console.WriteLine("Polymorphic collection test completed successfully.");
            Console.WriteLine();

            Console.WriteLine("Thank you for using the Media Library System!");
            Console.WriteLine("Press Enter to close the application.");
            Console.ReadLine();
        }

        private static void SearchAndDisplay(MediaLibrary library, string title)
        {
            MediaItem? foundItem = library.FindByTitle(title);

            if (foundItem is null)
            {
                Console.WriteLine($"Search result for \"{title}\": No matching media item found.");
                return;
            }

            Console.WriteLine($"Search result for \"{title}\": {foundItem.GetDisplayInfo()}");
        }
    }
}