namespace MediaLibrarySystem
{
    /// <summary>
    /// Defines a display contract for objects that can provide user-readable media information.
    /// </summary>
    public interface IDisplayable
    {
        /// <summary>
        /// Gets a complete display string that includes the most important details about the object.
        /// </summary>
        /// <returns>A formatted string containing detailed display information.</returns>
        string GetDisplayInfo();

        /// <summary>
        /// Gets a short display string suitable for summaries, search results, and compact lists.
        /// </summary>
        /// <returns>A compact string describing the object.</returns>
        string GetShortDescription();
    }
}