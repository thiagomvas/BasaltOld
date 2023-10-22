# GraphicsWindow2D

## `Field` BackgroundColor
Background color for the world.
```csharp
public static Color BackgroundColor
```


## `Field` FontColor
Font color used on UI;
```csharp
public static Color FontColor
```


## `Field` OnScreenRedraw

```csharp
private static event Action OnScreenRedraw
```


## `Field` OnScreenResize

```csharp
private static event Action OnScreenResize
```


## `Field` RenderWorldSpace

```csharp
private static event Action RenderWorldSpace
```


## `Field` RenderUI

```csharp
private static event Action RenderUI
```


## `Method` Init

```csharp
public static void Init(int Width, int Height, Camera2DObject cameraObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| Width | Int32 | No description. |
| Height | Int32 | No description. |
| cameraObject | [Camera2DObject](https://thiagomvas.github.io/GameEngine/Entities/Camera2DObject.html) | No description. |


## `Method` DrawUI
Draws all the UI;
```csharp
private static void DrawUI()
```


## `Method` GetType

```csharp
public Type GetType()
```


## `Method` MemberwiseClone

```csharp
Object MemberwiseClone()
```


## `Method` Finalize

```csharp
override void Finalize()
```


## `Method` ToString

```csharp
public override string ToString()
```


## `Method` Equals

```csharp
public override bool Equals(Object obj)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| obj | Object | No description. |


## `Method` GetHashCode

```csharp
public override int GetHashCode()
```

