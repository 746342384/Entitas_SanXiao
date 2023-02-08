using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Const;

namespace _04.Game.Components
{
    [Input, Unique]
    public class ClickComponent : IComponent
    {
        public int x;
        public int y;
    }

    [Input, Unique]
    public class SlideComponent : IComponent
    {
        public CustomVector2 Vector2;
        public SlideDirection Direction;
    }
}