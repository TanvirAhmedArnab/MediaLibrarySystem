# Simple Media Library System

Simple Media Library System is a C# console application built as a capstone project for the Coursera course [Advanced C# Language Features & Object-Oriented Programming](https://www.coursera.org/learn/advanced-c-language-features--object-oriented-programming?specialization=beginners-guide-to-c-sharp-fundamentals).

The project models a local media library that needs to manage different types of media items, including books, DVDs, and music albums. The main goal of this project is to practice object-oriented programming concepts such as inheritance, polymorphism, encapsulation, abstraction, interfaces, validation, exception handling, XML documentation, AI-assisted code review, and final OOP demonstration in a clear, maintainable C# application.

## Course Context

This project is part of the Beginners Guide to C# Fundamentals Professional Certificate. It is designed to demonstrate advanced C# language features and object-oriented design through a complete console-based media library system.

## Project Purpose

The purpose of this application is to build a structured media management system that can grow from a simple class hierarchy into a complete library application. The project begins with a shared abstract base class, expands into derived media types, includes a library collection that can manage different media items through a common base type, introduces interfaces for display and search behavior, adds stronger encapsulation with centralized validation and a manager layer, includes comprehensive XML documentation, and finishes with a complete console demonstration of the implemented OOP principles.

This project also demonstrates how version control can track the evolution of object-oriented class design step by step.

## Current Features

* Console application project setup
* Welcome and closing application messages
* Abstract `MediaItem` base class
* Private backing fields for encapsulation
* Read-only auto-incrementing `MediaId`
* Formatted `MediaCode` property
* Validated `Title` property
* Validated `Year` property
* Centralized protected validation methods in the base class
* Maximum title length validation
* Dynamic year validation up to the current year
* `IDisplayable` interface for display behavior
* `ISearchable` interface for search behavior
* Abstract `GetDisplayInfo()` method
* Abstract `GetShortDescription()` method
* Virtual `GetBasicInfo()` method
* Virtual `GetEstimatedValue()` method with base depreciation logic
* Virtual `GetCategoryInfo()` method with default category behavior
* Virtual `MatchesSearch()` method for searchable media behavior
* Virtual `GetSearchableTerms()` method for search term exposure
* `Book` derived class with author and page count validation
* `Dvd` derived class with director and runtime validation
* `MusicAlbum` derived class with artist and track count validation
* Constructor chaining from derived classes to the `MediaItem` base class
* Method overriding in all derived media classes
* Custom estimated value logic for books based on page count
* Custom estimated value logic for DVDs based on runtime
* Custom estimated value logic for music albums based on track count
* Custom category information for each media type
* Custom searchable terms for books, DVDs, and music albums
* Token-based multi-word search matching
* `MediaLibrary` class for managing a collection of media items
* `MediaLibraryManager` class for simplified user-facing operations
* `ItemCount` property for verifying valid library state
* `AddItem()` method that accepts any `MediaItem` derived object
* `GetAllItems()` method that returns a copy of the internal media collection
* `DisplayAllItems()` method that displays all items through interface-based polymorphic calls
* `FindByTitle()` method with case-insensitive title search
* `SearchItems()` method with flexible interface-based search
* `GetDisplaySummary()` method using the `IDisplayable` interface
* `GetDetailedReport()` method that shows basic info, category, estimated value, and total library value
* Friendly error messages for invalid media creation attempts
* Comprehensive XML documentation comments for public classes, methods, properties, and interfaces
* XML documentation file generation enabled in the project file
* Main program architecture comment block documenting OOP design and AI assistance
* Final console demonstration of inheritance, polymorphism, encapsulation, and abstraction
* Final validation test showing invalid items do not corrupt library state
* Final project reflection printed by the application
* Basic top-level exception handling in the console application
* Git repository setup with `.gitignore` and `.gitattributes`

## Object-Oriented Programming Concepts Used

### Encapsulation

The `MediaItem` class protects internal data through private fields and public properties. Validation logic prevents invalid values such as empty titles, overly long titles, or years outside the accepted range.

The media ID is stored as a private read-only field. It is assigned during object construction and cannot be changed afterward. This protects the identity of each media item after creation.

The derived classes also apply encapsulation:

* `Book` validates author name and page count.
* `Dvd` validates director name and runtime.
* `MusicAlbum` validates artist name and track count.

The `MediaLibrary` class encapsulates the internal media collection by keeping its `List<MediaItem>` private. Outside code cannot directly modify the internal list. Instead, it must use controlled public methods. The `GetAllItems()` method returns a copy of the collection, which prevents external callers from directly modifying the original internal list.

The `MediaLibraryManager` class adds another layer of encapsulation by hiding object creation, exception handling, and collection operations behind simple user-facing methods.

### Abstraction

`MediaItem` is an abstract class. It cannot be instantiated directly. Instead, it defines the common structure that all specific media item types must follow.

The project also uses interfaces for abstraction:

* `IDisplayable` defines a contract for objects that can provide display information.
* `ISearchable` defines a contract for objects that can participate in search operations.

The `MediaLibraryManager` class demonstrates abstraction by hiding implementation complexity from the main program. `Program.cs` does not need to know how the collection is stored, how validation is triggered, or how exceptions are caught. It calls simple methods such as `AddBook()`, `AddDvd()`, `AddMusicAlbum()`, and `GetSearchResultsDisplay()`.

### Inheritance

The project includes three derived classes:

* `Book`
* `Dvd`
* `MusicAlbum`

Each class inherits from the abstract `MediaItem` base class and reuses its shared title, year, media ID, basic display behavior, estimated value behavior, category behavior, searchable behavior, and validation helpers.

The derived constructors use constructor chaining to call the base `MediaItem` constructor before initializing their own specific fields.

### Polymorphism

The application stores `Book`, `Dvd`, and `MusicAlbum` objects inside a shared `MediaLibrary` collection that uses the base type `MediaItem`.

This allows the program to treat different media types uniformly while still calling each class's overridden methods.

Polymorphism is demonstrated through multiple methods:

* `GetDisplayInfo()`
* `GetShortDescription()`
* `GetBasicInfo()`
* `GetEstimatedValue()`
* `GetCategoryInfo()`
* `MatchesSearch()`
* `GetSearchableTerms()`

At runtime, C# automatically calls the correct implementation from `Book`, `Dvd`, or `MusicAlbum` depending on the actual object type.

### Interfaces

The `IDisplayable` interface defines display-related behavior:

* `GetDisplayInfo()`
* `GetShortDescription()`

The `ISearchable` interface defines search-related behavior:

* `MatchesSearch()`
* `GetSearchableTerms()`

`MediaItem` implements both interfaces, and all derived media classes inherit those contracts. Each derived class customizes the behavior by overriding methods and adding type-specific searchable terms.

This demonstrates how interfaces create consistent behavior contracts across different object types.

## Inheritance and Interface Structure

```text
IDisplayable
├── MediaItem
│   ├── Book
│   ├── Dvd
│   └── MusicAlbum

ISearchable
├── MediaItem
│   ├── Book
│   ├── Dvd
│   └── MusicAlbum
```

## Main Application Flow

The final console application demonstrates the media library by:

1. Creating a `MediaLibraryManager` instance.
2. Adding valid books, DVDs, and music albums through manager methods.
3. Attempting to add invalid media items to test friendly error handling.
4. Confirming that invalid creation attempts do not change the valid library item count.
5. Displaying all media items through polymorphic method calls.
6. Displaying a short summary through the `IDisplayable` interface.
7. Searching for media items by exact title.
8. Searching for media items by flexible searchable terms such as author, director, artist, and media type.
9. Testing multi-word token-based searches such as `hobbit tolkien` and `dark side pink`.
10. Handling missing and invalid search results safely.
11. Generating a detailed report with category information and estimated values.
12. Calculating the total estimated value of the library collection.
13. Printing a summary of all four OOP principles.
14. Printing a debugging guide for constructor chaining, polymorphism, interface calls, and encapsulation.
15. Printing a final project reflection.

## Validation Rules

The base `MediaItem` class validates shared media data:

* Title cannot be empty or whitespace.
* Title cannot exceed 100 characters.
* Year must be between 1800 and the current year.
* Media ID is generated automatically and cannot be changed after construction.

Derived classes validate their own specialized data:

* Book author cannot be empty or too long.
* Book page count must be within an accepted range.
* DVD director cannot be empty or too long.
* DVD runtime must be within an accepted range.
* Music album artist cannot be empty or too long.
* Music album track count must be within an accepted range.

These validation rules protect the object model from invalid state.

## Error Handling

Model classes throw exceptions when invalid data is provided. This keeps validation close to the data it protects.

The `MediaLibraryManager` class catches expected validation exceptions and converts them into user-friendly messages. This keeps the console application from crashing during normal invalid input scenarios.

The final demonstration verifies that invalid creation attempts do not corrupt the library state by comparing the item count before and after invalid input tests.

The `Program` class also includes a top-level exception handler as a final safety net for unexpected errors.

## Search Behavior

The project includes two levels of search behavior.

`FindByTitle()` performs a direct title search and returns the first matching media item.

`SearchItems()` performs flexible interface-based searching through the `ISearchable` contract. This allows different media types to expose different searchable terms:

* Books can be searched by title, year, media ID, author, or media type.
* DVDs can be searched by title, year, media ID, director, or media type.
* Music albums can be searched by title, year, media ID, artist, or media type.

The search behavior supports multi-word token matching. Each word in the search query must match at least one searchable term for an item to be returned.

For example:

* `tolkien` can match `The Hobbit` because Tolkien is the author.
* `hobbit tolkien` can match `The Hobbit` because one token matches the title and the other matches the author.
* `dark side pink` can match `The Dark Side of the Moon` because some tokens match the title and one token matches the artist.

This improves search flexibility while keeping the algorithm simple enough for the current project stage.

## Value Estimation Logic

The base `MediaItem` class provides a default estimated value based on item age. The value decreases over time but does not fall below a minimum base value.

Each derived class customizes the calculation:

* `Book` adds a capped adjustment based on page count.
* `Dvd` adds a capped adjustment based on runtime.
* `MusicAlbum` adds a capped adjustment based on track count.

These adjustments keep the calculation simple enough for the current project stage while still demonstrating meaningful method overriding.

## Technology Used

* C#
* .NET Console Application
* Visual Studio Community
* Git
* GitHub Desktop
* GitHub

## Testing Summary

The final version was manually tested by creating multiple valid instances of each derived media type:

* Multiple `Book` objects
* Multiple `Dvd` objects
* Multiple `MusicAlbum` objects

The sample objects are added through the `MediaLibraryManager`, which hides the underlying collection and object creation details from the main program.

Invalid creation attempts were also tested:

* Empty title
* Future year
* Invalid page count
* Invalid runtime
* Invalid track count
* Empty artist

These invalid inputs are rejected by validation logic and converted into friendly error messages by the manager layer.

The final demonstration confirms that invalid input does not corrupt the library state by checking that the item count remains the same before and after invalid creation attempts.

The `GetAllItemsDisplay()` behavior was tested to confirm that each object displays its own specialized output through overridden `GetDisplayInfo()` methods.

The `GetDisplaySummary()` method was tested to confirm that media items can be displayed through the `IDisplayable` interface.

The `FindByTitle()` method was tested with:

* Exact title matches
* Different letter casing
* Missing title searches
* Empty title search input

The `SearchItems()` method was tested with:

* Book author searches
* DVD director searches
* Music album artist searches
* Media type searches
* Multi-word searches
* Missing search terms
* Empty search input

This confirms that interface-based search works across all media types and that invalid or missing search results are handled safely.

The `GetDetailedReport()` method was tested to confirm that each item displays basic information, category information, estimated value, and contributes to the total estimated library value.

## Debugging Summary

Breakpoints can be placed inside the property setters for `Title`, `Year`, `Author`, `PageCount`, `Director`, `RuntimeMinutes`, `Artist`, and `TrackCount` to confirm that validation occurs before private fields are updated.

Breakpoints can be placed inside the `MediaItem`, `Book`, `Dvd`, and `MusicAlbum` constructors to observe constructor chaining. When a derived object is created, the base class constructor runs first. After the base `MediaItem` state is initialized, the derived class constructor continues and initializes type-specific data.

Breakpoints can be placed inside the `GetDisplayInfo()`, `GetShortDescription()`, `MatchesSearch()`, `GetSearchableTerms()`, `GetEstimatedValue()`, and `GetCategoryInfo()` methods of `Book`, `Dvd`, and `MusicAlbum`.

When the application calls these methods through `MediaItem`, `IDisplayable`, or `ISearchable` references, the debugger shows that the runtime chooses the correct implementation based on the actual object type.

This demonstrates runtime polymorphic method resolution and interface-based abstraction.

Private fields such as `_title`, `_year`, `_mediaItems`, and media-specific backing fields cannot be accessed directly from `Program.cs`. This confirms that encapsulation protects internal state.

## AI Assistance Disclosure

AI assistance was used during development to review object-oriented design, class naming, constructor chaining, validation logic, polymorphic collection design, search behavior, interface design, estimated value calculations, XML documentation, final demonstration structure, and README organization.

AI-assisted suggestions that were accepted:

* Use XML documentation comments for public classes, interfaces, methods, and properties.
* Enable XML documentation file generation in the project file.
* Document why each abstraction exists, not only what each method does.
* Improve search from simple substring matching to token-based multi-word matching.
* Add a manager layer to hide object creation, collection management, and expected validation exceptions.
* Add a final console demonstration that explicitly shows inheritance, polymorphism, encapsulation, and abstraction.

AI-assisted suggestions that were rejected or deferred:

* Fuzzy search
* Weighted search scoring
* Search ranking
* File persistence
* External indexing
* Database storage
* Complex menu systems
* Automated unit testing

Those suggestions may be useful later, but they were not necessary for the current course milestone and would have added unnecessary complexity.

## Development Reflection

This project demonstrates mastery of core OOP principles by building a small but structured system around a real media-library problem. Inheritance is shown through the `MediaItem` base class and its `Book`, `Dvd`, and `MusicAlbum` derived classes. Polymorphism is shown when different media types are stored in one collection and processed through shared base-class and interface references. Encapsulation is shown through private fields, validated properties, read-only IDs, copied collections, and controlled manager methods. Abstraction is shown through the abstract `MediaItem` class, the `IDisplayable` and `ISearchable` interfaces, and the `MediaLibraryManager` layer.

The most challenging part of the inheritance design was deciding which behavior belongs in the base class and which behavior belongs in derived classes. Shared rules such as title validation, year validation, media identity, and basic search terms belong in `MediaItem`. Type-specific details such as author, director, artist, page count, runtime, and track count belong in the derived classes. Keeping those responsibilities separated made the design cleaner and easier to extend.

AI assistance was useful for reviewing documentation quality, improving search behavior, and checking whether the design clearly demonstrated the required OOP principles. The most useful suggestions were XML documentation, token-based search, and a clearer final demonstration workflow. Suggestions that would have added unnecessary complexity, such as fuzzy search, scoring, persistence, or external indexing, were intentionally not implemented. Future improvements could include a fully interactive menu, saving and loading from files, borrowing and returning media, due dates, categories, and automated unit tests.

## Version Control Approach

This project uses Git to track the evolution of the class design step by step. Each commit represents one meaningful improvement, such as setting up the project, creating the base class, adding derived classes, implementing polymorphic collections, adding advanced virtual methods, implementing interfaces, improving validation, adding documentation, or completing the final demonstration.

Current major milestones:

1. Initial project setup with `MediaItem` base class
2. Implementation of `Book`, `Dvd`, and `MusicAlbum` inheritance hierarchy
3. Implementation of polymorphic media collection and title search
4. Implementation of advanced polymorphic methods and AI-assisted value calculation improvements
5. Implementation of `IDisplayable` and `ISearchable` interfaces
6. Enhancement of encapsulation with advanced validation and error handling
7. Addition of AI-assisted improvements and comprehensive documentation
8. Completion of the media library system with comprehensive OOP demonstration

## Repository Status

This project is complete as a course capstone demonstration of object-oriented programming in C#.

The final system demonstrates inheritance, polymorphism, encapsulation, abstraction, interfaces, validation, exception handling, XML documentation, AI-assisted improvement, flexible search, detailed reporting, and a final structured console demonstration.

Future improvements could include interactive menus, persistent storage, borrowing and returning workflows, due dates, automated tests, and a richer user interface.
