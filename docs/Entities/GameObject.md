# GameObject

## `Field` AwakeCalled
The Object Class used by the entire engine. It represents any object and it's components that are in any world.
```csharp
private bool AwakeCalled
```


## `Field` StartCalled
The Object Class used by the entire engine. It represents any object and it's components that are in any world.
```csharp
private bool StartCalled
```


## `Field` IsActive
Whether or not an object is active. Defines if it will be drawn, interacted with or interact with something.
```csharp
public bool IsActive
```


## `Property` Transform
The object's transforms.
```csharp
public Transform Transform { public get; set; }
```


## `Property` Rigidbody
The object's transforms.
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


## `Method` AddChildren
Attaches a children to this object
```csharp
public void AddChildren(GameObject obj)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| obj | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | The object to attach |


## `Method` Awake
Ran whenever a game object is instantiated.
```csharp
public virtual void Awake()
```


## `Method` Start
Ran on the first frame of its existance.
```csharp
public virtual void Start()
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


## `Method` Destroy
Destroys the game object and their components, unsubscribing from any events and disconnecting from everything.
```csharp
public virtual void Destroy()
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

