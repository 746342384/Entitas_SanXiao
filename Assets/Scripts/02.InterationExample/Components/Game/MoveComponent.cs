using Entitas;
using UnityEngine;

namespace InterationExample
{
    [Game]
    public class MoveComponent : IComponent
    {
        public Vector3 target;
    }
}