using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GUILIB.Styles.Texts
{
    public class TextStyle : Style
    {
        public override Color[] idleColor { set; get; } = new Color[] { new Color(100, 100, 100, 255), new Color(235, 235, 235, 255) };
        public override Color[] hoverColor { set; get; } = new Color[] { new Color(100, 100, 100, 255), new Color(235, 235, 235, 255) };
        public override Color[] pressedColor { set; get; } = new Color[] { new Color(100, 100, 100, 255), new Color(235, 235, 235, 255) };
        
        public Font font { set; get; } = GetFontDefault();
        public int fontSize { set; get; } = 20;
    }
}
