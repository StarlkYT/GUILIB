using System;
using Raylib_cs;
using static Raylib_cs.Raylib;
using GUILIB.Core;

namespace GUILIB.Widgets
{
    public abstract class Widget
    {
        #region Events
        /// <summary>
        ///     Invoked when the mouse clicks or keeps clicking on the button.
        /// </summary>
        public event EventHandler OnMousePress;
        protected void MousePressInvoke(object sender, EventArgs eventArgs) => OnMousePress?.Invoke(sender, eventArgs);

        /// <summary>
        ///     Invoked when the mouse enters the widget area.
        /// </summary>
        public event EventHandler OnMouseInside;
        protected void MouseInsideInvoke(object sender, EventArgs eventArgs) => OnMouseInside?.Invoke(sender, eventArgs);

        /// <summary>
        ///     Invoked every single second if the mosue is outside the widget area.
        /// </summary>
        public event EventHandler OnMouseOutside;
        protected void MouseOutsideInvoke(object sender, EventArgs eventArgs) => OnMouseOutside?.Invoke(sender, eventArgs);
        #endregion

        public Rectangle widgetRectangle;
        public Color color;
        public bool scales;

        public Widget(Rectangle widgetRectangle, Color color, bool scales)
        {
            this.widgetRectangle = widgetRectangle;
            this.color = color;
            this.scales = scales;
        }

        /// <summary>
        ///     0: pressed, 1: inside, 2: outside.
        /// </summary>
        public int MouseInteraction()
        {
            if (CheckCollisionRecs(widgetRectangle, Window.MouseRectangle))
            {
                if (IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 2;
            }
        }

        public virtual void Update()
        {
            switch (MouseInteraction())
            {
                case 0:
                    MousePressInvoke(this, EventArgs.Empty);
                    break;
                case 1:
                    MouseInsideInvoke(this, EventArgs.Empty);
                    break;
                case 2:
                    MouseOutsideInvoke(this, EventArgs.Empty);
                    break;
            }
        }

        public virtual void Draw()
        {
            DrawRectangleRec(widgetRectangle, color);
        }

        // To do: Create a method for drawing rectangle outline.
    }
}
