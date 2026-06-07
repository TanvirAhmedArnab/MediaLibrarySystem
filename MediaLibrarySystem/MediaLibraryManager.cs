using System;
using System.Collections.Generic;
using System.Text;

namespace MediaLibrarySystem
{
    /// <summary>
    /// Provides user-friendly operations for managing a media library.
    /// </summary>
    /// <remarks>
    /// This class acts as an application-facing abstraction layer over <see cref="MediaLibrary"/>.
    /// It hides object creation, validation exceptions, collection access, and report formatting
    /// behind simple methods that return user-readable messages.
    /// </remarks>
    public sealed class MediaLibraryManager
    {
        private readonly MediaLibrary _library;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaLibraryManager"/> class
        /// with an empty media library.
        /// </summary>
        public MediaLibraryManager()
            : this(new MediaLibrary())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaLibraryManager"/> class
        /// with an existing media library.
        /// </summary>
        /// <param name="library">The media library to manage.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="library"/> is <c>null</c>.</exception>
        public MediaLibraryManager(MediaLibrary library)
        {
            _library = library ?? throw new ArgumentNullException(nameof(library));
        }

        /// <summary>
        /// Creates and adds a book to the managed media library.
        /// </summary>
        /// <param name="title">The book title.</param>
        /// <param name="year">The publication year.</param>
        /// <param name="author">The book author.</param>
        /// <param name="pageCount">The number of pages.</param>
        /// <returns>A user-friendly success or failure message.</returns>
        public string AddBook(string title, int year, string author, int pageCount)
        {
            return TryAddMediaItem(
                () => new Book(title, year, author, pageCount),
                "book");
        }

        /// <summary>
        /// Creates and adds a DVD to the managed media library.
        /// </summary>
        /// <param name="title">The DVD title.</param>
        /// <param name="year">The release year.</param>
        /// <param name="director">The DVD director.</param>
        /// <param name="runtimeMinutes">The runtime in minutes.</param>
        /// <returns>A user-friendly success or failure message.</returns>
        public string AddDvd(string title, int year, string director, int runtimeMinutes)
        {
            return TryAddMediaItem(
                () => new Dvd(title, year, director, runtimeMinutes),
                "DVD");
        }

        /// <summary>
        /// Creates and adds a music album to the managed media library.
        /// </summary>
        /// <param name="title">The album title.</param>
        /// <param name="year">The release year.</param>
        /// <param name="artist">The album artist.</param>
        /// <param name="trackCount">The number of tracks.</param>
        /// <returns>A user-friendly success or failure message.</returns>
        public string AddMusicAlbum(string title, int year, string artist, int trackCount)
        {
            return TryAddMediaItem(
                () => new MusicAlbum(title, year, artist, trackCount),
                "music album");
        }

        /// <summary>
        /// Gets a detailed display string for all media items.
        /// </summary>
        /// <returns>A formatted list of all media items, or an empty-library message.</returns>
        public string GetAllItemsDisplay()
        {
            List<MediaItem> items = _library.GetAllItems();

            if (items.Count == 0)
            {
                return "The media library is currently empty.";
            }

            StringBuilder displayBuilder = new StringBuilder();

            displayBuilder.AppendLine("All Media Items");
            displayBuilder.AppendLine("---------------");

            foreach (MediaItem item in items)
            {
                IDisplayable displayableItem = item;
                displayBuilder.AppendLine(displayableItem.GetDisplayInfo());
            }

            return displayBuilder.ToString().TrimEnd();
        }

        /// <summary>
        /// Gets a compact summary of the managed media library.
        /// </summary>
        /// <returns>A formatted summary string.</returns>
        public string GetDisplaySummary()
        {
            return _library.GetDisplaySummary();
        }

        /// <summary>
        /// Gets a user-friendly title search result.
        /// </summary>
        /// <param name="title">The title to search for.</param>
        /// <returns>A formatted search result message.</returns>
        public string GetTitleSearchResult(string title)
        {
            try
            {
                MediaItem? foundItem = _library.FindByTitle(title);

                if (foundItem is null)
                {
                    return $"Title search result for \"{title}\": No matching media item found.";
                }

                return $"Title search result for \"{title}\": {foundItem.GetDisplayInfo()}";
            }
            catch (ArgumentException exception)
            {
                return $"Title search failed: {exception.Message}";
            }
        }

        /// <summary>
        /// Gets interface-based search results for a search term.
        /// </summary>
        /// <param name="searchTerm">The search text entered by the user.</param>
        /// <returns>A formatted multi-line search result message.</returns>
        /// <example>
        /// Calling this method with <c>tolkien hobbit</c> can return a book where
        /// one token matches the author and another token matches the title.
        /// </example>
        public string GetSearchResultsDisplay(string searchTerm)
        {
            try
            {
                List<MediaItem> matchingItems = _library.SearchItems(searchTerm);
                StringBuilder resultBuilder = new StringBuilder();

                resultBuilder.AppendLine($"Interface search results for \"{searchTerm}\":");

                if (matchingItems.Count == 0)
                {
                    resultBuilder.AppendLine("- No matching media items found.");
                    return resultBuilder.ToString().TrimEnd();
                }

                foreach (MediaItem item in matchingItems)
                {
                    IDisplayable displayableItem = item;
                    resultBuilder.AppendLine($"- {displayableItem.GetShortDescription()}");
                }

                return resultBuilder.ToString().TrimEnd();
            }
            catch (ArgumentException exception)
            {
                return $"Interface search failed: {exception.Message}";
            }
        }

        /// <summary>
        /// Gets a detailed library report.
        /// </summary>
        /// <returns>A formatted report containing basic info, categories, estimated values, and total value.</returns>
        public string GetDetailedReport()
        {
            return _library.GetDetailedReport();
        }

        private string TryAddMediaItem(Func<MediaItem> createItem, string mediaTypeName)
        {
            try
            {
                MediaItem item = createItem();
                _library.AddItem(item);

                return $"Added {mediaTypeName}: {item.GetShortDescription()}";
            }
            catch (ArgumentException exception)
            {
                return $"Could not add {mediaTypeName}: {exception.Message}";
            }
        }
    }
}