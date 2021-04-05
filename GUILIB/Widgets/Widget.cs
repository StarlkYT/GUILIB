using GUILIB.Core;
using GUILIB.Styles;
using Raylib_cs;
using System;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace GUILIB.Widgets
{
    public abstract class Widget
    {
        #region Delegates
        public Action<object> MouseIn;
        public virtual void InvokeMouseIn(object sender) => MouseIn?.Invoke(sender);

        public Action<object> MouseOut;
        public virtual void InvokeMouseOut(object sender) => MouseOut?.Invoke(sender);

        /// <summary>
        /// Invoked when the mouse keeps pressing on the widget.
        /// </summary>
        public Action<object, Vector2> MouseDown;
        public virtual void InvokeMouseDown(object sender, Vector2 mousePosition) => MouseDown?.Invoke(sender, mousePosition);

        /// <summary>
        /// Invoked when the mouse just presses on the widget.
        /// </summary>
        public Action<object, Vector2> MousePressed;
        public virtual void InvokeMousePressed(object sender, Vector2 mousePosition) => MousePressed?.Invoke(sender, mousePosition);
        #endregion

        public Rectangle widgetRectangle;

        // Change the rectangle's look according to the style.
        protected Color[] _colors;
        protected Style style;
        
        private bool _isMouseOut = true;

        public Widget(Rectangle widgetRectangle, Style style)
        {
            this.widgetRectangle = widgetRectangle;
            this.style = style;
        }

        public virtual void Update(bool isWidgetScalable)
        {
            HandleStates();

            if (isWidgetScalable)
            {

            }
            else
            {

            }
        }

        public virtual void Draw()
        {
            DrawRectangleRounded(widgetRectangle, style.roundness, 8, _colors[0]);
            DrawRectangleRoundedLines(widgetRectangle, style.roundness, 8, style.outlineThickness, _colors[1]);
        }

        private void HandleStates()
        {
            switch (MouseInteraction())
            {
                case 0: // Idle
                    _colors = style.idleColor;
                    if (_isMouseOut == false)
                    {
                        _isMouseOut = true;
                        MouseOut?.Invoke(this);
                    }
                    break;

                case 1: // Hover
                    _colors = style.hoverColor;
                    MouseIn?.Invoke(this);
                    _isMouseOut = _isMouseOut ? false : _isMouseOut;
                    break;

                case 2: // Down
                    _colors = style.pressedColor;
                    MouseDown?.Invoke(this, Window.MousePosition);
                    break;

                case 3: // Pressed
                    MousePressed?.Invoke(this, Window.MousePosition);
                    break;
            }
        }

        protected int MouseInteraction()
        {
            if (!_isMouseOut && IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON))
            {
                return 4;
            }
            else
            {
                if (CheckCollisionPointRec(Window.MousePosition, widgetRectangle))
                {
                    if (IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                    {
                        return 3;
                    }
                    else if (IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
