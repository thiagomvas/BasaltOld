# Rigidbody

## `Field` Mass

```csharp
public Single Mass
```


## `Field` Drag

```csharp
public Single Drag
```


## `Field` Velocity
Current velocity of the rigidbody (initialized as zero).
```csharp
public Vector2 Velocity
```


## `Field` Acceleration
Current acceleration of the rigidbody (initialized as zero).
```csharp
public Vector2 Acceleration
```


## `Field` IsKinematic

```csharp
public Boolean IsKinematic
```


## `Field` StoppingThreshold

```csharp
public Single StoppingThreshold
```


## `Field` parent

```csharp
public GameObject parent
```


## `Method` Update
Threshold for stopping velocity to avoid small drifting (default: 0.001f).
```csharp
public override Void Update()
```


## `Method` AddForce
Add a force to the rigidbody's acceleration.
```csharp
public Void AddForce(Vector2 force)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| force | Vector2 | The force to be applied to the acceleration. |


## `Method` Awake

```csharp
public override Void Awake(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | No description. |


## `Method` Destroy

```csharp
public override Void Destroy()
```


## `Method` Start

```csharp
public override Void Start(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | No description. |


## `Method` OnUpdate

```csharp
public Void OnUpdate()
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

