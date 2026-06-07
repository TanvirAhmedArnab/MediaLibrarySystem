using System.Collections.Generic;

namespace MediaLibrarySystem
{
    /// <summary>
    /// Defines a search contract for objects that can expose searchable terms and evaluate search queries.
    /// </summary>
    public interface ISearchable
    {
        /// <summary>
        /// Determines whether the object matches the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search text entered by the user.</param>
        /// <returns><c>true</c> if the object matches the search term; otherwise, <c>false</c>.</returns>
        bool MatchesSearch(string searchTerm);

        /// <summary>
        /// Gets the searchable terms that should be used when matching this object.
        /// </summary>
        /// <returns>A list of strings that represent searchable values for the object.</returns>
        List<string> GetSearchableTerms();
    }
}