using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game.Components
{
    /// <summary>
    /// 游戲面板
    /// </summary>
    [Game, Unique]
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
    [Game, Event(EventTarget.Self)]
    public class DestroyComponent : IComponent
    {
    }

    [Game, Event(EventTarget.Self, EventType.Added, 1)]
    public class ItemIndexComponent : IComponent
    {
        [EntityIndex] public CustomVector2 Vector2;
    }

    [Game, Event(EventTarget.Any)]
    public class LoadPrefabComponent : IComponent
    {
        public string path;
    }

    /// <summary>
    /// 元素是否可以移动标签
    /// </summary>
    [Game]
    public class MoveableComponent : IComponent
    {
    }
}