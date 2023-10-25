using GameEngineProject.Source.Entities;
using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace GameEngineProject.Source.Components
{
    public class LineRenderer3D : Renderer
    {
        public Color LineColor = Color.PINK;
        public int LineSides = 10;
        public Vector3[] Points;
        public float StartThickness = 1;
        public float EndThickness = 2;
        public bool RoundCorners = true;
        public override void Render()
        {
            for(int i = 0; i < Points.Length - 1; i++)
            {
                float delta = (EndThickness - StartThickness) / (Points.Length - 1);
                float startRadius = StartThickness + delta * i;
                float endRadius = StartThickness + delta * (i+1);
                DrawCylinderEx(Points[i], Points[i + 1], startRadius, endRadius, LineSides, LineColor);
                if (RoundCorners) DrawSphere(Points[i + 1], endRadius, Color.WHITE);
            }
        }

        public override void Start(GameObject gameObject)
        {
            base.Start(gameObject);
        }

        public override void Update()
        {
        }
    }
}
