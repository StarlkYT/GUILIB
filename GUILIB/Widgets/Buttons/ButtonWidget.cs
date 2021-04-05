using GUILIB.Styles.Buttons;
using GUILIB.Widgets.Texts;
using Raylib_cs;

namespace GUILIB.Widgets.Buttons
{
    public class ButtonWidget : Widget
    {
        public TextWidget textWidget;

        public ButtonWidget(Rectangle widgetRectangle, ButtonStyle buttonStyle, TextWidget textWidget) 
            : base(widgetRectangle, buttonStyle)
        {
            this.textWidget = textWidget;
        }

        public override void Draw()
        {
            base.Draw();
            textWidget.Draw();
        }
    }
}
