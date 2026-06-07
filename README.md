# Simple Media Library System

Simple Media Library System is a C# console application built as a capstone project for the Coursera course [Advanced C# Language Features & Object-Oriented Programming](https://www.coursera.org/learn/advanced-c-language-features--object-oriented-programming?specialization=beginners-guide-to-c-sharp-fundamentals).

The project models a local media library that needs to manage different types of media items, including books, DVDs, and music albums. The main goal of this project is to practice object-oriented programming concepts such as inheritance, polymorphism, encapsulation, and abstraction in a clear, maintainable C# application.

## Course Context

This project is part of the Beginners Guide to C# Fundamentals Professional Certificate. It is designed to demonstrate advanced C# language features and object-oriented design through a complete console-based media library system.

## Project Purpose

The purpose of this application is to build a structured media management system that can grow from a simple class hierarchy into a complete library application. The project begins with a shared abstract base class and expands into derived media types that represent different categories of library media.

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
* Polymorphic display using a shared `List<MediaItem>`
* Git repository setup with `.gitignore` and `.gitattributes`

## Object-Oriented Programming Concepts Used

### Encapsulation

The `MediaItem` class protects internal data through private fields and public properties. Validation logic prevents invalid values such as empty titles or years outside the accepted range.

The derived classes also apply encapsulation:

* `Book` validates author name and page count.
* `Dvd` validates director name and runtime.
* `MusicAlbum` validates artist name and track count.

This keeps each object responsible for protecting its own valid state.

### Abstraction

`MediaItem` is an abstract class. It cannot be instantiated directly. Instead, it defines the common structure that all specific media item types must follow.

The abstract `GetDisplayInfo()` method forces every derived media class to provide its own detailed display behavior.

### Inheritance

The project includes three derived classes:

* `Book`
* `Dvd`
* `MusicAlbum`

Each class inherits from the abstract `MediaItem` base class and reuses its shared title, year, media ID, and basic display behavior.

The derived constructors use constructor chaining to call the base `MediaItem` constructor before initializing their own specific fields.

### Polymorphism

The application stores `Book`, `Dvd`, and `MusicAlbum` objects inside a shared `List<MediaItem>`. This allows the program to treat different media types through the same base type while still calling each class's overridden display methods.

This demonstrates polymorphism because the same method call behaves differently depending on the actual object type.

## Inheritance Hierarchy

```text
MediaItem
├── Book
├── Dvd
└── MusicAlbum
```

## Technology Used

* C#
* .NET Console Application
* Visual Studio Community
* Git
* GitHub Desktop
* GitHub

## Testing Summary

The current version was manually tested by creating one instance of each derived media type:

* One `Book`
* One `Dvd`
* One `MusicAlbum`

The sample objects are stored in a shared `List<MediaItem>` and displayed using both basic and detailed information methods.

The inheritance hierarchy was also tested by confirming that each derived class successfully calls the base `MediaItem` constructor and then initializes its own specific properties.

## Debugging Summary

Breakpoints can be placed in the `MediaItem`, `Book`, `Dvd`, and `MusicAlbum` constructors to observe constructor chaining.

When a derived object is created, the base class constructor runs first. After the base `MediaItem` state is initialized, the derived class constructor continues and initializes type-specific data such as author, director, artist, page count, runtime, or track count.

## AI Assistance Disclosure

AI assistance was used during development to review object-oriented design, class naming, constructor chaining, validation logic, and README structure.

All AI-assisted suggestions were reviewed before implementation. Only suggestions that were understandable, relevant to the course requirements, and appropriate for the current project stage were included.

## Development Reflection

This stage of the project focuses on building a correct inheritance hierarchy rather than adding many application features too early. The most important design decision was to use an abstract `MediaItem` base class so that books, DVDs, and music albums can share common behavior while still implementing their own display logic.

Using a shared `List<MediaItem>` makes the polymorphic design visible. The application can work with multiple media types through the base class while still allowing each derived class to provide its own output.

## Planned Features

* Add a menu-driven console interface
* Add new book records from user input
* Add new DVD records from user input
* Add new music album records from user input
* Display all media items
* Search media items by title
* Add borrowing and returning behavior
* Display available and borrowed media items
* Improve validation and input handling
* Add final testing and debugging notes
* Continue improving documentation as the application evolves

## Version Control Approach

This project uses Git to track the evolution of the class design step by step. Each commit should represent one meaningful improvement, such as setting up the project, creating the base class, adding derived classes, implementing borrowing behavior, or improving documentation.

Current major milestones:

1. Initial project setup with `MediaItem` base class
2. Implementation of `Book`, `Dvd`, and `MusicAlbum` inheritance hierarchy

## Repository Status

This project now includes the foundational media inheritance hierarchy. The abstract `MediaItem` base class has been implemented, and the `Book`, `Dvd`, and `MusicAlbum` derived classes demonstrate constructor chaining, validated properties, method overriding, inheritance, and polymorphic behavior.

The next stage will focus on adding more application behavior, such as user interaction, library management, searching, and borrowing features.
