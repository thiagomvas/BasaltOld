# MathExtended

## `Method` LookAtRotation
Returns the rotation from the origin if it was looking at a target
```csharp
public static Quaternion LookAtRotation(Vector2 origin, Vector2 target)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| origin | Vector2 | The origin coordinates |
| target | Vector2 | The target's position to rotate towards |


## `Method` GetForwardVector
Gets the forward vector of a rotation.
```csharp
public static Vector2 GetForwardVector(Quaternion rotation)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| rotation | Quaternion | The rotation |


## `Method` WorldToScreenPosition
Converts a world coordinate into a screen coordinate
```csharp
public static Vector2 WorldToScreenPosition(Vector2 worldPosition, Camera2D camera)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| worldPosition | Vector2 | The world position |
| camera | Camera2D | The camera used |


## `Method` ScreenToWorldPosition
Converts a screen position to world position
```csharp
public static Vector2 ScreenToWorldPosition(Vector2 position, Camera2D camera)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| position | Vector2 | The screen position |
| camera | Camera2D | The camera used |


## `Method` GetZRotation

```csharp
public static Single GetZRotation(Quaternion quaternion)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| quaternion | Quaternion | No description. |


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

