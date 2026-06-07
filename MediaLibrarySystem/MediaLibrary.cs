using System;
using System.Collections.Generic;

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
                Console.WriteLine(item.GetDisplayInfo());
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
    }
}