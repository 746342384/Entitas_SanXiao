using Entitas;
using Game.System;

namespace Game.Controller
{
    public class InputFeature : Feature
    {
        public InputFeature(Contexts contexts)
        {
            Add(new ClickSystem(contexts));
            Add(new SliderSystem(contexts));
        }

        public sealed override Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}