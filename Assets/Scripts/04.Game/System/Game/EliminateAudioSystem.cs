using System;
using System.Collections.Generic;
using Entitas;
using Game.Const;

namespace _04.Game.System.Game
{
    public class EliminateAudioSystem : ReactiveSystem<GameEntity>
    {
        public EliminateAudioSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentsEliminate);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameComponentsItemEffectState &&
                   entity.gameComponentsEliminate.canEliminate;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var name = "";
                switch (gameEntity.gameComponentsItemEffectState.State)
                {
                    case ItemEffectName.NONE:
                        name = AudioName.NormalBomb.ToString();
                        break;
                    case ItemEffectName.ELIMINATE_SAME_COLOR:
                    case ItemEffectName.ELIMINATE_HORIZONTAL:
                    case ItemEffectName.ELIMINATE_VERTICAL:
                    case ItemEffectName.EXPLODE:
                        name = AudioName.SpecialBomb.ToString();
                        break;
                }

                gameEntity.ReplaceGameComponentsAudio(name);
            }
        }
    }

    public class ExchangeAudioSystem : ReactiveSystem<GameEntity>
    {
        public ExchangeAudioSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentsExchangeComponemt);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameComponentsExchangeComponemt &&
                   entity.gameComponentsExchangeComponemt.State is ExchangeState.EXCHANGE
                       or ExchangeState.EXCHANGE_BACK;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.ReplaceGameComponentsAudio(AudioName.Switch.ToString());
            }
        }
    }

    public class FallAudioSystem : ReactiveSystem<GameEntity>
    {
        public FallAudioSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentsItemIndex);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameComponentsFall && entity.gameComponentsFall.State == FallState.FALL;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.ReplaceGameComponentsAudio(AudioName.Fall.ToString());
            }
        }
    }
}