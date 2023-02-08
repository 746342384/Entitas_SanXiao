using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game.Components
{
    /// <summary>
    /// 游戲面板
    /// </summary>
    [Game]
    public class GameBoardComponent : IComponent
    {
        /// <summary>
        /// 列
        /// </summary>
        public int columns;

        /// <summary>
        /// 行
        /// </summary>
        public int rows;
    }

    /// <summary>
    /// 游戏元素
    /// </summary>
    [Game]
    public class GameBoardItem : IComponent
    {
    }

    /// <summary>
    /// 销毁组件
    /// </summary>
    [Game]
    public class DestroyComponent : IComponent
    {
    }

    [Game, Event(EventTarget.Self)]
    public class ItemIndex : IComponent
    {
        [EntityIndex] public CustomVector2 Vector2;
    }
}