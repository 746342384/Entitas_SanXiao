using Entitas;
using UnityEngine;

namespace InterationExample
{
    [Game]
    public class PositionComponent : IComponent
    {
        public Vector2 position;
    }
}