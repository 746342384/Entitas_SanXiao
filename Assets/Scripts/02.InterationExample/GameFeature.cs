using _02.InterationExample.Systems;
using Entitas;

namespace _02.InterationExample
{
    public class GameFeature : Feature
    {
        public GameFeature(Contexts contexts)
        {
            Add(new AddViewSystem(contexts));
            Add(new RenderSpriteSystem(contexts));
            Add(new PositionSystem(contexts));
            Add(new MoveSystem(contexts));
            Add(new DirectionSystem(contexts));
            Add(new ChangeRotationSystem(contexts));
        }

        public sealed override Entitas.Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}