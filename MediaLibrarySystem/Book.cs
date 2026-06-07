using System;

namespace MediaLibrarySystem
{
    public sealed class Book : MediaItem
    {
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
            return $"Book: {Title} ({Year}) by {Author} | {PageCount} pages | ID: {MediaId}";
        }

        public override string GetBasicInfo()
        {
            return $"{base.GetBasicInfo()} | Book by {Author}";
        }
    }
}