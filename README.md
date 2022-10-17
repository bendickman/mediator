# Mediator

## Development Environment

The project was built using Visual Studio 2022 targeting .NET 6

## Overview

The aim of this repository is to provide an implementation of the Mediator pattern without using any third-party libraries such as MediatR.

When using the likes of MediatR through-out your code, you quickly become dependant of that implememtation, which can provide issues later down the line. By implementing your own version of the Mediator pattern, you gain back more control over your codebase.

The approach for this application was based on the following blog post (https://cezarypiatek.github.io/post/why-i-dont-use-mediatr-for-cqrs/) and provides further reasons for your own implementation.

## Architecture Approach

This solution follows the [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture) approach by Jason Taylor and consists of the following:


### Mediator.API

This layer is a Web API that provides all the endpoints of the application

### Mediator.Infrastucture

This layer is a simple class library that contains classes for accessing external resources such as web services. These classes should be based on interfaces defined within the application layer.

### Mediator.Application

This layer is a simple class library that contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. 

This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Mediator.Domain

This layer is a simple class library that contains all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

## Technologies

* [.NET 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
* [Scrutor](https://github.com/khellang/Scrutor)