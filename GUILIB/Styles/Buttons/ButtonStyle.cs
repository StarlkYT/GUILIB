using Raylib_cs;

namespace GUILIB.Styles.Buttons
{
    public class ButtonStyle : Style
    {
        public override Color[] idleColor { set; get; } = new Color[] { new Color(90, 200, 225, 255), new Color(80, 180, 190, 255) };
        public override Color[] hoverColor { set; get; } = new Color[] { new Color(90, 200, 225, 200), new Color(80, 180, 190, 200) };
        public override Color[] pressedColor { set; get; } = new Color[] { new Color(80, 180, 185, 255), new Color(75, 175, 165, 255) };
    }
}
