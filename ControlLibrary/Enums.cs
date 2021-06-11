namespace ControlLibrary
{
    #region EnumControlState

    /// <summary>
    /// 控件的基本状态
    /// </summary>
    public enum EnumControlState
    {
        None,

        /// <summary>
        /// 默认状态
        /// </summary>
        Default,

        /// <summary>
        /// 高亮状态（鼠标悬浮）
        /// </summary>
        HeightLight,

        /// <summary>
        /// 焦点（鼠标按下、已选择、输入状态等）
        /// </summary>
        Focused,
    }

    #endregion

    //#region EnumButtonlShape
    ///// <summary>
    ///// 按钮的形状
    ///// </summary>
    //public enum EnumButtonlShape
    //{
    //    /// <summary>
    //    /// 矩形
    //    /// </summary>
    //    Rectangle,
    //    /// <summary>
    //    /// 圆角矩形
    //    /// </summary>
    //    RoundRectangle,
    //    /// <summary>
    //    /// 三角形
    //    /// </summary>
    //    Triangle,
    //    /// <summary>
    //    /// 椭圆
    //    /// </summary>
    //    Ellipse
    //}
    //#endregion

    #region
    /// <summary>
    /// 三角形按钮的朝向
    /// </summary>
    public enum EnumButtonDirection
    {
        /// <summary>
        /// 向左
        /// </summary>
        Left,
        /// <summary>
        /// 向右
        /// </summary>
        Right,
        /// <summary>
        /// 向上
        /// </summary>
        Top,
        /// <summary>
        /// 向下
        /// </summary>
        Bottom
    }
    #endregion



    #region EnumMessageBox

    /// <summary>
    /// EnumMessageBox的信息类型
    /// </summary>
    public enum EnumMessageBox
    {
        /// <summary>
        /// 信息
        /// </summary>
        Info,

        /// <summary>
        /// 错误
        /// </summary>
        Error,

        /// <summary>
        /// 询问
        /// </summary>
        Question,

        /// <summary>
        /// 警告
        /// </summary>
        Warning,
    }

    #endregion

    #region EnumTabStyle

    /// <summary>
    /// Tabcontrol的边框样式
    /// </summary>
    public enum EnumTabStyle
    {
        Default,

        None,
    }

    #endregion

    #region EnumPageSize

    /// <summary>
    /// 分页大小
    /// </summary>
    public enum EnumPageSize
    {
        Size_10 = 10,

        Size_20 = 20,

        Size_50 = 50,

        Size_80 = 80,

        Size_150 = 150,

        Size_250 = 250,
    }

    #endregion








}
