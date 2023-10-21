# UIElement

## `Field` Delta
The element's original position.
```csharp
private Vector2 Delta
```


## `Field` IsActive

```csharp
public Boolean IsActive
```


## `Property` Pivot
The pivot point used to reposition this element whenever the screen resizes. <br/> <br/>         To modify, use <see cref="SetPivot(PivotPoint)"/>
```csharp
public PivotPoint Pivot { public get;  set; }
```


## `Property` OriginalPosition
The element's original position.
```csharp
public Vector2 OriginalPosition { public get; public set; }
```


## `Property` Transform

```csharp
public Transform Transform { public get;  set; }
```


## `Property` Rigidbody

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


## `Method` UpdatePosition
Updates the element's position whenever its resized.
```csharp
public Void UpdatePosition()
```


## `Method` SetPivot
Changes the pivot point of this element.
```csharp
public Void SetPivot(PivotPoint pivot)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| pivot | PivotPoint |  |


## `Method` Render
Draws the UIElement on screen. Override the method to change how it will be drawn.
```csharp
public virtual Void Render()
```


## `Method` AddChildren

```csharp
public Void AddChildren(GameObject obj)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| obj | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | No description. |


## `Method` Awake

```csharp
public override Void Awake()
```


## `Method` Start

```csharp
public override Void Start()
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
public override Void Destroy()
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

