using System;
using System.Collections.Generic;
using System.Text;

namespace MediaLibrarySystem
{
    /// <summary>
    /// Stores and manages a collection of media items.
    /// </summary>
    /// <remarks>
    /// This class hides the internal <see cref="List{T}"/> implementation and exposes
    /// controlled operations for adding, retrieving, searching, summarizing, and reporting
    /// media items.
    /// </remarks>
    public sealed class MediaLibrary
    {
        private readonly List<MediaItem> _mediaItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaLibrary"/> class.
        /// </summary>
        public MediaLibrary()
        {
            _mediaItems = new List<MediaItem>();
        }

        /// <summary>
        /// Gets the number of media items currently stored in the library.
        /// </summary>
        /// <value>The total number of stored media items.</value>
        public int Count
        {
            get
            {
                return _mediaItems.Count;
            }
        }

        /// <summary>
        /// Adds a media item to the library.
        /// </summary>
        /// <param name="item">The media item to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is <c>null</c>.</exception>
        public void AddItem(MediaItem item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Media item cannot be null.");
            }

            _mediaItems.Add(item);
        }

        /// <summary>
        /// Gets a copy of all media items in the library.
        /// </summary>
        /// <returns>A new list containing the current media items.</returns>
        /// <remarks>
        /// Returning a copy protects the internal collection from direct external modification.
        /// </remarks>
        public List<MediaItem> GetAllItems()
        {
            return new List<MediaItem>(_mediaItems);
        }

        /// <summary>
        /// Displays all media items directly to the console.
        /// </summary>
        /// <remarks>
        /// This method demonstrates polymorphic display behavior through the
        /// <see cref="IDisplayable"/> interface.
        /// </remarks>
        public void DisplayAllItems()
        {
            if (_mediaItems.Count == 0)
            {
                Console.WriteLine("The media library is currently empty.");
                return;
            }

            foreach (MediaItem item in _mediaItems)
            {
                IDisplayable displayableItem = item;
                Console.WriteLine(displayableItem.GetDisplayInfo());
            }
        }

        /// <summary>
        /// Finds the first media item with a matching title.
        /// </summary>
        /// <param name="title">The title to search for.</param>
        /// <returns>The first matching media item, or <c>null</c> when no match is found.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="title"/> is empty or whitespace.</exception>
        public MediaItem? FindByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Search title cannot be empty.", nameof(title));
            }

            string normalizedTitle = title.Trim();

            foreach (MediaItem item in _mediaItems)
            {
                if (string.Equals(item.Title, normalizedTitle, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Searches the media library using interface-based searchable terms.
        /// </summary>
        /// <param name="term">The search text entered by the user.</param>
        /// <returns>A list of media items that match the search term.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="term"/> is empty or whitespace.</exception>
        /// <remarks>
        /// The search supports multi-word queries. Each query token must match at least one
        /// searchable term exposed by a media item.
        /// </remarks>
        /// <example>
        /// Searching for <c>tolkien hobbit</c> can match a book when one token matches
        /// the title and another token matches the author.
        /// </example>
        public List<MediaItem> SearchItems(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                throw new ArgumentException("Search term cannot be empty.", nameof(term));
            }

            List<MediaItem> matchingItems = new List<MediaItem>();

            foreach (MediaItem item in _mediaItems)
            {
                ISearchable searchableItem = item;

                if (searchableItem.MatchesSearch(term))
                {
                    matchingItems.Add(item);
                }
            }

            return matchingItems;
        }

        /// <summary>
        /// Gets a compact display summary of all media items.
        /// </summary>
        /// <returns>A formatted multi-line summary string.</returns>
        public string GetDisplaySummary()
        {
            if (_mediaItems.Count == 0)
            {
                return "The media library is currently empty.";
            }

            StringBuilder summaryBuilder = new StringBuilder();

            summaryBuilder.AppendLine("Media Library Summary");
            summaryBuilder.AppendLine("---------------------");

            foreach (MediaItem item in _mediaItems)
            {
                IDisplayable displayableItem = item;
                summaryBuilder.AppendLine($"- {displayableItem.GetShortDescription()}");
            }

            return summaryBuilder.ToString().TrimEnd();
        }

        /// <summary>
        /// Gets a detailed report for all media items, including category information and estimated values.
        /// </summary>
        /// <returns>A formatted multi-line detailed report string.</returns>
        public string GetDetailedReport()
        {
            if (_mediaItems.Count == 0)
            {
                return "The media library is currently empty.";
            }

            double totalEstimatedValue = 0.0;
            StringBuilder reportBuilder = new StringBuilder();

            reportBuilder.AppendLine("Detailed Library Report");
            reportBuilder.AppendLine("-----------------------");

            foreach (MediaItem item in _mediaItems)
            {
                double estimatedValue = item.GetEstimatedValue();
                totalEstimatedValue += estimatedValue;

                reportBuilder.AppendLine(item.GetBasicInfo());
                reportBuilder.AppendLine($"Category: {item.GetCategoryInfo()}");
                reportBuilder.AppendLine($"Estimated Value: ${estimatedValue:F2}");
                reportBuilder.AppendLine();
            }

            reportBuilder.AppendLine($"Total Estimated Library Value: ${totalEstimatedValue:F2}");

            return reportBuilder.ToString().TrimEnd();
        }

        /// <summary>
        /// Displays the detailed media report directly to the console.
        /// </summary>
        public void DisplayDetailedReport()
        {
            Console.WriteLine(GetDetailedReport());
        }
    }
}