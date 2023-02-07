using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

namespace _02.InterationExample.Systems
{
    public class MoveSystem : ReactiveSystem<GameEntity>
    {
        public MoveSystem(Contexts contexts) : base(contexts.game)
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
                entity.interationExampleView.viewTrans.DOMove(
                    new Vector2(entity.interationExampleMove.target.x, entity.interationExampleMove.target.y), 3f);
            }
        }
    }
}