using System;

namespace MediaLibrarySystem
{
    public sealed class Book : MediaItem
    {
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Author cannot be empty.", nameof(value));
                }

                _author = value.Trim();
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
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        value,
                        "Page count must be greater than zero.");
                }

                _pageCount = value;
            }
        }

        public override string GetDisplayInfo()
        {
            return $"Book: {Title} by {Author} ({Year}) - {PageCount} pages";
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
    }
}