using System;
using GUILIB.Core;
using static Raylib_cs.Raylib;
using Raylib_cs;

namespace GUILIB.Widgets.Other
{
    public class BackgroundWidget : Widget
    {
        public Color backgroundColour;
        public float roundness;

        private bool _scales;
        private int width;
        private int height;

        public BackgroundWidget(Rectangle rectangle, Color background, float roundness, bool scales)
        {
            widgetRectangle = rectangle;
            this.backgroundColour = background;
            this.roundness = roundness;
            this._scales = scales;
        }

        public override void Draw()
        {
            if(_scales)
            {
                DrawRectangleRounded(new Rectangle((widgetRectangle.x / 100) * GetScreenWidth(), (widgetRectangle.y / 100) * GetScreenHeight(), (widgetRectangle.width / 100) * GetScreenWidth(), (widgetRectangle.height / 100) * GetScreenHeight()),roundness, 8, backgroundColour);
            }
            else
            {
                DrawRectangleRounded(widgetRectangle,roundness, 8, backgroundColour);
            }

        } //MAKE ONE WHICH SCALES WITH THE SCREEN!
        //int GetScreenWidth(void);                                           // Get current screen width
        //int GetScreenHeight(void);                                              // Get current screen height
    }
}
