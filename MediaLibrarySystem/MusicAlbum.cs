using System;

namespace MediaLibrarySystem
{
    public sealed class MusicAlbum : MediaItem
    {
        private const double ValuePerTrack = 0.75;
        private const double MaximumTrackValueAdjustment = 12.0;

        private string _artist = string.Empty;
        private int _trackCount;

        public MusicAlbum(string title, int year, string artist, int trackCount)
            : base(title, year)
        {
            Artist = artist;
            TrackCount = trackCount;
        }

        public string Artist
        {
            get
            {
                return _artist;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Artist cannot be empty.", nameof(value));
                }

                _artist = value.Trim();
            }
        }

        public int TrackCount
        {
            get
            {
                return _trackCount;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        value,
                        "Track count must be greater than zero.");
                }

                _trackCount = value;
            }
        }

        public override string GetDisplayInfo()
        {
            return $"Album: {Title} by {Artist} ({Year}) - {TrackCount} tracks";
        }

        public override string GetBasicInfo()
        {
            return $"{base.GetBasicInfo()} | Album by {Artist}";
        }

        public override double GetEstimatedValue()
        {
            double baseValue = base.GetEstimatedValue();
            double trackAdjustment = Math.Min(MaximumTrackValueAdjustment, TrackCount * ValuePerTrack);

            return Math.Round(baseValue + trackAdjustment, 2);
        }

        public override string GetCategoryInfo()
        {
            string albumCategory = TrackCount >= 10 ? "Full-Length Album" : "Short Album";

            return $"Music Album | {albumCategory} | Artist: {Artist}";
        }
    }
}