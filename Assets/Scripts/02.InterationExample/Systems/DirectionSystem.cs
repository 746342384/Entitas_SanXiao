using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _02.InterationExample.Systems
{
    public class DirectionSystem : ReactiveSystem<GameEntity>
    {
        public DirectionSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InterationExampleMove);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInterationExampleMove
                   && entity.isInterationExampleMoveComplete
                   && entity.hasInterationExampleView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var view = entity.interationExampleView.viewTrans;
                var targetPos = entity.interationExampleMove.target;
                var direction = (targetPos - view.position).normalized;
                
                // var angleOffset = Quaternion.FromToRotation(view.up, direction);
                // view.rotation *= angleOffset;
                
                var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                entity.ReplaceInterationExampleDirection(angle);
            }
        }
    }
}