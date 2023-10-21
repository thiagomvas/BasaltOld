# Collider2D

## `Field` OnCollision

```csharp
private EventHandler`1 OnCollision
```


## `Field` parent

```csharp
public GameObject parent
```


## `Method` Destroy
Event triggered when this object collides with something.
```csharp
public override Void Destroy()
```


## `Method` Start
Event triggered when this object collides with something.
```csharp
public override Void Start(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | No description. |


## `Method` CheckAllCollisions
Method to be ran to check if object is colliding with something.
```csharp
private Void CheckAllCollisions()
```


## `Method` CheckCollision
The method used to check if an object is colliding with this object.
```csharp
public virtual Void CheckCollision(GameObject other)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| other | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | The other object to check collisions with |


## `Method` SolveCollision
The method used to solve the collision (Offset the position so it's not inside the object or do something else)
```csharp
public virtual Void SolveCollision(Collider2D collided)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| collided | [Collider2D](https://thiagomvas.github.io/GameEngine/Components/Collider2D.html) | The object that collided with this |


## `Method` InvokeOnCollision
Invokes the OnCollisionEvent event.
```csharp
public Void InvokeOnCollision(GameObject collided)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| collided | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | The GameObject that collided with this object |


## `Method` DrawDebugHitbox
Method used by the Debug System to draw the hitboxes on selection.
```csharp
public virtual Void DrawDebugHitbox(Vector2 screenPos)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| screenPos | Vector2 | The on screen coordinates to use as center |


## `Method` Awake

```csharp
public override Void Awake(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | No description. |


## `Method` OnUpdate

```csharp
public Void OnUpdate()
```


## `Method` Update

```csharp
public override Void Update()
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
override Void Finalize()
```


## `Method` ToString

```csharp
public override String ToString()
```


## `Method` Equals

```csharp
public override Boolean Equals(Object obj)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| obj | Object | No description. |


## `Method` GetHashCode

```csharp
public override Int32 GetHashCode()
```

