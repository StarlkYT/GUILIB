using GUILIB.Styles;
using GUILIB.Styles.Buttons;
using GUILIB.Styles.Texts;
using GUILIB.Widgets.Texts;
using Raylib_cs;
using System;
using System.Numerics;

namespace GUILIB.Widgets.Buttons
{
    public class ToggleButtonWidget : Widget
    {
        public Action<bool> ToggleChange;

        public ToggleButtonStyle toggleButtonStyle;
        public Vector2 toggleButtonSize;

        private ButtonWidget toggleButton;
        private bool toggled = false;

        public ToggleButtonWidget(Rectangle widgetRectangle, ToggleButtonStyle style, ButtonStyle toggleButtonStyle, Vector2 toggleButtonSize) : base(widgetRectangle, style)
        {
            this.toggleButtonStyle = style;
            this.toggleButtonSize = toggleButtonSize;
            this.toggleButton = new ButtonWidget(new Rectangle(widgetRectangle.x, widgetRectangle.y, toggleButtonSize.X, toggleButtonSize.Y), toggleButtonStyle, 
                                                 new TextWidget(widgetRectangle, new TextStyle(), "", false));
            this.toggleButton.MousePressed += ToggleButtonPressed;
        }

        public override void Update(bool isWidgetScalable)
        {
            base.Update(isWidgetScalable);
            toggleButton.Update(isWidgetScalable);
        }

        public override void Draw()
        {
            base.Draw();
            toggleButton.Draw();
        }

        private void ToggleButtonPressed(object sender, Vector2 mousePosition)
        {
            toggled = !toggled;
            ToggleChange?.Invoke(toggled);
            if (toggled)
            {
                toggleButton.widgetRectangle = new Rectangle(widgetRectangle.width - toggleButtonSize.X, widgetRectangle.y, toggleButtonSize.X, toggleButtonSize.Y);
            }
            else
            {
                toggleButton.widgetRectangle = new Rectangle(widgetRectangle.x, widgetRectangle.y, toggleButtonSize.X, toggleButtonSize.Y);
            }
        }
    }
}
