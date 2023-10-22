# ObjectPooling

## `Field` Pool

```csharp
public List`1 Pool
```


## `Property` Queue
Gets the current index used to retrieve objects from the pool.
```csharp
public Int32 Queue { public get; set; }
```


## `Method` Get
Retrieves a GameObject from the pool, cycling through the available objects.
```csharp
public GameObject Get()
```


## `Method` Populate
Adds a GameObject to the object pool, expanding it if necessary.
```csharp
public void Populate(GameObject obj)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| obj | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | The GameObject to add to the pool. |


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

