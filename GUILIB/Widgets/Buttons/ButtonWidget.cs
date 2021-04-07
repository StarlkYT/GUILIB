using GUILIB.Styles.Buttons;
using GUILIB.Styles.Texts;
using GUILIB.Widgets.Texts;
using Raylib_cs;
using System.Numerics;

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

        public ButtonWidget(Rectangle widgetRectangle, ButtonStyle buttonStyle)
            : base(widgetRectangle, buttonStyle)
        {
            textWidget = new TextWidget(new Rectangle(), new TextStyle(), "", false);
        }

        public override void Update(bool isWidgetScalable)
        {
            // Centering text
            Vector2 textMeasure = Raylib.MeasureTextEx(textWidget.textStyle.font, textWidget.text, textWidget.textStyle.fontSize, textWidget.textStyle.fontSize / 10);
            textWidget.widgetRectangle.x = widgetRectangle.x - textMeasure.X /2 + widgetRectangle.width / 2;
            textWidget.widgetRectangle.y = widgetRectangle.y + textMeasure.Y;

            base.Update(isWidgetScalable);
        }

        public override void Draw()
        {
            base.Draw();
            textWidget.Draw();
        }
    }
}
