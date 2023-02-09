using System.Collections.Generic;
using Entitas;
using Game.Const;

namespace Game.System.Game
{
    public class ExchangeBackSystem : ReactiveSystem<GameEntity>
    {
        public ExchangeBackSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentsEliminate);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameComponentsExchangeComponemt
                   && entity.hasGameComponentsEliminate
                   && !entity.gameComponentsEliminate.canEliminate
                   && entity.gameComponentsExchangeComponemt.State == ExchangeState.EXCHANGE;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.ReplaceGameComponentsExchangeComponemt(ExchangeState.EXCHANGE_BACK);
            }
        }
    }
}