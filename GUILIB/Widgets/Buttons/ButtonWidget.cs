using System;
using GUILIB.Styles.Buttons;
using GUILIB.Core;
using static Raylib_cs.Raylib;
using Raylib_cs;

namespace GUILIB.Widgets.Buttons
{
    public class ButtonWidget : Widget
    {
        public event EventHandler OnButtonPressed;
        public new event EventHandler OnMouseExited;
        public new event EventHandler OnMouseHover;

        public string text;
        public int textSize;
        public bool isToggled = false;
        public ButtonStyle buttonStyle;

        private bool _scales;
        private Color _currentBackgroundColor;
        private Color _currentOutlineColor;
        private Color _currentTextColor;
        private Rectangle _textRectangle;

        public ButtonWidget(Rectangle rectangle, ButtonStyle buttonStyle, string text, int textSize, bool scales)
        {
            widgetRectangle = rectangle;
            this.buttonStyle = buttonStyle;
            this.text = text;
            this.textSize = textSize;
            this._scales = scales;
        }

        public override void Update()
        {
            if (CheckCollisionRecs(widgetRectangle, Window.MouseRectangle))
            {
                if (IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    OnButtonPressed?.Invoke(this, EventArgs.Empty);
                    isToggled = !isToggled;
                }

                if (IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    _currentBackgroundColor = buttonStyle.backgroundPressedColor;
                    _currentOutlineColor = buttonStyle.outlinePressedColor;
                    _currentTextColor = buttonStyle.outlinePressedColor;
                }
                else
                {
                    OnMouseHover?.Invoke(this, EventArgs.Empty);
                    _currentBackgroundColor = buttonStyle.backgroundHoverColor;
                    _currentOutlineColor = buttonStyle.outlineHoverColor;
                    _currentTextColor = buttonStyle.textHoverColor;
                }
            }
            else
            {
                OnMouseExited?.Invoke(this, EventArgs.Empty);
                _currentBackgroundColor = buttonStyle.backgroundIdleColor;
                _currentOutlineColor = buttonStyle.outlineIdleColor;
                _currentTextColor = buttonStyle.textIdleColor;
            }

            switch (buttonStyle.textMargin)
            {
                case "TopLeft":
                    _textRectangle = new Rectangle(widgetRectangle.x + buttonStyle.outlineThickness, widgetRectangle.y + buttonStyle.outlineThickness,
                                                   widgetRectangle.width - buttonStyle.outlineThickness, widgetRectangle.height - buttonStyle.outlineThickness);
                    break;
            }
        }

        public override void Draw()
        {
            if(_scales) //Very buggy  & Broken!
            {
                DrawRectangleRounded(new Rectangle((widgetRectangle.x / 100) * GetScreenWidth(), (widgetRectangle.y / 100) * GetScreenHeight(), (widgetRectangle.width / 100) * GetScreenWidth(), (widgetRectangle.height / 100) * GetScreenHeight()), 
                                    buttonStyle.roundness, 8, _currentBackgroundColor);
                DrawRectangleLinesEx(new Rectangle((widgetRectangle.x / 100) * GetScreenWidth(), (widgetRectangle.y / 100) * GetScreenHeight(), (widgetRectangle.width / 100) * GetScreenWidth(), (widgetRectangle.height / 100) * GetScreenHeight()), buttonStyle.outlineThickness, _currentOutlineColor);
                DrawTextRec(GetFontDefault(), text, _textRectangle, textSize, textSize / 10, true, _currentTextColor);
            }
            else
            {
                DrawRectangleRounded(widgetRectangle, buttonStyle.roundness, 8, _currentBackgroundColor);
                DrawRectangleLinesEx(widgetRectangle, buttonStyle.outlineThickness, _currentOutlineColor);
                DrawTextRec(GetFontDefault(), text, _textRectangle, textSize, textSize / 10, true, _currentTextColor);
            }
        }
    }
}
