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

        public int Count
        {
            get
            {
                return _mediaItems.Count;
            }
        }

        public void AddItem(MediaItem item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Media item cannot be null.");
            }

            _mediaItems.Add(item);
        }

        public List<MediaItem> GetAllItems()
        {
            return new List<MediaItem>(_mediaItems);
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

        public void DisplayDetailedReport()
        {
            Console.WriteLine(GetDetailedReport());
        }
    }
}