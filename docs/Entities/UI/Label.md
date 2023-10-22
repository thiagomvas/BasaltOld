# Label

## `Field` Text
The text for this label
```csharp
public string Text
```


## `Field` FontSize
The font size for this label's text
```csharp
public int FontSize
```


## `Field` TextColor
The color of this label's text
```csharp
public Color TextColor
```


## `Field` Spacing
The spacing between each character in this label.
```csharp
public int Spacing
```


## `Field` IsActive

```csharp
public bool IsActive
```


## `Property` Pivot

```csharp
public PivotPoint Pivot { public get; set; }
```


## `Property` OriginalPosition

```csharp
public Vector2 OriginalPosition { public get; public set; }
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


## `Method` Render
The spacing between each character in this label.
```csharp
public override void Render()
```


## `Method` UpdatePosition

```csharp
public void UpdatePosition()
```


## `Method` SetPivot

```csharp
public void SetPivot(PivotPoint pivot)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| pivot | PivotPoint | No description. |


## `Method` OnRender

```csharp
public void OnRender()
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


## `Method` Destroy

```csharp
public override void Destroy()
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

