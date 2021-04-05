using Raylib_cs;

namespace GUILIB.Styles.Panels
{
    public class PanelStyle : Style
    {
        public override Color[] idleColor { set; get; } = new Color[] { new Color(245, 245, 245, 255), new Color(235, 235, 235, 255) };
        public override Color[] hoverColor { set; get; } = new Color[] { new Color(245, 245, 245, 255), new Color(235, 235, 235, 255) };
        public override Color[] pressedColor { set; get; } = new Color[] { new Color(245, 245, 245, 255), new Color(235, 235, 235, 255) };

        public override float roundness { set; get; } = 0.15f;
    }
}
