using Raylib_cs;

namespace GUILIB.Styles.Buttons
{
    public class ToggleButtonStyle : Style
    {
        public override Color[] idleColor { set; get; } = new Color[] { new Color(175, 175, 175, 255), new Color(235, 235, 235, 255) };
        public override Color[] hoverColor { set; get; } = new Color[] { new Color(175, 175, 175, 255), new Color(235, 235, 235, 255) };
        public override Color[] pressedColor { set; get; } = new Color[] { new Color(175, 175, 175, 255), new Color(235, 235, 235, 255) };
        
        public override int outlineThickness { set; get; } = 0;
        public override float roundness { set; get; } = 0.45f;
    }
}
