# Camera2DObject

## `Field` camera
The actual Camera2D used for rendering.
```csharp
public Camera2D camera
```


## `Field` IsActive

```csharp
public bool IsActive
```


## `Property` Transform

```csharp
public Transform Transform { public get; set; }
```


## `Property` Rigidbody

```csharp
public Rigidbody Rigidbody { public get; set; }
```


## `Property` Components

```csharp
public List`1 Components { public get; set; }
```


## `Property` Children

```csharp
public List`1 Children { public get; set; }
```


## `Method` UpdateCameraPosition

```csharp
private void UpdateCameraPosition(Object sender, TransformPositionUpdatedEventArgs e)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| sender | Object | No description. |
| e | [TransformPositionUpdatedEventArgs](https://thiagomvas.github.io/GameEngine/Core/Types/TransformPositionUpdatedEventArgs.html) | No description. |


## `Method` Destroy
Updates the camera's focus position
```csharp
public override void Destroy()
```


## `Method` AddChildren

```csharp
public void AddChildren(GameObject obj)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| obj | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | No description. |


## `Method` Awake

```csharp
public override void Awake()
```


## `Method` Start

```csharp
public override void Start()
```


## `Method` AddComponent

```csharp
public T AddComponent()
```


## `Method` GetComponent

```csharp
public T GetComponent()
```


## `Method` TryGetComponent

```csharp
public bool TryGetComponent(T& component)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| component | T& | No description. |


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

