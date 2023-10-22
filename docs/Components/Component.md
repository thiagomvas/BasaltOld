# Component

## `Field` parent
The GameObject to which this component is attached.
```csharp
public GameObject parent
```


## `Method` Awake
Initializes the component when a GameObject is awakened.
```csharp
public virtual void Awake(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | The GameObject to which this component is attached. |


## `Method` Destroy
Destroys the component, performing any necessary cleanup.
```csharp
public virtual void Destroy()
```


## `Method` Start
Initializes the component when a GameObject is started.
```csharp
public virtual void Start(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | The GameObject to which this component is attached. |


## `Method` OnUpdate
Event handler for the screen redraw event, which triggers the component's Update method.
```csharp
public void OnUpdate()
```


## `Method` Update
Updates the component's behavior. Override this method to implement custom functionality.
```csharp
public virtual void Update()
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

