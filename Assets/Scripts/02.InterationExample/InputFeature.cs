using _02.InterationExample.Systems;
using Entitas;

namespace _02.InterationExample
{
    public class InputFeature : Feature
    {
        public InputFeature(Contexts contexts)
        {
            Add(new MouseSystem(contexts));
            Add(new CreateSystem(contexts));
            Add(new StartMoveSystem(contexts));
        }

        public sealed override Entitas.Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}