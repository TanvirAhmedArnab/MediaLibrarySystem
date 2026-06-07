using System;
using System.Collections.Generic;

namespace MediaLibrarySystem
{
    public sealed class Book : MediaItem
    {
        private const int MaximumAuthorLength = 80;
        private const int MinimumPageCount = 1;
        private const int MaximumPageCount = 10000;
        private const double ValuePerPage = 0.03;
        private const double MaximumPageValueAdjustment = 15.0;

        private string _author = string.Empty;
        private int _pageCount;

        public Book(string title, int year, string author, int pageCount)
            : base(title, year)
        {
            Author = author;
            PageCount = pageCount;
        }

        public string Author
        {
            get
            {
                return _author;
            }

            set
            {
                _author = ValidateRequiredText(
                    value,
                    nameof(value),
                    "Author",
                    MaximumAuthorLength);
            }
        }

        public int PageCount
        {
            get
            {
                return _pageCount;
            }

            set
            {
                ValidateNumberRange(
                    value,
                    nameof(value),
                    "Page count",
                    MinimumPageCount,
                    MaximumPageCount);

                _pageCount = value;
            }
        }

        public override string GetDisplayInfo()
        {
            return $"Book: {Title} by {Author} ({Year}) - {PageCount} pages";
        }

        public override string GetShortDescription()
        {
            return $"Book: {Title} by {Author}";
        }

        public override string GetBasicInfo()
        {
            return $"{base.GetBasicInfo()} | Book by {Author}";
        }

        public override double GetEstimatedValue()
        {
            double baseValue = base.GetEstimatedValue();
            double pageAdjustment = Math.Min(MaximumPageValueAdjustment, PageCount * ValuePerPage);

            return Math.Round(baseValue + pageAdjustment, 2);
        }

        public override string GetCategoryInfo()
        {
            string lengthCategory = PageCount >= 400 ? "Long Book" : "Standard Book";

            return $"Book | {lengthCategory} | Author: {Author}";
        }

        public override bool MatchesSearch(string searchTerm)
        {
            return ContainsSearchTerm(GetSearchableTerms(), searchTerm);
        }

        public override List<string> GetSearchableTerms()
        {
            List<string> searchableTerms = base.GetSearchableTerms();
            searchableTerms.Add(Author);
            searchableTerms.Add("Book");

            return searchableTerms;
        }
    }
}