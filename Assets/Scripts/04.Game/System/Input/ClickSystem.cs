using System.Collections.Generic;
using _04.Game.Components;
using Entitas;
using Game.Const;
using UnityEngine;

namespace Game.System
{
    public class ClickSystem : ReactiveSystem<InputEntity>
    {
        private Contexts _context;
        private ClickComponent _lastComponent;

        public ClickSystem(Contexts context) : base(context.input)
        {
            _context = context;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher._04GameComponentsClick);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.has_04GameComponentsClick;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            var input = entities.SingleEntity();
            var click = input._04GameComponentsClick;
            var gameEntities =
                _context.game.GetEntitiesWithGameComponentsItemIndex(new CustomVector2(click.x, click.y));
            var isCanMove = false;
            if (null != gameEntities)
            {
                isCanMove = gameEntities.SingleEntity().isGameComponentsMoveable;
            }

            if (isCanMove)
            {
                if (_lastComponent == null)
                {
                    _lastComponent = new ClickComponent();
                }
                else
                {
                    if (click.x == _lastComponent.x - 1 && click.y == _lastComponent.y ||
                        click.x == _lastComponent.x + 1 && click.y == _lastComponent.y ||
                        click.y == _lastComponent.y - 1 && click.x == _lastComponent.x ||
                        click.y == _lastComponent.y + 1 && click.x == _lastComponent.x)
                    {
                        ReplaceExchange(click);
                        ReplaceExchange(_lastComponent);
                        _lastComponent = null;
                    }
                }

                if (_lastComponent != null)
                {
                    _lastComponent.x = click.x;
                    _lastComponent.y = click.y;
                }
            }
        }

        private void ReplaceExchange(ClickComponent clickComponent)
        {
            var customVector2 = new CustomVector2(clickComponent.x, clickComponent.y);
            var entities = _context.game.GetEntitiesWithGameComponentsItemIndex(customVector2);
            foreach (var gameEntity in entities)
            {
                gameEntity.ReplaceGameComponentsExchangeComponemt(ExchangeState.START);
            }
        }
    }
}