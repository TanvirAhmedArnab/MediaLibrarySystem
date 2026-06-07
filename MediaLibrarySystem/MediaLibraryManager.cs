using System;
using System.Collections.Generic;
using System.Text;

namespace MediaLibrarySystem
{
    public sealed class MediaLibraryManager
    {
        private readonly MediaLibrary _library;

        public MediaLibraryManager()
            : this(new MediaLibrary())
        {
        }

        public MediaLibraryManager(MediaLibrary library)
        {
            _library = library ?? throw new ArgumentNullException(nameof(library));
        }

        public string AddBook(string title, int year, string author, int pageCount)
        {
            return TryAddMediaItem(
                () => new Book(title, year, author, pageCount),
                "book");
        }

        public string AddDvd(string title, int year, string director, int runtimeMinutes)
        {
            return TryAddMediaItem(
                () => new Dvd(title, year, director, runtimeMinutes),
                "DVD");
        }

        public string AddMusicAlbum(string title, int year, string artist, int trackCount)
        {
            return TryAddMediaItem(
                () => new MusicAlbum(title, year, artist, trackCount),
                "music album");
        }

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

        public string GetDisplaySummary()
        {
            return _library.GetDisplaySummary();
        }

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