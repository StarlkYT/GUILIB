using GUILIB.Styles.Texts;
using Raylib_cs;
using System;
using System.Text;
using static Raylib_cs.Raylib;

namespace GUILIB.Widgets.Texts
{
    public class TextEntryWidget : Widget
    {
        public Action<object, string> TextEntered;

        public TextEntryStyle textEntryStyle;
        public bool wrapText;
        public int lettersLimit;

        public StringBuilder text = new StringBuilder();

        public TextEntryWidget(Rectangle widgetRectangle, TextEntryStyle textEntryStyle, bool wrapText, int lettersLimit) 
            : base(widgetRectangle, textEntryStyle)
        {
            this.textEntryStyle = textEntryStyle;
            this.wrapText = wrapText;
            this.lettersLimit = lettersLimit;
        }

        public override void Update(bool isWidgetScalable)
        {
            if (IsKeyPressed(KeyboardKey.KEY_BACKSPACE) && text.Length > 0)
            {
                text.Remove(text.Length - 1, 1);
                TextEntered?.Invoke(this, "Backspace".ToString());
            }

            int unicodeChar = GetCharPressed();
            while (unicodeChar > 0)
            {
                if ((unicodeChar >= 32) && (unicodeChar <= 125) && lettersLimit > text.Length)
                {
                    text.Append((char)unicodeChar);
                    TextEntered?.Invoke(this, ((char)unicodeChar).ToString());
                }
                unicodeChar = GetCharPressed();
            }

            base.Update(isWidgetScalable);
        }

        public override void Draw()
        {
            DrawTextRec(textEntryStyle.font, text.ToString() + textEntryStyle.caret, widgetRectangle, 
                        textEntryStyle.fontSize, textEntryStyle.fontSize / 10, wrapText, textEntryStyle.idleColor[0]);
        }
    }
}
