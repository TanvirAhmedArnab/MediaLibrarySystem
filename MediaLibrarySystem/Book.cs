using System;
using System.Collections.Generic;

namespace MediaLibrarySystem
{
    /// <summary>
    /// Represents a book media item in the library.
    /// </summary>
    /// <remarks>
    /// A book extends <see cref="MediaItem"/> with author and page count information.
    /// </remarks>
    public sealed class Book : MediaItem
    {
        private const int MaximumAuthorLength = 80;
        private const int MinimumPageCount = 1;
        private const int MaximumPageCount = 10000;
        private const double ValuePerPage = 0.03;
        private const double MaximumPageValueAdjustment = 15.0;

        private string _author = string.Empty;
        private int _pageCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="year">The publication year of the book.</param>
        /// <param name="author">The author of the book.</param>
        /// <param name="pageCount">The number of pages in the book.</param>
        public Book(string title, int year, string author, int pageCount)
            : base(title, year)
        {
            Author = author;
            PageCount = pageCount;
        }

        /// <summary>
        /// Gets or sets the book author.
        /// </summary>
        /// <value>The validated and trimmed author name.</value>
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

        /// <summary>
        /// Gets or sets the number of pages in the book.
        /// </summary>
        /// <value>The validated page count.</value>
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

        /// <summary>
        /// Gets detailed book display information.
        /// </summary>
        /// <returns>A formatted string containing the book title, author, year, and page count.</returns>
        public override string GetDisplayInfo()
        {
            return $"Book: {Title} by {Author} ({Year}) - {PageCount} pages";
        }

        /// <summary>
        /// Gets a compact book description.
        /// </summary>
        /// <returns>A short string containing the book title and author.</returns>
        public override string GetShortDescription()
        {
            return $"Book: {Title} by {Author}";
        }

        /// <summary>
        /// Gets basic book information.
        /// </summary>
        /// <returns>A formatted string containing shared media information and the author.</returns>
        public override string GetBasicInfo()
        {
            return $"{base.GetBasicInfo()} | Book by {Author}";
        }

        /// <summary>
        /// Calculates the estimated book value using base value plus a capped page-count adjustment.
        /// </summary>
        /// <returns>The estimated book value rounded to two decimal places.</returns>
        public override double GetEstimatedValue()
        {
            double baseValue = base.GetEstimatedValue();
            double pageAdjustment = Math.Min(MaximumPageValueAdjustment, PageCount * ValuePerPage);

            return Math.Round(baseValue + pageAdjustment, 2);
        }

        /// <summary>
        /// Gets category information for the book.
        /// </summary>
        /// <returns>A string describing the book category and author.</returns>
        public override string GetCategoryInfo()
        {
            string lengthCategory = PageCount >= 400 ? "Long Book" : "Standard Book";

            return $"Book | {lengthCategory} | Author: {Author}";
        }

        /// <summary>
        /// Determines whether the book matches a search term.
        /// </summary>
        /// <param name="searchTerm">The search text entered by the user.</param>
        /// <returns><c>true</c> if the book matches the search term; otherwise, <c>false</c>.</returns>
        public override bool MatchesSearch(string searchTerm)
        {
            return ContainsSearchTerm(GetSearchableTerms(), searchTerm);
        }

        /// <summary>
        /// Gets searchable terms for this book.
        /// </summary>
        /// <returns>A list containing shared media terms, the author, and the media type.</returns>
        public override List<string> GetSearchableTerms()
        {
            List<string> searchableTerms = base.GetSearchableTerms();
            searchableTerms.Add(Author);
            searchableTerms.Add("Book");

            return searchableTerms;
        }
    }
}