using Raylib_cs;
using System.Numerics;
using static GameEngineProject.Source.Core.Utils.UI;
using static GameEngineProject.Source.Core.Utils.Conversions;
using static Raylib_cs.Raylib;

namespace GameEngineProject.Source.Entities
{
    public class UIElement : GameObject
    {
        /// <summary>
        /// Screen Pivot Points enum
        /// </summary>
        public enum PivotPoint { Center, TopLeft, Left, BottomLeft, Bottom, BottomRight, Right, TopRight, Top }

        /// <summary>
        /// The pivot point used to reposition this element whenever the screen resizes. <br/> <br/>
        /// To modify, use <see cref="SetPivot(PivotPoint)"/>
        /// </summary>
        /// 
        public PivotPoint Pivot { get; private set; } = PivotPoint.Center;
        
        /// <summary>
        /// The element's original position.
        /// </summary>
        public Vector2 OriginalPosition { get; init; }
        private Vector2 Delta = Vector2.Zero;
        public UIElement(Vector2 position) => OriginalPosition = position;

        /// <summary>
        /// Updates the element's position whenever its resized.
        /// </summary>
        public void UpdatePosition()
        {
            Vector2 newPos = Vector2.Zero;
            switch(Pivot)
            {
                case PivotPoint.Center:
                    newPos = ScreenCenter + Delta;
                    break;
                case PivotPoint.TopLeft:
                    newPos = ScreenTopLeft + Delta;
                    break;
                case PivotPoint.Left:
                    newPos = ScreenLeft + Delta;
                    break;
                case PivotPoint.BottomLeft:
                    newPos = ScreenBottomLeft + Delta;
                    break;
                case PivotPoint.Bottom:
                    newPos = ScreenBottom + Delta;
                    break;
                case PivotPoint.BottomRight:
                    newPos = ScreenBottomRight + Delta;
                    break;
                case PivotPoint.Right:
                    newPos = ScreenRight + Delta;
                    break;
                case PivotPoint.TopRight:
                    newPos = ScreenTopRight + Delta;
                    break;
                case PivotPoint.Top:
                    newPos = ScreenTop + Delta;
                    break;

            }
            Transform.Position = newPos;
        }

        /// <summary>
        /// Changes the pivot point of this element.
        /// </summary>
        /// <param name="pivot"></param>
        public void SetPivot(PivotPoint pivot)
        {
            Pivot = pivot;
            switch (Pivot)
            {
                case PivotPoint.Center:
                    Delta = OriginalPosition - ScreenCenter;
                    break;
                case PivotPoint.TopLeft:
                    Delta = OriginalPosition;
                    break;
                case PivotPoint.Left:
                    Delta = OriginalPosition - ScreenLeft;
                    break;
                case PivotPoint.BottomLeft:
                    Delta = OriginalPosition - ScreenBottomLeft;
                    break;
                case PivotPoint.Bottom:
                    Delta = OriginalPosition - ScreenBottom;
                    break;
                case PivotPoint.BottomRight:
                    Delta = OriginalPosition - ScreenBottomRight;
                    break;
                case PivotPoint.Right:
                    Delta = OriginalPosition - ScreenRight;
                    break;
                case PivotPoint.TopRight:
                    Delta = OriginalPosition - ScreenTopRight;
                    break;
                case PivotPoint.Top:
                    Delta = OriginalPosition - ScreenTop;
                    break;

            }
        }

        /// <summary>
        /// Draws the UIElement on screen. Override the method to change how it will be drawn.
        /// </summary>
        public virtual void Render()
        {
            if (!IsActive) return;
        }
    }
}
