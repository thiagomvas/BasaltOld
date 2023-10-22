# CircleCollider

## `Field` parent

```csharp
public GameObject parent
```


## `Property` Radius
Gets or sets the radius of the collision circle.
```csharp
public Int32 Radius { public get; public set; }
```


## `Method` Start
Initializes the collider when a GameObject is started. 
```csharp
public override void Start(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | The GameObject to which this collider is attached. |


## `Method` CheckCollision
Checks for collisions with another GameObject.
```csharp
public override void CheckCollision(GameObject other)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| other | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | The GameObject to check for collision with. |


## `Method` SolveCollision
Solves a collision with another Collider2D, if it is a CircleCollider.
```csharp
public override void SolveCollision(Collider2D collided)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| collided | [Collider2D](https://thiagomvas.github.io/GameEngine/Components/Collider2D.html) | The collider with which this collider has collided. |


## `Method` DrawDebugHitbox
Draws the debug hitbox of the collider on the screen.
```csharp
public override void DrawDebugHitbox(Vector2 screenPos)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| screenPos | Vector2 | The position on the screen where the hitbox should be drawn. |


## `Method` Destroy

```csharp
public override void Destroy()
```


## `Method` InvokeOnCollision

```csharp
public void InvokeOnCollision(GameObject collided)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| collided | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | No description. |


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

