using _04.Game.System;
using Entitas;
using Game.System;

namespace _04.Game.Controller
{
    public class GameFeature : Feature
    {
        public GameFeature(Contexts contexts)
        {
            Add(new GameBoardSystem(contexts));
            Add(new ExchangeSystem(contexts));
            Add(new MoveCompleteSystem(contexts));
            Add(new GetSameColorSystem(contexts));
        }

        public sealed override Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}