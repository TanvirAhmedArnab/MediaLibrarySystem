using System;
using System.Collections.Generic;

namespace MediaLibrarySystem
{
    /// <summary>
    /// Represents a music album media item in the library.
    /// </summary>
    /// <remarks>
    /// A music album extends <see cref="MediaItem"/> with artist and track count information.
    /// </remarks>
    public sealed class MusicAlbum : MediaItem
    {
        private const int MaximumArtistLength = 80;
        private const int MinimumTrackCount = 1;
        private const int MaximumTrackCount = 500;
        private const double ValuePerTrack = 0.75;
        private const double MaximumTrackValueAdjustment = 12.0;

        private string _artist = string.Empty;
        private int _trackCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicAlbum"/> class.
        /// </summary>
        /// <param name="title">The album title.</param>
        /// <param name="year">The release year of the album.</param>
        /// <param name="artist">The album artist.</param>
        /// <param name="trackCount">The number of tracks on the album.</param>
        public MusicAlbum(string title, int year, string artist, int trackCount)
            : base(title, year)
        {
            Artist = artist;
            TrackCount = trackCount;
        }

        /// <summary>
        /// Gets or sets the album artist.
        /// </summary>
        /// <value>The validated and trimmed artist name.</value>
        public string Artist
        {
            get
            {
                return _artist;
            }

            set
            {
                _artist = ValidateRequiredText(
                    value,
                    nameof(value),
                    "Artist",
                    MaximumArtistLength);
            }
        }

        /// <summary>
        /// Gets or sets the number of tracks on the album.
        /// </summary>
        /// <value>The validated track count.</value>
        public int TrackCount
        {
            get
            {
                return _trackCount;
            }

            set
            {
                ValidateNumberRange(
                    value,
                    nameof(value),
                    "Track count",
                    MinimumTrackCount,
                    MaximumTrackCount);

                _trackCount = value;
            }
        }

        /// <summary>
        /// Gets detailed album display information.
        /// </summary>
        /// <returns>A formatted string containing the album title, artist, year, and track count.</returns>
        public override string GetDisplayInfo()
        {
            return $"Album: {Title} by {Artist} ({Year}) - {TrackCount} tracks";
        }

        /// <summary>
        /// Gets a compact album description.
        /// </summary>
        /// <returns>A short string containing the album title and artist.</returns>
        public override string GetShortDescription()
        {
            return $"Album: {Title} by {Artist}";
        }

        /// <summary>
        /// Gets basic album information.
        /// </summary>
        /// <returns>A formatted string containing shared media information and the artist.</returns>
        public override string GetBasicInfo()
        {
            return $"{base.GetBasicInfo()} | Album by {Artist}";
        }

        /// <summary>
        /// Calculates the estimated album value using base value plus a capped track-count adjustment.
        /// </summary>
        /// <returns>The estimated album value rounded to two decimal places.</returns>
        public override double GetEstimatedValue()
        {
            double baseValue = base.GetEstimatedValue();
            double trackAdjustment = Math.Min(MaximumTrackValueAdjustment, TrackCount * ValuePerTrack);

            return Math.Round(baseValue + trackAdjustment, 2);
        }

        /// <summary>
        /// Gets category information for the music album.
        /// </summary>
        /// <returns>A string describing the album category and artist.</returns>
        public override string GetCategoryInfo()
        {
            string albumCategory = TrackCount >= 10 ? "Full-Length Album" : "Short Album";

            return $"Music Album | {albumCategory} | Artist: {Artist}";
        }

        /// <summary>
        /// Determines whether the music album matches a search term.
        /// </summary>
        /// <param name="searchTerm">The search text entered by the user.</param>
        /// <returns><c>true</c> if the album matches the search term; otherwise, <c>false</c>.</returns>
        public override bool MatchesSearch(string searchTerm)
        {
            return ContainsSearchTerm(GetSearchableTerms(), searchTerm);
        }

        /// <summary>
        /// Gets searchable terms for this music album.
        /// </summary>
        /// <returns>A list containing shared media terms, the artist, and album-related media type terms.</returns>
        public override List<string> GetSearchableTerms()
        {
            List<string> searchableTerms = base.GetSearchableTerms();
            searchableTerms.Add(Artist);
            searchableTerms.Add("Music Album");
            searchableTerms.Add("Album");

            return searchableTerms;
        }
    }
}