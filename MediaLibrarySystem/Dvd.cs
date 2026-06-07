using System;
using System.Collections.Generic;

namespace MediaLibrarySystem
{
    /// <summary>
    /// Represents a DVD media item in the library.
    /// </summary>
    /// <remarks>
    /// A DVD extends <see cref="MediaItem"/> with director and runtime information.
    /// </remarks>
    public sealed class Dvd : MediaItem
    {
        private const int MaximumDirectorLength = 80;
        private const int MinimumRuntimeMinutes = 1;
        private const int MaximumRuntimeMinutes = 1000;
        private const double ValuePerRuntimeMinute = 0.05;
        private const double MaximumRuntimeValueAdjustment = 10.0;

        private string _director = string.Empty;
        private int _runtimeMinutes;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dvd"/> class.
        /// </summary>
        /// <param name="title">The title of the DVD.</param>
        /// <param name="year">The release year of the DVD.</param>
        /// <param name="director">The director of the DVD.</param>
        /// <param name="runtimeMinutes">The runtime length in minutes.</param>
        public Dvd(string title, int year, string director, int runtimeMinutes)
            : base(title, year)
        {
            Director = director;
            RuntimeMinutes = runtimeMinutes;
        }

        /// <summary>
        /// Gets or sets the DVD director.
        /// </summary>
        /// <value>The validated and trimmed director name.</value>
        public string Director
        {
            get
            {
                return _director;
            }

            set
            {
                _director = ValidateRequiredText(
                    value,
                    nameof(value),
                    "Director",
                    MaximumDirectorLength);
            }
        }

        /// <summary>
        /// Gets or sets the DVD runtime in minutes.
        /// </summary>
        /// <value>The validated runtime length.</value>
        public int RuntimeMinutes
        {
            get
            {
                return _runtimeMinutes;
            }

            set
            {
                ValidateNumberRange(
                    value,
                    nameof(value),
                    "Runtime",
                    MinimumRuntimeMinutes,
                    MaximumRuntimeMinutes);

                _runtimeMinutes = value;
            }
        }

        /// <summary>
        /// Gets detailed DVD display information.
        /// </summary>
        /// <returns>A formatted string containing the DVD title, director, year, and runtime.</returns>
        public override string GetDisplayInfo()
        {
            return $"DVD: {Title} directed by {Director} ({Year}) - {RuntimeMinutes} minutes";
        }

        /// <summary>
        /// Gets a compact DVD description.
        /// </summary>
        /// <returns>A short string containing the DVD title and director.</returns>
        public override string GetShortDescription()
        {
            return $"DVD: {Title} directed by {Director}";
        }

        /// <summary>
        /// Gets basic DVD information.
        /// </summary>
        /// <returns>A formatted string containing shared media information and the director.</returns>
        public override string GetBasicInfo()
        {
            return $"{base.GetBasicInfo()} | DVD directed by {Director}";
        }

        /// <summary>
        /// Calculates the estimated DVD value using base value plus a capped runtime adjustment.
        /// </summary>
        /// <returns>The estimated DVD value rounded to two decimal places.</returns>
        public override double GetEstimatedValue()
        {
            double baseValue = base.GetEstimatedValue();
            double runtimeAdjustment = Math.Min(MaximumRuntimeValueAdjustment, RuntimeMinutes * ValuePerRuntimeMinute);

            return Math.Round(baseValue + runtimeAdjustment, 2);
        }

        /// <summary>
        /// Gets category information for the DVD.
        /// </summary>
        /// <returns>A string describing the DVD category and director.</returns>
        public override string GetCategoryInfo()
        {
            string runtimeCategory = RuntimeMinutes >= 120 ? "Feature-Length DVD" : "Short DVD";

            return $"DVD | {runtimeCategory} | Director: {Director}";
        }

        /// <summary>
        /// Determines whether the DVD matches a search term.
        /// </summary>
        /// <param name="searchTerm">The search text entered by the user.</param>
        /// <returns><c>true</c> if the DVD matches the search term; otherwise, <c>false</c>.</returns>
        public override bool MatchesSearch(string searchTerm)
        {
            return ContainsSearchTerm(GetSearchableTerms(), searchTerm);
        }

        /// <summary>
        /// Gets searchable terms for this DVD.
        /// </summary>
        /// <returns>A list containing shared media terms, the director, and the media type.</returns>
        public override List<string> GetSearchableTerms()
        {
            List<string> searchableTerms = base.GetSearchableTerms();
            searchableTerms.Add(Director);
            searchableTerms.Add("DVD");

            return searchableTerms;
        }
    }
}