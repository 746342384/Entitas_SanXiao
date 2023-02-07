using _03.MultiReactive.Systems;
using Entitas;

namespace _03.MultiReactive
{
    public class MultiReactiveFeature : Feature
    {
        public MultiReactiveFeature(Contexts contexts)
        {
            Add(new MultiDestroySystem(contexts));
            Add(new MultiViewSystem(contexts));
            Add(new NameSystem(contexts));
        }

        public sealed override Entitas.Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}