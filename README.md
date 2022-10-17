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

This layer is a simple class library containing all of the implementation logic.

### Mediator.Application

This layer is a simple class library containing all of the interfaces

## Technologies

* [.NET 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
* [Scrutor](https://github.com/khellang/Scrutor)