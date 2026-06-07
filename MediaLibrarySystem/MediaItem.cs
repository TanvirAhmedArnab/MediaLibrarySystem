using System;

namespace MediaLibrarySystem
{
    public abstract class MediaItem
    {
        private static int s_nextMediaNumber = 1;

        private string _title = string.Empty;
        private int _year;
        private string _mediaId = string.Empty;

        protected MediaItem(string title, int year)
        {
            MediaId = GenerateMediaId();
            Title = title;
            Year = year;
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title cannot be empty.", nameof(value));
                }

                _title = value.Trim();
            }
        }

        public int Year
        {
            get
            {
                return _year;
            }

            set
            {
                if (value < 1800 || value > 2024)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        value,
                        "Year must be between 1800 and 2024.");
                }

                _year = value;
            }
        }

        public string MediaId
        {
            get
            {
                return _mediaId;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Media ID cannot be empty.", nameof(value));
                }

                _mediaId = value;
            }
        }

        public abstract string GetDisplayInfo();

        public virtual string GetBasicInfo()
        {
            return $"{MediaId} | {Title} ({Year})";
        }

        public virtual double GetEstimatedValue()
        {
            int age = DateTime.Now.Year - Year;
            double estimatedValue = Math.Max(5.0, 25.0 - age * 2.0);

            return Math.Round(estimatedValue, 2);
        }

        public virtual string GetCategoryInfo()
        {
            return "General Media Item";
        }

        private static string GenerateMediaId()
        {
            string mediaId = $"MEDIA-{s_nextMediaNumber:0000}";
            s_nextMediaNumber++;

            return mediaId;
        }
    }
}