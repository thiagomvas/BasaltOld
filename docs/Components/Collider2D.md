# Collider2D

## `Field` OnCollision

```csharp
private EventHandler OnCollision
```


## `Field` parent

```csharp
public GameObject parent
```


## `Method` Destroy
Event triggered when this object collides with something.
```csharp
public override void Destroy()
```


## `Method` Start
Event triggered when this object collides with something.
```csharp
public override void Start(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | No description. |


## `Method` CheckAllCollisions
Method to be ran to check if object is colliding with something.
```csharp
private void CheckAllCollisions()
```


## `Method` CheckCollision
The method used to check if an object is colliding with this object.
```csharp
public virtual void CheckCollision(GameObject other)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| other | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | The other object to check collisions with |


## `Method` SolveCollision
The method used to solve the collision (Offset the position so it's not inside the object or do something else)
```csharp
public virtual void SolveCollision(Collider2D collided)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| collided | [Collider2D](https://thiagomvas.github.io/GameEngine/Components/Collider2D.html) | The object that collided with this |


## `Method` InvokeOnCollision
Invokes the OnCollisionEvent event.
```csharp
public void InvokeOnCollision(GameObject collided)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| collided | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | The GameObject that collided with this object |


## `Method` DrawDebugHitbox
Method used by the Debug System to draw the hitboxes on selection.
```csharp
public virtual void DrawDebugHitbox(Vector2 screenPos)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| screenPos | Vector2 | The on screen coordinates to use as center |


## `Method` Awake

```csharp
public override void Awake(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | No description. |


## `Method` OnUpdate

```csharp
public void OnUpdate()
```


## `Method` Update

```csharp
public override void Update()
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

