using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ControlLibrary
{
    internal class LinearColor
    {
        public Color First;
        public Color Second;

        public LinearColor(Color color1, Color color2)
        {
            this.First = color1;
            this.Second = color2;
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
            this.First = color1;
            this.Second = color2;
            this.Factors = factors == null ? new float[] { } : factors;
            this.Positions = positions == null ? new float[] { } : positions;
        }
    }

}
