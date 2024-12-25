# Architecture Solution Template for .NET

This is a solution template for creating ASP.NET Core Web API that puts together CQRS + DDD (Domain Driven Design).

## Motives

Solution Architecture to use when starting new projects. Using this throughout project would enhance time to setup/start projects, enforce consistency, keep simplicity of the structure and would allow easier testibility.
 
## Project structure

- `Api` - using Minimal API layer.
- `Handlers` - class library with all query and command handlers.
- `Infrastructure` - persistence setup.
- `Core` - common stuff with no major dependecies.
- `Domain` - domain entities and domain services.

## Installation & Running

1. The project creates and migrates SQL database on the runtime, go to [TBD] and set the desired connection string. 

2. Once launched it will pop up swagger page: `/swagger/index.html`

## Usage 

```TBD```

  
## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## Questions, feature requests

- Create a [new issue](https://github.com/gecapo/cqrs-ddd-template/issues/new)
