# Simple Media Library System

Simple Media Library System is a C# console application built as a capstone project for the Coursera course [Advanced C# Language Features & Object-Oriented Programming](https://www.coursera.org/learn/advanced-c-language-features--object-oriented-programming?specialization=beginners-guide-to-c-sharp-fundamentals).

The project models a local media library that needs to manage different types of media items, including books, DVDs, and music albums. The main goal of this project is to practice object-oriented programming concepts such as inheritance, polymorphism, encapsulation, and abstraction in a clear, maintainable C# application.

## Course Context

This project is part of the Beginners Guide to C# Fundamentals Professional Certificate. It is designed to demonstrate advanced C# language features and object-oriented design through a complete console-based media library system.

## Project Purpose

The purpose of this application is to build a structured media management system that can grow from a simple class hierarchy into a complete library application. The project begins with a shared abstract base class, expands into derived media types, and now includes a library collection that can manage different media items through a common base type.

This project also demonstrates how version control can track the evolution of object-oriented class design step by step.

## Current Features

* Console application project setup
* Welcome and closing application messages
* Abstract `MediaItem` base class
* Private backing fields for encapsulation
* Validated `Title` property
* Validated `Year` property
* Auto-generated `MediaId` property
* Abstract `GetDisplayInfo()` method
* Virtual `GetBasicInfo()` method
* Virtual `GetEstimatedValue()` method with base depreciation logic
* Virtual `GetCategoryInfo()` method with default category behavior
* `Book` derived class with author and page count validation
* `Dvd` derived class with director and runtime validation
* `MusicAlbum` derived class with artist and track count validation
* Constructor chaining from derived classes to the `MediaItem` base class
* Method overriding in all derived media classes
* Custom estimated value logic for books based on page count
* Custom estimated value logic for DVDs based on runtime
* Custom estimated value logic for music albums based on track count
* Custom category information for each media type
* `MediaLibrary` class for managing a collection of media items
* `AddItem()` method that accepts any `MediaItem` derived object
* `DisplayAllItems()` method that displays all items through polymorphic method calls
* `FindByTitle()` method with case-insensitive title search
* `DisplayDetailedReport()` method that shows basic info, category, estimated value, and total library value
* Demonstration of multiple media types processed uniformly through a shared library collection
* Basic top-level exception handling in the console application
* Git repository setup with `.gitignore` and `.gitattributes`

## Object-Oriented Programming Concepts Used

### Encapsulation

The `MediaItem` class protects internal data through private fields and public properties. Validation logic prevents invalid values such as empty titles or years outside the accepted range.

The derived classes also apply encapsulation:

* `Book` validates author name and page count.
* `Dvd` validates director name and runtime.
* `MusicAlbum` validates artist name and track count.

The `MediaLibrary` class also encapsulates the internal media collection by keeping its `List<MediaItem>` private. Items are added and searched through public methods instead of exposing the list directly.

This keeps each object responsible for protecting its own valid state and prevents outside code from modifying internal data without control.

### Abstraction

`MediaItem` is an abstract class. It cannot be instantiated directly. Instead, it defines the common structure that all specific media item types must follow.

The abstract `GetDisplayInfo()` method forces every derived media class to provide its own detailed display behavior.

The application can work with media items through the abstract `MediaItem` type without needing to know the exact concrete type at every call site.

### Inheritance

The project includes three derived classes:

* `Book`
* `Dvd`
* `MusicAlbum`

Each class inherits from the abstract `MediaItem` base class and reuses its shared title, year, media ID, basic display behavior, estimated value behavior, and category behavior.

The derived constructors use constructor chaining to call the base `MediaItem` constructor before initializing their own specific fields.

### Polymorphism

The application stores `Book`, `Dvd`, and `MusicAlbum` objects inside a shared `MediaLibrary` collection that uses the base type `MediaItem`.

This allows the program to treat different media types uniformly while still calling each class's overridden methods.

Polymorphism is demonstrated through multiple methods:

* `GetDisplayInfo()`
* `GetBasicInfo()`
* `GetEstimatedValue()`
* `GetCategoryInfo()`

For example, `DisplayDetailedReport()` loops through the media collection and calls these methods through `MediaItem` references. At runtime, C# automatically calls the correct implementation from `Book`, `Dvd`, or `MusicAlbum`.

This demonstrates runtime polymorphism because the same method call behaves differently depending on the actual object type.

## Inheritance Hierarchy

```text
MediaItem
├── Book
├── Dvd
└── MusicAlbum
```

## Main Application Flow

The current console application demonstrates the media library by:

1. Creating a `MediaLibrary` instance.
2. Adding several books, DVDs, and music albums.
3. Displaying all media items through polymorphic method calls.
4. Searching for media items by title.
5. Handling missing search results safely.
6. Generating a detailed report with category information and estimated values.
7. Calculating the total estimated value of the library collection.

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

The current version was manually tested by creating multiple instances of each derived media type:

* Multiple `Book` objects
* Multiple `Dvd` objects
* Multiple `MusicAlbum` objects

The sample objects are added to a single `MediaLibrary` instance. This confirms that different media types can be stored together through the shared `MediaItem` base type.

The `DisplayAllItems()` method was tested to confirm that each object displays its own specialized output through overridden `GetDisplayInfo()` methods.

The `FindByTitle()` method was tested with:

* Exact title matches
* Different letter casing
* Missing title searches

This confirms that case-insensitive search works across all media types and that no-match results are handled safely.

The `DisplayDetailedReport()` method was tested to confirm that each item displays basic information, category information, estimated value, and contributes to the total estimated library value.

## Debugging Summary

Breakpoints can be placed inside the `GetDisplayInfo()`, `GetEstimatedValue()`, and `GetCategoryInfo()` methods of `Book`, `Dvd`, and `MusicAlbum`.

When `DisplayAllItems()` or `DisplayDetailedReport()` calls these methods through a `MediaItem` reference, the debugger shows that the runtime chooses the correct overridden method based on the actual object type.

This demonstrates runtime polymorphic method resolution.

Breakpoints can also be placed in the `MediaItem`, `Book`, `Dvd`, and `MusicAlbum` constructors to observe constructor chaining.

When a derived object is created, the base class constructor runs first. After the base `MediaItem` state is initialized, the derived class constructor continues and initializes type-specific data such as author, director, artist, page count, runtime, or track count.

## AI Assistance Disclosure

AI assistance was used during development to review object-oriented design, class naming, constructor chaining, validation logic, polymorphic collection design, search behavior, estimated value calculations, and README structure.

For the estimated value feature, AI assistance suggested making the calculations more controlled by using capped adjustments and rounding values to two decimal places. This suggestion was accepted because it keeps the output readable and prevents very large page counts, runtimes, or track counts from creating unrealistic estimated values.

More complex suggestions, such as using real-world market pricing, condition ratings, popularity scores, or external price data, were not included because they would add unnecessary complexity for the current course stage.

All AI-assisted suggestions were reviewed before implementation. Only suggestions that were understandable, relevant to the course requirements, and appropriate for the current project stage were included.

## Development Reflection

This stage of the project focuses on deeper polymorphism. The previous stage demonstrated polymorphism through display methods. This stage expands the design by adding virtual methods to the base class and overriding them in each derived class.

The important design improvement is that the `MediaLibrary` class does not need separate logic for books, DVDs, and music albums. It can call shared methods through the `MediaItem` base type, and the runtime selects the correct behavior automatically.

The estimated value feature also shows why virtual methods are useful. The base class provides a default value calculation, while each derived class adds a media-specific adjustment.

## Planned Features

* Add a menu-driven console interface
* Add new book records from user input
* Add new DVD records from user input
* Add new music album records from user input
* Display all media items through user-selected menu options
* Search media items by title through user input
* Add borrowing and returning behavior
* Display available and borrowed media items
* Improve validation and input handling
* Add final testing and debugging notes
* Continue improving documentation as the application evolves

## Version Control Approach

This project uses Git to track the evolution of the class design step by step. Each commit should represent one meaningful improvement, such as setting up the project, creating the base class, adding derived classes, implementing polymorphic collections, adding advanced virtual methods, adding search behavior, or improving documentation.

Current major milestones:

1. Initial project setup with `MediaItem` base class
2. Implementation of `Book`, `Dvd`, and `MusicAlbum` inheritance hierarchy
3. Implementation of polymorphic media collection and title search
4. Implementation of advanced polymorphic methods and AI-assisted value calculation improvements

## Repository Status

This project now includes advanced polymorphic behavior through multiple overridden methods. The application can store books, DVDs, and music albums in one collection, display each item using overridden methods, search across all media types by title, generate category-specific information, calculate estimated item values, and display total estimated library value.

The next stage will focus on adding interactive user input and menu-driven library management.
