using System;

namespace MediaLibrarySystem
{
    public sealed class MusicAlbum : MediaItem
    {
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
            return $"Music Album: {Title} ({Year}) by {Artist} | {TrackCount} tracks | ID: {MediaId}";
        }

        public override string GetBasicInfo()
        {
            return $"{base.GetBasicInfo()} | Album by {Artist}";
        }
    }
}