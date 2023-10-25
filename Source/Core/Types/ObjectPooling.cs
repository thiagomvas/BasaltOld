using GameEngineProject.Source.Components;
using GameEngineProject.Source.Entities;
using System.Numerics;
using System.Security.AccessControl;

namespace GameEngineProject.Source.Core.Types
{
    /// <summary>
    /// Manages object pooling for GameObjects, allowing efficient reuse of objects.
    /// </summary>
    public class ObjectPooling
    {
        /// <summary>
        /// Gets the list of pooled GameObjects.
        /// </summary>
        public List<GameObject> Pool = new();

        /// <summary>
        /// Gets the current index used to retrieve objects from the pool.
        /// </summary>
        public int Queue { get; private set; } = 0;

        /// <summary>
        /// Initializes a new instance of the ObjectPooling class.
        /// </summary>
        public ObjectPooling()
        {
        }

        /// <summary>
        /// Retrieves a GameObject from the pool, cycling through the available objects.
        /// </summary>
        /// <returns>The retrieved GameObject.</returns>
        public GameObject Get()
        {
            Queue = (Queue + 1) % Pool.Count;
            return Pool[Queue];
        }

        /// <summary>
        /// Adds a GameObject to the object pool, expanding it if necessary.
        /// </summary>
        /// <param name="obj">The GameObject to add to the pool.</param>
        public void Populate(GameObject obj)
        {
            Pool.Add(obj);
        }
    }

}
