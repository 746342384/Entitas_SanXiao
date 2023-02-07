using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace MultiReactive
{
    [Game, Input, Ui]
    public class DestroyComponent : IComponent
    {
    }

    [Game, Input, Ui]
    public class ViewComponent : IComponent
    {
        public Transform trans;
    }

    [Game, Event(EventTarget.Any)]
    public class NameComponent : IComponent
    {
        [EntityIndex] public string name;
    }
}