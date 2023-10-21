# IComponent

## `Method` Awake
Called whenever an object is created/instantiated. Usually used for setting up the component and its values.
```csharp
public abstract void Awake(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | The parent object that contains this component |


## `Method` Start
Called on the first frame of the game.
```csharp
public abstract void Start(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | The parent object that contains this component |


## `Method` Update
Method called every tick/frame
```csharp
public abstract void Update()
```


## `Method` Destroy
Called when a game object gets destroyed. Used for unsubscribing to events and disconnecting from everything to run before deletion.
```csharp
public abstract void Destroy()
```

