# GameEngine
This is a hobby project being developed only by me for entertainment and learning purposes, as well as using it in future game jams.
The project is developed 100% with C#, with the only exception being the use of the Raylib_cs package, a C# Binding for the Raylib Library. The engine is made with the intention of making games entirely with coding and no editors.
Feel free to make your own contributions if you so desire to try to extend my spaghetti code.

More information on current progress on: https://github.com/users/thiagomvas/projects/1
## Setup
To set the engine up, follow these steps:

1. Clone this repository.
2. Navigate to the project folder.
3. Run `dotnet restore` to download the project dependencies.
4. Run `dotnet run` to start the engine and the project in it.

## Developing games with it
Currently, no actual documentation besides method and field summaries exist, however, these are general guidelines:

- Anything that exists in the game world should be a GameObject.
- Any children of a GameObject should be added with the AddChildren() method.
- For easy control over the gamera, instantiate a Camera2DObject. It also inherits GameObject, which means it can be set as children of another GameObject to make it follow the object.
- There is a simple Player object which also inherits GameObject with basic top down controls.

