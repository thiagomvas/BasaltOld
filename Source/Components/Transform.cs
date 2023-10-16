using GameEngineProject.Source.Entities;
using GameEngineProject.Source.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameEngineProject.Source.Components
{
    /// <summary>
    /// Holds the object's positional data, like the Position and Rotation. It is always included in every Game Object
    /// </summary>
    public class Transform : IComponent
    {
        /// <summary>
        /// This object's current position
        /// </summary>
        public Vector3 Position { get; set; }
        /// <summary>
        /// This object's current rotation
        /// </summary>
        public Quaternion Rotation { get; set; }

        #region Constructors
        public Transform()
        {
            Position = Vector3.Zero;
            Rotation = Quaternion.Identity;
        }

        public Transform(Vector3 position)
        {
            Position = position;
            Rotation = Quaternion.Identity;
        }

        #endregion

        public void Initialize(GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        public void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}
