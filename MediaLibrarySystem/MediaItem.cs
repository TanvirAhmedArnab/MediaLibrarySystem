using System;
using System.Collections.Generic;

namespace MediaLibrarySystem
{
    public abstract class MediaItem : IDisplayable, ISearchable
    {
        private const int MinimumYear = 1800;
        private const int MaximumTitleLength = 100;

        private static int s_nextId = 1;

        private readonly int _mediaId;
        private string _title = string.Empty;
        private int _year;

        protected MediaItem(string title, int year)
        {
            _mediaId = GenerateMediaId();
            Title = title;
            Year = year;
        }

        public int MediaId
        {
            get
            {
                return _mediaId;
            }
        }

        public string MediaCode
        {
            get
            {
                return $"MEDIA-{MediaId:0000}";
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                ValidateTitle(value);
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
                ValidateYear(value);
                _year = value;
            }
        }

        public abstract string GetDisplayInfo();

        public abstract string GetShortDescription();

        public virtual string GetBasicInfo()
        {
            return $"{MediaCode} | {Title} ({Year})";
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

        public virtual bool MatchesSearch(string searchTerm)
        {
            return ContainsSearchTerm(GetSearchableTerms(), searchTerm);
        }

        public virtual List<string> GetSearchableTerms()
        {
            return new List<string>
            {
                Title,
                Year.ToString(),
                MediaId.ToString(),
                MediaCode
            };
        }

        protected static void ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty or whitespace.", nameof(title));
            }

            if (title.Trim().Length > MaximumTitleLength)
            {
                throw new ArgumentException(
                    $"Title cannot exceed {MaximumTitleLength} characters.",
                    nameof(title));
            }
        }

        protected static void ValidateYear(int year)
        {
            int currentYear = DateTime.Now.Year;

            if (year < MinimumYear || year > currentYear)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(year),
                    year,
                    $"Year must be between {MinimumYear} and {currentYear}.");
            }
        }

        protected static string ValidateRequiredText(
            string value,
            string parameterName,
            string displayName,
            int maximumLength)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    $"{displayName} cannot be empty or whitespace.",
                    parameterName);
            }

            string trimmedValue = value.Trim();

            if (trimmedValue.Length > maximumLength)
            {
                throw new ArgumentException(
                    $"{displayName} cannot exceed {maximumLength} characters.",
                    parameterName);
            }

            return trimmedValue;
        }

        protected static void ValidateNumberRange(
            int value,
            string parameterName,
            string displayName,
            int minimumValue,
            int maximumValue)
        {
            if (value < minimumValue || value > maximumValue)
            {
                throw new ArgumentOutOfRangeException(
                    parameterName,
                    value,
                    $"{displayName} must be between {minimumValue} and {maximumValue}.");
            }
        }

        protected static bool ContainsSearchTerm(IEnumerable<string> searchableTerms, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return false;
            }

            string normalizedSearchTerm = searchTerm.Trim();

            foreach (string term in searchableTerms)
            {
                if (term.Contains(normalizedSearchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private static int GenerateMediaId()
        {
            int mediaId = s_nextId;
            s_nextId++;

            return mediaId;
        }
    }
}