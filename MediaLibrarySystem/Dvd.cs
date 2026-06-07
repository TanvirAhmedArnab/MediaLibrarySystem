using System;

namespace MediaLibrarySystem
{
    public sealed class Dvd : MediaItem
    {
        private string _director = string.Empty;
        private int _runtimeMinutes;

        public Dvd(string title, int year, string director, int runtimeMinutes)
            : base(title, year)
        {
            Director = director;
            RuntimeMinutes = runtimeMinutes;
        }

        public string Director
        {
            get
            {
                return _director;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Director cannot be empty.", nameof(value));
                }

                _director = value.Trim();
            }
        }

        public int RuntimeMinutes
        {
            get
            {
                return _runtimeMinutes;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        value,
                        "Runtime must be greater than zero minutes.");
                }

                _runtimeMinutes = value;
            }
        }

        public override string GetDisplayInfo()
        {
            return $"DVD: {Title} directed by {Director} ({Year}) - {RuntimeMinutes} minutes";
        }

        public override string GetBasicInfo()
        {
            return $"{base.GetBasicInfo()} | DVD directed by {Director}";
        }
    }
}