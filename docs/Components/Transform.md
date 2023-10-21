# Transform

## `Field` OnPositionChanged

```csharp
private EventHandler`1 OnPositionChanged
```


## `Field` parent

```csharp
public GameObject parent
```


## `Property` Position
This object's current position.
```csharp
public Vector2 Position { public get; public set; }
```


## `Property` Rotation
This object's current rotation.
```csharp
public Quaternion Rotation { public get; public set; }
```


## `Property` Forward
Returns a direction vector representing the direction this object is looking at.
```csharp
public Vector2 Forward { public get;  set; }
```


## `Property` Children

```csharp
public List`1 Children { public get;  set; }
```


## `Method` Move
Moves the transform and all it's children by an amount in each axis
```csharp
public Void Move(Vector2 units)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| units | Vector2 | The amount to move in each axis |


## `Method` MoveTo
Moves the transform and all it's chidren to a point
```csharp
public Void MoveTo(Vector2 point)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| point | Vector2 | The point to set the position as |


## `Method` AddChildren
Adds a children to this transform
```csharp
public Void AddChildren(GameObject obj)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| obj | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | The game object to set as children |


## `Method` AddChildren
Adds a children to this transform
```csharp
public Void AddChildren(Transform transform)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| transform | [Transform](https://thiagomvas.github.io/GameEngine/Components/Transform.html) | The transform to set as children |


## `Method` Destroy

```csharp
public Void Destroy()
```


## `Method` Awake

```csharp
public Void Awake(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | No description. |


## `Method` Start

```csharp
public Void Start(GameObject gameObject)
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
public Void Update()
```


## `Method` GetType

```csharp
public Type GetType()
```


## `Method` MemberwiseClone

```csharp
private Object MemberwiseClone()
```


## `Method` Finalize

```csharp
private Void Finalize()
```


## `Method` ToString

```csharp
public String ToString()
```


## `Method` Equals

```csharp
public Boolean Equals(Object obj)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| obj | Object | No description. |


## `Method` GetHashCode

```csharp
public Int32 GetHashCode()
```

