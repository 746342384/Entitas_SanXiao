using System.Collections.Generic;
using Entitas;
using Game.Const;

namespace _04.Game.System
{
    public class ExchangeSystem : ReactiveSystem<GameEntity>
    {
        public ExchangeSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentsExchangeComponemt);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameComponentsExchangeComponemt
                   && entity.gameComponentsExchangeComponemt.State is ExchangeState.START
                       or ExchangeState.EXCHANGE_BACK;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            if (entities.Count == 2)
            {
                Exchange(entities[0], entities[1]);
            }
        }

        private void Exchange(GameEntity one, GameEntity two)
        {
            var onePos = one.gameComponentsItemIndex.Vector2;
            var twoPos = two.gameComponentsItemIndex.Vector2;
            two.ReplaceGameComponentsItemIndex(onePos);
            one.ReplaceGameComponentsItemIndex(twoPos);
            SetExchangeState(one);
            SetExchangeState(two);
        }

        private void SetExchangeState(GameEntity entity)
        {
            if (entity.gameComponentsExchangeComponemt.State == ExchangeState.START)
            {
                entity.ReplaceGameComponentsExchangeComponemt(ExchangeState.EXCHANGE);
            }
            else if (entity.gameComponentsExchangeComponemt.State == ExchangeState.EXCHANGE_BACK)
            {
                entity.ReplaceGameComponentsExchangeComponemt(ExchangeState.END);
            }
        }
    }
}