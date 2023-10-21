# Rigidbody

## `Field` Mass
Mass of the rigidbody (default: 1f).
```csharp
public float Mass
```


## `Field` Drag
Linear drag coefficient (default: 10f).
```csharp
public float Drag
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
Determines if the rigidbody is kinematic (doesn't respond to forces).
```csharp
public bool IsKinematic
```


## `Field` StoppingThreshold
Threshold for stopping velocity to avoid small drifting (default: 0.001f).
```csharp
public float StoppingThreshold
```


## `Field` parent

```csharp
public GameObject parent
```


## `Method` Update
Threshold for stopping velocity to avoid small drifting (default: 0.001f).
```csharp
public override void Update()
```


## `Method` AddForce
Add a force to the rigidbody's acceleration.
```csharp
public void AddForce(Vector2 force)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| force | Vector2 | The force to be applied to the acceleration. |


## `Method` Awake

```csharp
public override void Awake(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | No description. |


## `Method` Destroy

```csharp
public override void Destroy()
```


## `Method` Start

```csharp
public override void Start(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | No description. |


## `Method` OnUpdate

```csharp
public void OnUpdate()
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

