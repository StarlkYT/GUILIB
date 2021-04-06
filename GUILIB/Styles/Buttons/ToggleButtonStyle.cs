using Raylib_cs;

namespace GUILIB.Styles.Buttons
{
    public class ToggleButtonStyle : Style
    {
        public override Color[] idleColor { set; get; } = new Color[] { new Color(175, 175, 175, 255), new Color(235, 235, 235, 255) };
        public override Color[] hoverColor { set; get; } = new Color[] { new Color(175, 175, 175, 255), new Color(235, 235, 235, 255) };
        public override Color[] pressedColor { set; get; } = new Color[] { new Color(175, 175, 175, 255), new Color(235, 235, 235, 255) };
        
        public override int outlineThickness { set; get; } = 0;
        public override float roundness { set; get; } = 0.25f;

        public Color[] idleToggleButtonColor { set; get; } = new Color[] { new Color(200, 250, 200, 255), new Color(200, 250, 200, 255) };
        public Color[] hoverToggleButtonColor { set; get; } = new Color[] { new Color(255, 255, 200, 255), new Color(235, 235, 235, 180) };
        public Color[] pressedToggleButtonColor { set; get; } = new Color[] { new Color(200, 200, 200, 50), new Color(235, 235, 235, 25) };
        
        public int outlineToggleThickness { set; get; } = 0;
        public float roundnessToggle { set; get; } = 0.25f;
    }
}
