# Simple Media Library System

Simple Media Library System is a C# console application built as a capstone project for the Coursera course [Advanced C# Language Features & Object-Oriented Programming](https://www.coursera.org/learn/advanced-c-language-features--object-oriented-programming?specialization=beginners-guide-to-c-sharp-fundamentals).

The project models a local media library that needs to manage different types of media items, including books, DVDs, and music albums. The main goal of this project is to practice object-oriented programming concepts such as inheritance, polymorphism, encapsulation, abstraction, interfaces, validation, exception handling, XML documentation, and AI-assisted code review in a clear, maintainable C# application.

## Course Context

This project is part of the Beginners Guide to C# Fundamentals Professional Certificate. It is designed to demonstrate advanced C# language features and object-oriented design through a complete console-based media library system.

## Project Purpose

The purpose of this application is to build a structured media management system that can grow from a simple class hierarchy into a complete library application. The project begins with a shared abstract base class, expands into derived media types, includes a library collection that can manage different media items through a common base type, introduces interfaces for display and search behavior, adds stronger encapsulation with centralized validation and a manager layer, and now includes comprehensive XML documentation and AI-assisted code quality improvements.

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
* Demonstration of multiple media types processed uniformly through a shared library collection
* Demonstration of interface-based abstraction through display and search contracts
* Demonstration of a manager layer hiding collection and validation complexity from the main program
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

The `MediaLibrary` class encapsulates the internal media collection by keeping its `List<MediaItem>` private. Outside code cannot directly modify the internal list. Instead, it must use controlled public methods.

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

The current console application demonstrates the media library by:

1. Creating a `MediaLibraryManager` instance.
2. Adding valid books, DVDs, and music albums through manager methods.
3. Attempting to add invalid media items to test friendly error handling.
4. Displaying all media items through polymorphic method calls.
5. Displaying a short summary through the `IDisplayable` interface.
6. Searching for media items by exact title.
7. Searching for media items by flexible searchable terms such as author, director, artist, and media type.
8. Testing multi-word token-based searches such as `hobbit tolkien` and `dark side pink`.
9. Handling missing search results safely.
10. Generating a detailed report with category information and estimated values.
11. Calculating the total estimated value of the library collection.

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

The `Program` class also includes a top-level exception handler as a final safety net for unexpected errors.

## Search Behavior

The project includes two levels of search behavior.

`FindByTitle()` performs a direct title search and returns the first matching media item.

`SearchItems()` performs flexible interface-based searching through the `ISearchable` contract. This allows different media types to expose different searchable terms:

* Books can be searched by title, year, media ID, author, or media type.
* DVDs can be searched by title, year, media ID, director, or media type.
* Music albums can be searched by title, year, media ID, artist, or media type.

The search behavior now supports multi-word token matching. Each word in the search query must match at least one searchable term for an item to be returned.

For example:

* `tolkien` can match `The Hobbit` because Tolkien is the author.
* `hobbit tolkien` can match `The Hobbit` because one token
