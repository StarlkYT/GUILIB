using static Raylib_cs.Raylib;
using Raylib_cs;

namespace GUILIB.Widgets.Buttons
{
    public class ButtonWidget : Widget
    {
        public float roundness;
        public int outlineThickness;
        public string text;
        public int textSize;
        public bool wrapText;
        
        public Color textColor = new Color(0, 0, 0, 255);
        public Color outlineColor = new Color(0, 0, 0, 255);

        private Rectangle _textRectangle;

        public ButtonWidget(Rectangle widgetRectangle, Color color, bool scales, float roundness = 0.25f, 
                            int outlineThickness = 1, string text = "", int textSize = 15, bool wrapText = false) : base(widgetRectangle, color, scales)
        {
            this.roundness = roundness;
            this.outlineThickness = outlineThickness;
            this.text = text;
            this.textSize = textSize;
            this.wrapText = wrapText;
        }

        public override void Update()
        {
            _textRectangle = new Rectangle(widgetRectangle.x + outlineThickness, widgetRectangle.y + outlineThickness,
                                          widgetRectangle.width - outlineThickness, widgetRectangle.height - outlineThickness);
            base.Update();
        }

        public override void Draw()
        {
            if(scales)
            {
                DrawRectangleRoundedLines(new Rectangle((widgetRectangle.x / 100) * GetScreenWidth(), (widgetRectangle.y / 100) * GetScreenHeight(), (widgetRectangle.width / 100) * GetScreenWidth(), (widgetRectangle.height / 100) * GetScreenHeight()), roundness, 8, outlineThickness, outlineColor);
                DrawRectangleRounded(new Rectangle((widgetRectangle.x / 100) * GetScreenWidth(), (widgetRectangle.y / 100) * GetScreenHeight(), (widgetRectangle.width / 100) * GetScreenWidth(), (widgetRectangle.height / 100) * GetScreenHeight()), roundness, 8, color);
                DrawTextRec(GetFontDefault(), text, _textRectangle, textSize, textSize / 10, wrapText, textColor);
            }else
            {
                DrawRectangleRoundedLines(widgetRectangle, roundness, 8, outlineThickness, outlineColor);
                DrawRectangleRounded(widgetRectangle, roundness, 8, color);
                DrawTextRec(GetFontDefault(), text, _textRectangle, textSize, textSize / 10, wrapText, textColor);
            }
        }
    }
}
