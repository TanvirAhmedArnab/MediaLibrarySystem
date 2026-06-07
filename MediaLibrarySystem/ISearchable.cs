using System.Collections.Generic;

namespace MediaLibrarySystem
{
    public interface ISearchable
    {
        bool MatchesSearch(string searchTerm);

        List<string> GetSearchableTerms();
    }
}