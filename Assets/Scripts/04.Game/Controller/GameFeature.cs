using _04.Game.System;
using Entitas;

namespace _04.Game.Controller
{
    public class GameFeature : Feature
    {
        public GameFeature(Contexts contexts)
        {
            Add(new GameBoardSystem(contexts));
        }

        public sealed override Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}