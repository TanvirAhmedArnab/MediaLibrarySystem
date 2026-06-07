# Simple Media Library System

Simple Media Library System is a C# console application built as a capstone project for the Coursera course [Advanced C# Language Features & Object-Oriented Programming](https://www.coursera.org/learn/advanced-c-language-features--object-oriented-programming?specialization=beginners-guide-to-c-sharp-fundamentals).

The project models a local media library that needs to manage different types of media items, including books, DVDs, and music albums. The main goal is to practice advanced object-oriented programming concepts such as inheritance, polymorphism, encapsulation, and abstraction in a clear, maintainable C# application.

## Course Context

This project is part of the Beginners Guide to C# Fundamentals Professional Certificate. It is designed to demonstrate object-oriented design through a complete console-based media library system.

## Project Purpose

The purpose of this application is to build a structured media management system that can grow from a simple class hierarchy into a complete library application. The project begins with a shared abstract base class and will later expand into derived media types, search features, borrowing behavior, and menu-driven interaction.

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
* Git repository setup with `.gitignore` and `.gitattributes`

## Object-Oriented Programming Concepts

### Encapsulation

The `MediaItem` class protects internal data through private fields and public properties. Validation logic prevents invalid values such as empty titles or years outside the accepted range.

### Abstraction

`MediaItem` is an abstract class. It cannot be instantiated directly. Instead, it defines the common structure that all specific media item types must follow.

### Inheritance

Future classes such as `Book`, `Dvd`, and `MusicAlbum` will inherit from `MediaItem` and reuse its shared state and behavior.

### Polymorphism

The abstract `GetDisplayInfo()` method will allow each derived media type to provide its own display format while still being handled through the shared `MediaItem` base type.

## Technology Used

* C#
* .NET Console Application
* Visual Studio Community
* Git
* GitHub Desktop
* GitHub

## Planned Features

* Add book media items
* Add DVD media items
* Add music album media items
* Display all media items
* Search media items by title
* Borrow and return media items
* Display available and borrowed media items
* Add documented testing and debugging notes
* Add AI assistance disclosure
* Improve the README as the application evolves

## Version Control Approach

This project uses Git to track the evolution of the class design. Each commit should represent one meaningful improvement, such as setting up the project, creating the base class, adding derived classes, implementing borrowing behavior, or improving documentation.

## Repository Status

This project is currently in its initial setup stage. The foundational `MediaItem` base class has been designed, and the application is ready for derived media item classes.
