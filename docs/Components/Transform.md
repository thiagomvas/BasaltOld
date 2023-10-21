# Transform

## `Field` <Position>k__BackingField

```csharp
private Vector2 <Position>k__BackingField
```


## `Field` <Rotation>k__BackingField

```csharp
private Quaternion <Rotation>k__BackingField
```


## `Field` <Children>k__BackingField

```csharp
private List`1 <Children>k__BackingField
```


## `Field` OnPositionChanged

```csharp
private EventHandler`1 OnPositionChanged
```


## `Field` parent

```csharp
public GameObject parent
```


## `Property` Position

```csharp
public Vector2 Position { public get; public }
```


## `Property` Rotation

```csharp
public Quaternion Rotation { public get; public }
```


## `Property` Forward

```csharp
public Vector2 Forward { public get;  }
```


## `Property` Children

```csharp
public List`1 Children { public get;  }
```


## `Method` add_OnPositionChanged

```csharp
public Void add_OnPositionChanged(EventHandler`1 value)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| value | EventHandler`1 | Lorem ipsum dolor sit amet, consectetur adipiscing elit. |


## `Method` remove_OnPositionChanged

```csharp
public Void remove_OnPositionChanged(EventHandler`1 value)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| value | EventHandler`1 | Lorem ipsum dolor sit amet, consectetur adipiscing elit. |


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
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | Lorem ipsum dolor sit amet, consectetur adipiscing elit. |


## `Method` Start

```csharp
public Void Start(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | Lorem ipsum dolor sit amet, consectetur adipiscing elit. |


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
| obj | Object | Lorem ipsum dolor sit amet, consectetur adipiscing elit. |


## `Method` GetHashCode

```csharp
public Int32 GetHashCode()
```

