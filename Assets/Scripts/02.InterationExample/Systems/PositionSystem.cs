using System.Collections.Generic;
using Entitas;

namespace _02.InterationExample.Systems
{
    public class PositionSystem : ReactiveSystem<GameEntity>
    {
        public PositionSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InterationExamplePosition);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInterationExamplePosition && entity.hasInterationExampleView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.interationExampleView.viewTrans.position = entity.interationExamplePosition.position;
            }
        }
    }
}