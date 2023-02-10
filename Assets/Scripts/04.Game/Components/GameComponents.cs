using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Const;

namespace Game.Components
{
    /// <summary>
    /// 游戲面板
    /// </summary>
    [Game, Unique]
    public class GameBoardComponent : IComponent
    {
        public int columns;
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

    [Game]
    public class ExchangeComponemt : IComponent
    {
        public ExchangeState State;
    }

    [Game]
    public class ExchangeComplete : IComponent
    {
    }

    [Game]
    public class GetSameColor : IComponent
    {
    }

    [Game]
    public class DetectionSameItem : IComponent
    {
        public List<IEntity> UpEntities;
        public List<IEntity> DownEntities;
        public List<IEntity> LeftEntities;
        public List<IEntity> RightEntities;
    }

    [Game]
    public class JudgeFormation : IComponent
    {
    }

    /// <summary>
    /// 标记是否能消除元素
    /// </summary>
    [Game]
    public class Eliminate : IComponent
    {
        public bool canEliminate;
    }

    [Game]
    public class ItemEffectState : IComponent
    {
        public ItemEffectName State;
    }

    [Game, Event(EventTarget.Self)]
    public class LoadSprite : IComponent
    {
        public string name;
    }
}