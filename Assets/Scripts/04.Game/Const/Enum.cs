namespace Game.Const
{
    public enum SlideDirection
    {
        UP,
        DOWM,
        LEFT,
        RIGHT
    }

    /// <summary>
    /// 交换状态
    /// </summary>
    public enum ExchangeState
    {
        NONE,
        START,
        EXCHANGE,
        EXCHANGE_BACK,
        END
    }


    /// <summary>
    /// 特殊元素效果名称
    /// </summary>
    public enum ItemEffectName
    {
        NONE,

        /// <summary>
        /// 消除所有相同颜色的元素（五个及五个以上的元素连成一条直线）
        /// </summary>
        ELIMINATE_SAME_COLOR,

        /// <summary>
        /// 消除行（四个元素连成一条横线）
        /// </summary>
        ELIMINATE_HORIZONTAL,

        /// <summary>
        /// 消除列（四个元素连成一条竖线）
        /// </summary>
        ELIMINATE_VERTICAL,

        /// <summary>
        /// 爆炸消除以此元素为中心的九宫格范围（横竖都满足三个及三个元素以上）
        /// </summary>
        EXPLODE
    }

    public enum AudioName
    {
        Bg,
        Fall,
        NormalBomb,
        SpecialBomb,
        Switch,
    }

    public enum FallState
    {
        STEADY,
        FALL
    }
}