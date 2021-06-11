using System.Drawing;

namespace ControlLibrary
{
    internal class LinearColor
    {
        public Color First;
        public Color Second;

        public LinearColor(Color color1, Color color2)
        {
            First = color1;
            Second = color2;
        }

    }

    /// <summary>
    /// 渐变色
    /// </summary>
    internal struct GradientColor
    {
        public Color First;
        public Color Second;
        /// <summary>
        /// 色彩渲染系数（0到1的浮点数值）
        /// </summary>
        public float[] Factors;
        /// <summary>
        /// 色彩渲染系数（0到1的浮点数值）
        /// </summary>
        public float[] Positions;

        public GradientColor(Color color1, Color color2, float[] factors, float[] positions)
        {
            First = color1;
            Second = color2;
            Factors = factors == null ? new float[] { } : factors;
            Positions = positions == null ? new float[] { } : positions;
        }
    }

}
