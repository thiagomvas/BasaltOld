using System.Numerics;
using static Basalt.Source.Core.Utils.UI;
using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using Basalt.Source.Core.Types;

namespace Basalt.Source.Core.UI
{
    /// <summary>
    /// Represents a UI button element.
    /// </summary>
    public class Button : UIElement
    {
        /// <summary>
        /// Gets the label associated with the button.
        /// </summary>
        public Label Label { get; private set; }
        /// <summary>
        /// The normal color of the button when not hovered or clicked.
        /// </summary>
        public Color NormalColor = Color.LIGHTGRAY;
        /// <summary>
        /// The color of the button when hovered.
        /// </summary>
        public Color HoverColor = Color.GRAY;
        /// <summary>
        /// The color of the button when clicked.
        /// </summary>
        public Color ClickColor = Color.DARKGRAY;
        private int Width, Height;
        /// <summary>
        /// Gets a value indicating whether the mouse is currently hovering over the button.
        /// </summary>
        public bool IsHovered { get; private set; } = false;

        /// <summary>
        /// Gets a value indicating whether the button is currently clicked.
        /// </summary>
        public bool IsClicked { get; private set; } = false;

        public Button(Vector2 position, int width, int height) : base(position)
        {
            Label = new Label(position + new Vector2(width, height) / 2);
            Instantiate(Label);
            Width = width;
            Height = height;
        }
        public override void SetPivot(PivotPoint pivot)
        {
            base.SetPivot(pivot);
            Label.SetPivot(Pivot);
        }
        public override void Update()
        {
            base.Update();
            Vector2 pos = GetMousePosition();
            IsHovered = pos.X > Position.X && pos.Y > Position.Y && pos.X < Position.X + Width && pos.Y < Position.Y + Height;
            if (IsHovered && IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
            {
                IsClicked = true;
                if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
                    OnClick();

            }
            else IsClicked = false;

            if (IsHovered) OnHover();


        }
        /// <summary>
        /// Triggered when the mouse hovers over the button.
        /// </summary>
        public virtual void OnHover() { }
        /// <summary>
        /// Triggered when the button is clicked.
        /// </summary>
        public virtual void OnClick() { }

        public override void Render()
        {
            base.Render();
            Color drawColor = IsHovered ? IsClicked ? ClickColor : HoverColor : NormalColor;
            DrawRectangle((int)Position.X, (int)Position.Y, Width, Height, drawColor);
        }
    }
}
