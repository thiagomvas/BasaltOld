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
    public class Transform : IComponent
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }

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
