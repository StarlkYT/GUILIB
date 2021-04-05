using Raylib_cs;

namespace GUILIB.Styles
{
    public class Style
    {
        public virtual Color[] idleColor { set; get; } = new Color[] { new Color(), new Color() };
        public virtual Color[] hoverColor { set; get; } = new Color[] { new Color(), new Color() };
        public virtual Color[] pressedColor { set; get; } = new Color[] { new Color(), new Color() };

        public virtual int outlineThickness { set; get; } = 0;
        public virtual float roundness { set; get; } = 0.5f;
    }
}
