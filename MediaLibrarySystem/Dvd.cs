using System;
using System.Collections.Generic;

namespace MediaLibrarySystem
{
    public sealed class Dvd : MediaItem
    {
        private const double ValuePerRuntimeMinute = 0.05;
        private const double MaximumRuntimeValueAdjustment = 10.0;

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

        public override string GetShortDescription()
        {
            return $"DVD: {Title} directed by {Director}";
        }

        public override string GetBasicInfo()
        {
            return $"{base.GetBasicInfo()} | DVD directed by {Director}";
        }

        public override double GetEstimatedValue()
        {
            double baseValue = base.GetEstimatedValue();
            double runtimeAdjustment = Math.Min(MaximumRuntimeValueAdjustment, RuntimeMinutes * ValuePerRuntimeMinute);

            return Math.Round(baseValue + runtimeAdjustment, 2);
        }

        public override string GetCategoryInfo()
        {
            string runtimeCategory = RuntimeMinutes >= 120 ? "Feature-Length DVD" : "Short DVD";

            return $"DVD | {runtimeCategory} | Director: {Director}";
        }

        public override bool MatchesSearch(string searchTerm)
        {
            return ContainsSearchTerm(GetSearchableTerms(), searchTerm);
        }

        public override List<string> GetSearchableTerms()
        {
            List<string> searchableTerms = base.GetSearchableTerms();
            searchableTerms.Add(Director);
            searchableTerms.Add("DVD");

            return searchableTerms;
        }
    }
}