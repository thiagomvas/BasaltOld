# Conversions

## `Method` XYFromVector3
Converts a Vector3 into a Vector2 by removing the Z axis
```csharp
public static Vector2 XYFromVector3(Vector3 vector)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| vector | Vector3 | The vector to convert from |


## `Method` XYToVector3
Converts a Vector2 into a Vector3 using it for X and Y axis
```csharp
public static Vector3 XYToVector3(Vector2 vector)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| vector | Vector2 | The Vector to convert from |


## `Method` ForwardDirectionFromQuaternion
Gets the forward normalized vector from a rotation.
```csharp
public static Vector3 ForwardDirectionFromQuaternion(Quaternion rotation)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| rotation | Quaternion | The rotation quaternionn |


## `Method` StringifyGameObject
Turns a game object and all it's components into readable text.
```csharp
public static String StringifyGameObject(GameObject obj)
```
### Parameters

| Parameter Name | Type | Description |
| --------- | --------- | --------- |
| obj | [GameObject](https://thiagomvas.github.io/GameEngine/Entities/GameObject.html) | The game object to convert |


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

