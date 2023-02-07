using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace InterationExample
{
    [Input, Unique]
    public class MouseComponent : IComponent
    {
        public MouseButton Mouse;
        public MouseButtonEvent MouseEvent;
    }
}