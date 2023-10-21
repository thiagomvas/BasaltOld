# Label

## `Field` Text
The text for this label
```csharp
public String Text
```


## `Field` FontSize

```csharp
public Int32 FontSize
```


## `Field` TextColor
The color of this label's text
```csharp
public Color TextColor
```


## `Field` Spacing

```csharp
public Int32 Spacing
```


## `Field` IsActive

```csharp
public Boolean IsActive
```


## `Property` Pivot

```csharp
public PivotPoint Pivot { public get;  set; }
```


## `Property` OriginalPosition

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


## `Method` Render
The spacing between each character in this label.
```csharp
public override Void Render()
```


## `Method` UpdatePosition

```csharp
public Void UpdatePosition()
```


## `Method` SetPivot

```csharp
public Void SetPivot(PivotPoint pivot)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| pivot | PivotPoint | No description. |


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

