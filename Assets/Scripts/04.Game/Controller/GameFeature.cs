using _04.Game.System;
using _04.Game.System.Game;
using Entitas;
using Game.System;
using Game.System.Game;

namespace Game.Controller
{
    public class GameFeature : Feature
    {
        public GameFeature(Contexts contexts)
        {
            Add(new GameBoardSystem(contexts));
            Add(new ExchangeSystem(contexts));
            Add(new MoveCompleteSystem(contexts));
            Add(new GetSameColorSystem(contexts));
            Add(new JudgeSameColorSystem(contexts));
            Add(new EliminateSystem(contexts));
            Add(new ExchangeBackSystem(contexts));
            Add(new FallSystem(contexts));
            Add(new DestroySystem(contexts));
            Add(new FillSystem(contexts));
        }

        public sealed override Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}