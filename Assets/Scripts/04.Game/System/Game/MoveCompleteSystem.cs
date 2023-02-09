using System.Collections.Generic;
using Entitas;

namespace _04.Game.System
{
    public class MoveCompleteSystem : ReactiveSystem<GameEntity>
    {
        public MoveCompleteSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentsExchangeComplete);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isGameComponentsExchangeComplete;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.isGameComponentsExchangeComplete = false;
                gameEntity.isGameComponentsGetSameColor = true;
            }
        }
    }
}