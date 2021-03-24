using System;
using GUILIB.Core;
using static Raylib_cs.Raylib;
using Raylib_cs;

namespace GUILIB.Widgets
{
    public class ToggleButtonWidget : Widget
    {
        /// <summary>
        ///     Invoked when the toggle button is pressed.
        /// </summary>
        public event EventHandler OnButtonToggled;

        public float roundness;
        public float buttonRoundness;
        public int outlineThickness;
        public int outlineButtonThickness;
        public bool isToggled = false;

        public Color buttonColor = new Color(0, 0, 0, 255);
        public Color outlineColor = new Color(0, 0, 0, 255);
        public Color outlineButtonColor = new Color(0, 0, 0, 255);
        public Rectangle buttonRectangle;
        public Rectangle ede; //

        public ToggleButtonWidget(Rectangle widgetRectangle, Color color, bool scales, float roundness = 0.25f, int outlineThickness = 1) : base(widgetRectangle, color, scales)
        {
            this.roundness = roundness;
            this.buttonRoundness = roundness;
            this.outlineThickness = outlineThickness;
            this.outlineButtonThickness = outlineThickness;
            this.buttonRectangle = new Rectangle(widgetRectangle.x, widgetRectangle.y,
                                                 widgetRectangle.width / 3, widgetRectangle.height);
        }

        public override void Update()
        {
            if (CheckCollisionRecs(buttonRectangle, Window.MouseRectangle))
            {
                if (IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    OnButtonToggled?.Invoke(this, EventArgs.Empty);
                    if (isToggled)
                    {
                        buttonRectangle = new Rectangle(widgetRectangle.x, widgetRectangle.y,
                                                        widgetRectangle.width / 3, widgetRectangle.height);
                    }
                    else
                    {
                        buttonRectangle = new Rectangle(widgetRectangle.x + widgetRectangle.width - buttonRectangle.width, widgetRectangle.y,
                                                        widgetRectangle.width / 3, widgetRectangle.height);
                    }
                    isToggled = !isToggled;
                }
            }

        }

        public override void Draw()
        {
            DrawRectangleRoundedLines(widgetRectangle, roundness, 8, outlineThickness + 1, outlineColor);
            DrawRectangleRounded(widgetRectangle, roundness, 8, color);
        
            DrawRectangleRoundedLines(buttonRectangle, buttonRoundness, 8, outlineButtonThickness + 1, outlineButtonColor);
            DrawRectangleRounded(buttonRectangle, buttonRoundness, 8, buttonColor);
        }
    }
}