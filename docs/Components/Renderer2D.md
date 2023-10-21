# Renderer2D

## `Field` parent

```csharp
public GameObject parent
```


## `Property` transform
The parent's transform.
```csharp
public Transform transform { public get; set; }
```


## `Method` Awake
The parent's transform.
```csharp
public override void Awake(GameObject gameObject)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| gameObject | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | No description. |


## `Method` OnRender
Passes a few checks before calling <see cref="Render()"/>
```csharp
public void OnRender()
```


## `Method` Render
How the object will be drawn by the GraphicsManager2D.
```csharp
public virtual void Render()
```


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

