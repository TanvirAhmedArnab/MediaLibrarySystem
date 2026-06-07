using System;
using System.Collections.Generic;
using System.Text;

namespace MediaLibrarySystem
{
    public sealed class MediaLibrary
    {
        private readonly List<MediaItem> _mediaItems;

        public MediaLibrary()
        {
            _mediaItems = new List<MediaItem>();
        }

        public void AddItem(MediaItem item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Media item cannot be null.");
            }

            _mediaItems.Add(item);
        }

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

        public void DisplayDetailedReport()
        {
            if (_mediaItems.Count == 0)
            {
                Console.WriteLine("The media library is currently empty.");
                return;
            }

            double totalEstimatedValue = 0.0;

            Console.WriteLine("Detailed Library Report");
            Console.WriteLine("-----------------------");

            foreach (MediaItem item in _mediaItems)
            {
                double estimatedValue = item.GetEstimatedValue();
                totalEstimatedValue += estimatedValue;

                Console.WriteLine(item.GetBasicInfo());
                Console.WriteLine($"Category: {item.GetCategoryInfo()}");
                Console.WriteLine($"Estimated Value: ${estimatedValue:F2}");
                Console.WriteLine();
            }

            Console.WriteLine($"Total Estimated Library Value: ${totalEstimatedValue:F2}");
        }
    }
}