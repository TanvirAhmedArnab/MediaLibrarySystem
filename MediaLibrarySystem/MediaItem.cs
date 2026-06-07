using System;
using System.Collections.Generic;

namespace MediaLibrarySystem
{
    /// <summary>
    /// Represents the abstract base class for all media items in the library.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class centralizes shared state and behavior for all media types, including title,
    /// publication year, generated media identity, basic display behavior, value estimation,
    /// category information, and search support.
    /// </para>
    /// <para>
    /// Derived classes such as <see cref="Book"/>, <see cref="Dvd"/>, and
    /// <see cref="MusicAlbum"/> inherit this structure and override methods where they need
    /// media-specific behavior.
    /// </para>
    /// </remarks>
    public abstract class MediaItem : IDisplayable, ISearchable
    {
        private const int MinimumYear = 1800;
        private const int MaximumTitleLength = 100;

        private static int s_nextId = 1;

        private readonly int _mediaId;
        private string _title = string.Empty;
        private int _year;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaItem"/> class.
        /// </summary>
        /// <param name="title">The title of the media item.</param>
        /// <param name="year">The release or publication year of the media item.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="title"/> is empty or too long.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="year"/> is outside the accepted range.
        /// </exception>
        protected MediaItem(string title, int year)
        {
            _mediaId = GenerateMediaId();
            Title = title;
            Year = year;
        }

        /// <summary>
        /// Gets the read-only numeric media identifier.
        /// </summary>
        /// <value>A unique auto-incrementing integer assigned when the media item is created.</value>
        public int MediaId
        {
            get
            {
                return _mediaId;
            }
        }

        /// <summary>
        /// Gets the formatted media code.
        /// </summary>
        /// <value>A formatted identifier such as <c>MEDIA-0001</c>.</value>
        public string MediaCode
        {
            get
            {
                return $"MEDIA-{MediaId:0000}";
            }
        }

        /// <summary>
        /// Gets or sets the media title.
        /// </summary>
        /// <value>The validated and trimmed media title.</value>
        /// <exception cref="ArgumentException">
        /// Thrown when the assigned title is empty, whitespace, or longer than the allowed length.
        /// </exception>
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

        /// <summary>
        /// Gets or sets the media release or publication year.
        /// </summary>
        /// <value>The validated year of the media item.</value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the assigned year is earlier than 1800 or later than the current year.
        /// </exception>
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

        /// <summary>
        /// Gets detailed display information for the media item.
        /// </summary>
        /// <returns>A formatted string containing media-specific display information.</returns>
        public abstract string GetDisplayInfo();

        /// <summary>
        /// Gets a short description of the media item.
        /// </summary>
        /// <returns>A compact string suitable for summaries and search results.</returns>
        public abstract string GetShortDescription();

        /// <summary>
        /// Gets basic shared media information.
        /// </summary>
        /// <returns>A formatted string containing the media code, title, and year.</returns>
        public virtual string GetBasicInfo()
        {
            return $"{MediaCode} | {Title} ({Year})";
        }

        /// <summary>
        /// Calculates the estimated value of the media item using base depreciation logic.
        /// </summary>
        /// <returns>The estimated value rounded to two decimal places.</returns>
        public virtual double GetEstimatedValue()
        {
            int age = DateTime.Now.Year - Year;
            double estimatedValue = Math.Max(5.0, 25.0 - age * 2.0);

            return Math.Round(estimatedValue, 2);
        }

        /// <summary>
        /// Gets general category information for the media item.
        /// </summary>
        /// <returns>A category description for the media item.</returns>
        public virtual string GetCategoryInfo()
        {
            return "General Media Item";
        }

        /// <summary>
        /// Determines whether this media item matches the supplied search term.
        /// </summary>
        /// <param name="searchTerm">The search text to evaluate.</param>
        /// <returns><c>true</c> if all search tokens are found in the searchable terms; otherwise, <c>false</c>.</returns>
        public virtual bool MatchesSearch(string searchTerm)
        {
            return ContainsSearchTerm(GetSearchableTerms(), searchTerm);
        }

        /// <summary>
        /// Gets the searchable terms for this media item.
        /// </summary>
        /// <returns>A list containing the title, year, numeric media ID, and formatted media code.</returns>
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

        /// <summary>
        /// Validates a media title.
        /// </summary>
        /// <param name="title">The title to validate.</param>
        /// <exception cref="ArgumentException">Thrown when the title is empty, whitespace, or too long.</exception>
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

        /// <summary>
        /// Validates a media release or publication year.
        /// </summary>
        /// <param name="year">The year to validate.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the year is earlier than 1800 or later than the current year.
        /// </exception>
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

        /// <summary>
        /// Validates required text and returns the trimmed value.
        /// </summary>
        /// <param name="value">The text value to validate.</param>
        /// <param name="parameterName">The parameter name used in exception details.</param>
        /// <param name="displayName">The user-facing field name used in error messages.</param>
        /// <param name="maximumLength">The maximum allowed text length.</param>
        /// <returns>The trimmed validated text.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the value is empty, whitespace, or longer than the allowed length.
        /// </exception>
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

        /// <summary>
        /// Validates that an integer value falls within an inclusive range.
        /// </summary>
        /// <param name="value">The numeric value to validate.</param>
        /// <param name="parameterName">The parameter name used in exception details.</param>
        /// <param name="displayName">The user-facing field name used in error messages.</param>
        /// <param name="minimumValue">The minimum accepted value.</param>
        /// <param name="maximumValue">The maximum accepted value.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the value is outside the accepted range.
        /// </exception>
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

        /// <summary>
        /// Determines whether searchable terms contain all tokens from a search term.
        /// </summary>
        /// <param name="searchableTerms">The terms exposed by a searchable object.</param>
        /// <param name="searchTerm">The search text entered by the user.</param>
        /// <returns>
        /// <c>true</c> if every search token appears in at least one searchable term; otherwise, <c>false</c>.
        /// </returns>
        protected static bool ContainsSearchTerm(IEnumerable<string> searchableTerms, string searchTerm)
        {
            string[] searchTokens = GetSearchTokens(searchTerm);

            if (searchTokens.Length == 0)
            {
                return false;
            }

            List<string> normalizedTerms = new List<string>();

            foreach (string term in searchableTerms)
            {
                if (!string.IsNullOrWhiteSpace(term))
                {
                    normalizedTerms.Add(term.Trim());
                }
            }

            foreach (string token in searchTokens)
            {
                bool tokenMatched = false;

                foreach (string term in normalizedTerms)
                {
                    if (term.Contains(token, StringComparison.OrdinalIgnoreCase))
                    {
                        tokenMatched = true;
                        break;
                    }
                }

                if (!tokenMatched)
                {
                    return false;
                }
            }

            return true;
        }

        private static string[] GetSearchTokens(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Array.Empty<string>();
            }

            return searchTerm.Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        }

        private static int GenerateMediaId()
        {
            int mediaId = s_nextId;
            s_nextId++;

            return mediaId;
        }
    }
}