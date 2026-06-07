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
* `Book` derived class with author and page count validation
* `Dvd` derived class with director and runtime validation
* `MusicAlbum` derived class with artist and track count validation
* Constructor chaining from derived classes to the `MediaItem` base class
* Method overriding in all derived media classes
* `MediaLibrary` class for managing a collection of media items
* `AddItem()` method that accepts any `MediaItem` derived object
* `DisplayAllItems()` method that displays all items through polymorphic method calls
* `FindByTitle()` method with case-insensitive title search
* Demonstration of multiple media types processed uniformly through a shared library collection
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

Each class inherits from the abstract `MediaItem` base class and reuses its shared title, year, media ID, and basic display behavior.

The derived constructors use constructor chaining to call the base `MediaItem` constructor before initializing their own specific fields.

### Polymorphism

The application stores `Book`, `Dvd`, and `MusicAlbum` objects inside a shared `MediaLibrary` collection that uses the base type `MediaItem`.

This allows the program to treat different media types uniformly while still calling each class's overridden display methods.

For example, `DisplayAllItems()` loops through the media collection and calls `GetDisplayInfo()` on each item. At runtime, C# automatically calls the correct overridden method from `Book`, `Dvd`, or `MusicAlbum`.

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

## Debugging Summary

Breakpoints can be placed inside the `GetDisplayInfo()` methods of `Book`, `Dvd`, and `MusicAlbum`.

When `DisplayAllItems()` calls `GetDisplayInfo()` through a `MediaItem` reference, the debugger shows that the runtime chooses the correct overridden method based on the actual object type.

This demonstrates runtime polymorphic method resolution.

Breakpoints can also be placed in the `MediaItem`, `Book`, `Dvd`, and `MusicAlbum` constructors to observe constructor chaining.

When a derived object is created, the base class constructor runs first. After the base `MediaItem` state is initialized, the derived class constructor continues and initializes type-specific data such as author, director, artist, page count, runtime, or track count.

## AI Assistance Disclosure

AI assistance was used during development to review object-oriented design, class naming, constructor chaining, validation logic, polymorphic collection design, search behavior, and README structure.

All AI-assisted suggestions were reviewed before implementation. Only suggestions that were understandable, relevant to the course requirements, and appropriate for the current project stage were included.

## Development Reflection

This stage of the project focuses on moving from individual derived classes to a polymorphic collection. The important design improvement is the addition of the `MediaLibrary` class, which manages different media types through a single collection of `MediaItem` references.

This makes the object-oriented design more practical. Instead of handling books, DVDs, and music albums separately, the application can process them uniformly through the base class while still preserving their specialized behavior.

The `FindByTitle()` method also begins to move the project toward a real media management system by introducing search behavior across all media types.

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

This project uses Git to track the evolution of the class design step by step. Each commit should represent one meaningful improvement, such as setting up the project, creating the base class, adding derived classes, implementing polymorphic collections, adding search behavior, or improving documentation.

Current major milestones:

1. Initial project setup with `MediaItem` base class
2. Implementation of `Book`, `Dvd`, and `MusicAlbum` inheritance hierarchy
3. Implementation of polymorphic media collection and title search

## Repository Status

This project now includes a polymorphic media collection through the `MediaLibrary` class. The application can store books, DVDs, and music albums in one collection, display each item using overridden methods, and search across all media types by title.

The next stage will focus on adding interactive user input and menu-driven library management.