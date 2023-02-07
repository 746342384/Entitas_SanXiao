using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _03.MultiReactive.Systems
{
    public class NameSystem : ReactiveSystem<GameEntity>
    {
        public NameSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.MultiReactiveName);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasMultiReactiveName;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            //var entitiesWithMultiReactiveName = Contexts.sharedInstance.game.GetEntitiesWithMultiReactiveName("Name");
            // foreach (var gameEntity in entitiesWithMultiReactiveName)
            // {
            //     Debug.Log(gameEntity.multiReactiveName);
            // }
        }
    }
}