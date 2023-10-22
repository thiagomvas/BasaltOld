# GameEngine
This is a hobby project being developed only by me for entertainment and learning purposes, as well as using it in future game jams.
The project is developed 100% with C#, with the only exception being the use of the Raylib_cs package, a C# Binding for the Raylib Library. The engine is made with the intention of making games entirely with coding and no editors.
Feel free to make your own contributions if you so desire to try to extend my spaghetti code.

More information on current progress on: https://github.com/users/thiagomvas/projects/1 .
Documentation on: https://thiagomvas.github.io/GameEngine
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

## All Classes
  - [Assets](https://thiagomvas.github.io/GameEngine/Core/Utils/Assets.html)
 - [Camera2DObject](https://thiagomvas.github.io/GameEngine/Entities/Camera2DObject.html)
 - [CircleCollider](https://thiagomvas.github.io/GameEngine/Components/CircleCollider.html)
 - [CircleRenderer](https://thiagomvas.github.io/GameEngine/Components/CircleRenderer.html)
 - [Collider2D](https://thiagomvas.github.io/GameEngine/Components/Collider2D.html)
 - [Component](https://thiagomvas.github.io/GameEngine/Components/Component.html)
 - [Conversions](https://thiagomvas.github.io/GameEngine/Core/Utils/Conversions.html)
 - [CustomDrawing](https://thiagomvas.github.io/GameEngine/Core/Utils/CustomDrawing.html)
 - [CustomShapes](https://thiagomvas.github.io/GameEngine/Core/Utils/CustomShapes.html)
 - [Debug](https://thiagomvas.github.io/GameEngine/Core/Utils/Debug.html)
 - [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html)
 - [Globals](https://thiagomvas.github.io/GameEngine/Core/Globals.html)
 - [GraphicsWindow2D](https://thiagomvas.github.io/GameEngine/Core/Graphics/GraphicsWindow2D.html)
 - [IComponent](https://thiagomvas.github.io/GameEngine/Interfaces/IComponent.html)
 - [Label](https://thiagomvas.github.io/GameEngine/Entities/UI/Label.html)
 - [MathExtended](https://thiagomvas.github.io/GameEngine/Core/Utils/MathExtended.html)
 - [ObjectPooling](https://thiagomvas.github.io/GameEngine/Core/Types/ObjectPooling.html)
 - [OnCollisionEnterEventArgs](https://thiagomvas.github.io/GameEngine/Core/Types/OnCollisionEnterEventArgs.html)
 - [Player](https://thiagomvas.github.io/GameEngine/Entities/Player.html)
 - [ProgressBar](https://thiagomvas.github.io/GameEngine/Entities/UI/ProgressBar.html)
 - [Projectile](https://thiagomvas.github.io/GameEngine/Components/Projectile.html)
 - [Renderer2D](https://thiagomvas.github.io/GameEngine/Components/Renderer2D.html)
 - [Rigidbody](https://thiagomvas.github.io/GameEngine/Components/Rigidbody.html)
 - [SpriteRenderer](https://thiagomvas.github.io/GameEngine/Components/SpriteRenderer.html)
 - [Time](https://thiagomvas.github.io/GameEngine/Core/Utils/Time.html)
 - [Transform](https://thiagomvas.github.io/GameEngine/Components/Transform.html)
 - [TransformPositionUpdatedEventArgs](https://thiagomvas.github.io/GameEngine/Core/Types/TransformPositionUpdatedEventArgs.html)
 - [UI](https://thiagomvas.github.io/GameEngine/Core/Utils/UI.html)
 - [UIElement](https://thiagomvas.github.io/GameEngine/Entities/UIElement.html)