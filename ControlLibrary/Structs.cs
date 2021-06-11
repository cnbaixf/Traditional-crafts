namespace ControlLibrary
{
    /// <summary>
    /// 矩形的圆角半径
    /// </summary>
    public struct CornerRadius
    {
        /// <summary>
        /// 左上角圆角半径
        /// </summary>
        public int TopLeft;

        /// <summary>
        /// 右上角圆角半径
        /// </summary>
        public int TopRight;

        /// <summary>
        /// 左下角圆角半径
        /// </summary>
        public int BottomLeft;

        /// <summary>
        /// 右下角圆角半径
        /// </summary>
        public int BottomRigth;

        /// <summary>
        /// 设置四个角为相同的圆角半径
        /// </summary>
        /// <param name="radius"></param>
        public CornerRadius(int radius) : this(radius, radius, radius, radius)
        {
        }

        /// <summary>
        /// 初始化四个角的圆角半径
        /// </summary>
        /// <param name="topLeft"></param>
        /// <param name="topRight"></param>
        /// <param name="bottomLeft"></param>
        /// <param name="bottomRight"></param>
        public CornerRadius(int topLeft, int topRight, int bottomLeft, int bottomRight)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRigth = bottomRight;
        }

    }
}
