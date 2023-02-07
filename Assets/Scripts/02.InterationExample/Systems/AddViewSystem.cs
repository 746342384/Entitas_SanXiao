using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace _02.InterationExample.Systems
{
    public class AddViewSystem : ReactiveSystem<GameEntity>
    {
        private readonly Transform _parent;

        public AddViewSystem(Contexts context) : base(context.game)
        {
            _parent = new GameObject("ViewParent").transform;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InterationExampleSprite);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInterationExampleSprite && !entity.hasInterationExampleView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var go = new GameObject("View");
                go.transform.SetParent(_parent);
                go.Link(entity);
                entity.AddInterationExampleView(go.transform);
                entity.isInterationExampleMoveComplete = true;
            }
        }
    }
}