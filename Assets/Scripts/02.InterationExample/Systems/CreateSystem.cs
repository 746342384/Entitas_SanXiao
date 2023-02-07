using System.Collections.Generic;
using System.Linq;
using Entitas;
using InterationExample;
using UnityEngine;

namespace _02.InterationExample.Systems
{
    public class CreateSystem : ReactiveSystem<InputEntity>
    {
        private GameContext _gameContext;

        public CreateSystem(Contexts context) : base(context.input)
        {
            _gameContext = context.game;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.InterationExampleMouse);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasInterationExampleMouse
                   && entity.interationExampleMouse.Mouse == MouseButton.LEFT
                   && entity.interationExampleMouse.MouseEvent == MouseButtonEvent.DOWN;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var gameEntity in entities.Select(_ => _gameContext.CreateEntity()))
            {
                gameEntity.AddInterationExampleSprite("Bullet");
                if (Camera.main == null) continue;
                var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                gameEntity.AddInterationExamplePosition(worldPos);
            }
        }
    }
}