using GUILIB.Styles.Buttons;
using Raylib_cs;
using System;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace GUILIB.Widgets.Buttons
{
    public class ToggleButtonWidget : Widget
    {
        /// <summary>
        /// Invoked when the user changes the toggle mode of the toggle button. The boolean is True if it was toggled.
        /// </summary>
        public Action<bool> ToggleChange;
        public ToggleButtonStyle toggleButtonStyle;
        public Vector2 toggleSize;

        private bool _toggled = false;
        private Rectangle _toggleRectangle;
        private Color[] _toggleColors = new Color[] { Color.WHITE, Color.WHITE };

        public ToggleButtonWidget(Rectangle widgetRectangle, ToggleButtonStyle style, Vector2 toggleSize)
            : base(widgetRectangle, style)
        {
            this._toggleRectangle = new Rectangle(widgetRectangle.x, widgetRectangle.y,
                                                  toggleSize.X, toggleSize.Y);
            this.toggleButtonStyle = style;
            this.toggleSize = toggleSize;
            _toggleColors = toggleButtonStyle.idleToggleButtonColor;
        }

        public override void Update(bool isWidgetScalable)
        {
            switch (MouseInteraction())
            {
                case 0: // Idle
                    _toggleColors = toggleButtonStyle.idleToggleButtonColor;
                    break;

                case 1: // Hover
                    _toggleColors = toggleButtonStyle.hoverToggleButtonColor;
                    break;

                case 2: // Down
                    _toggleColors = toggleButtonStyle.pressedToggleButtonColor;
                    break;

                case 4: // Pressed
                    _toggled = !_toggled;
                    ToggleChange?.Invoke(_toggled);

                    if (_toggled)
                    {
                        this._toggleRectangle = new Rectangle(widgetRectangle.width - toggleSize.X, widgetRectangle.y,
                                                              toggleSize.X, toggleSize.Y);
                    }
                    else
                    {
                        this._toggleRectangle = new Rectangle(widgetRectangle.x, widgetRectangle.y,
                                                              toggleSize.X, toggleSize.Y);
                    }
                    break;
            }

            base.Update(isWidgetScalable);
        }

        public override void Draw()
        {
            base.Draw();
            DrawRectangleRounded(_toggleRectangle, toggleButtonStyle.roundnessToggle, 8, _toggleColors[0]);
            DrawRectangleRoundedLines(_toggleRectangle, toggleButtonStyle.roundnessToggle, 8, 
                                      toggleButtonStyle.outlineToggleThickness, _toggleColors[1]);
        }
    }
}
