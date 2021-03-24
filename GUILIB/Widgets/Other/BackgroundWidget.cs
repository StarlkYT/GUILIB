using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GUILIB.Widgets.Other
{
    public class BackgroundWidget : Widget
    {
        public float roundness;
        public int outlineThickness;

        public Color outlineColor = new Color(0, 0, 0, 255);

        public BackgroundWidget(Rectangle widgetRectangle, Color color, bool scales, float roundness = 0.25f, int outlineThickness = 1) : base(widgetRectangle, color, scales)
        {
            this.roundness = roundness;
            this.outlineThickness = outlineThickness;
        }

        public override void Draw()
        {
            if(scales)
            {
                DrawRectangleRoundedLines(new Rectangle((widgetRectangle.x / 100) * GetScreenWidth(), (widgetRectangle.y / 100) * GetScreenHeight(), (widgetRectangle.width / 100) * GetScreenWidth(), (widgetRectangle.height / 100) * GetScreenHeight()), roundness, 8, outlineThickness + 1, outlineColor);
                DrawRectangleRounded(new Rectangle((widgetRectangle.x / 100) * GetScreenWidth(), (widgetRectangle.y / 100) * GetScreenHeight(), (widgetRectangle.width / 100) * GetScreenWidth(), (widgetRectangle.height / 100) * GetScreenHeight()), roundness, 8, color);
            }else 
            {
                DrawRectangleRoundedLines(widgetRectangle, roundness, 8, outlineThickness + 1, outlineColor);
                DrawRectangleRounded(widgetRectangle, roundness, 8, color);
            }
        }
    }
}

