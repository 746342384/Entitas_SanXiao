using System.Collections.Generic;
using Entitas;
using InterationExample;
using UnityEngine;

namespace _02.InterationExample.Systems
{
    public class StartMoveSystem : ReactiveSystem<InputEntity>
    {
        private GameContext _gameContext;

        public StartMoveSystem(Contexts context) : base(context.input)
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
                   && entity.interationExampleMouse.Mouse == MouseButton.RIGHT
                   && entity.interationExampleMouse.MouseEvent == MouseButtonEvent.DOWN;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (Camera.main == null) continue;
                var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var gameEntities = _gameContext.GetGroup(GameMatcher.InterationExampleView);
                foreach (var gameEntity in gameEntities)
                {
                    gameEntity.ReplaceInterationExampleMove(worldPos);
                }
            }
        }
    }
}