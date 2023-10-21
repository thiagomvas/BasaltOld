# GameObject

## `Field` AwakeCalled

```csharp
private Boolean AwakeCalled
```


## `Field` StartCalled

```csharp
private Boolean StartCalled
```


## `Field` IsActive

```csharp
public Boolean IsActive
```


## `Property` Transform
The object's transforms.
```csharp
public Transform Transform { public get;  set; }
```


## `Property` Rigidbody
The object's transforms.
```csharp
public Rigidbody Rigidbody { public get;  set; }
```


## `Property` Components

```csharp
public List`1 Components { public get;  set; }
```


## `Property` Children

```csharp
public List`1 Children { public get;  set; }
```


## `Method` AddChildren
Attaches a children to this object
```csharp
public Void AddChildren(GameObject obj)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| obj | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | The object to attach |


## `Method` Awake

```csharp
public Void Awake()
```


## `Method` Start

```csharp
public Void Start()
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
public Boolean TryGetComponent(T& component)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| component | T& | No description. |


## `Method` Destroy

```csharp
public Void Destroy()
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

