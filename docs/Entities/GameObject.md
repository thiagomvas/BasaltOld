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
Ran whenever a game object is instantiated.
```csharp
public virtual Void Awake()
```


## `Method` Start
Ran on the first frame of its existance.
```csharp
public virtual Void Start()
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
Destroys the game object and their components, unsubscribing from any events and disconnecting from everything.
```csharp
public virtual Void Destroy()
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

