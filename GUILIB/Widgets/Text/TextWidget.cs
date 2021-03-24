using static Raylib_cs.Raylib;
using Raylib_cs;

namespace GUILIB.Widgets.Text
{
    public class TextWidget : Widget
    {
        public string text;
        public int textSize;
        public bool wrapText;

        public TextWidget(Rectangle widgetRectangle, Color color, bool scales, string text, int textSize, bool wrapText) : base(widgetRectangle, color, scales)
        {
            this.text = text;
            this.textSize = textSize;
            this.wrapText = wrapText;
        }

        public override void Draw()
        {
            DrawTextRec(GetFontDefault(), text, widgetRectangle, textSize, textSize / 10, wrapText, color);
        }
    }
}
