using GUILIB.Styles.Texts;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GUILIB.Widgets.Texts
{
    public class TextWidget : Widget
    {
        public string text;
        public bool wrapText;
        public TextStyle textStyle;

        public TextWidget(Rectangle widgetRectangle, TextStyle textStyle, string text, bool wrapText) 
            : base(widgetRectangle, textStyle)
        {
            this.text = text;
            this.wrapText = wrapText;
            this.textStyle = textStyle;
        }

        public override void Draw()
        {
            DrawTextRec(textStyle.font, text, widgetRectangle, textStyle.fontSize, 
                        textStyle.fontSize / 10, wrapText, style.idleColor[0]);
        }
    }
}
