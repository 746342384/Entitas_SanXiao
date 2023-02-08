using System;
using System.Collections.Generic;
using Entitas;
using Game.Const;
using UnityEngine;

namespace Game.System
{
    public class SliderSystem : ReactiveSystem<InputEntity>
    {
        private Contexts _context;

        public SliderSystem(Contexts context) : base(context.input)
        {
            _context = context;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher._04GameComponentsSlide);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.has_04GameComponentsSlide;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            if (entities.Count == 1)
            {
                var inputEntity = entities.SingleEntity();
                var customVector2 = new CustomVector2(inputEntity._04GameComponentsSlide.Vector2.x,
                    inputEntity._04GameComponentsSlide.Vector2.y);
                var isCanMove = _context.game.GetEntitiesWithGameComponentsItemIndex(customVector2).SingleEntity()
                    .isGameComponentsMoveable;
                if (isCanMove)
                {
                    var nextPos = NextPos(inputEntity);
                    _context.input.Replace_04GameComponentsClick(nextPos.x, nextPos.y);
                    Debug.Log(inputEntity._04GameComponentsSlide.Direction);
                }
            }
        }

        private CustomVector2 NextPos(InputEntity entity)
        {
            var x = entity._04GameComponentsSlide.Vector2.x;
            var y = entity._04GameComponentsSlide.Vector2.y;
            switch (entity._04GameComponentsSlide.Direction)
            {
                case SlideDirection.UP:
                    y++;
                    break;
                case SlideDirection.DOWM:
                    y--;
                    break;
                case SlideDirection.LEFT:
                    x--;
                    break;
                case SlideDirection.RIGHT:
                    x++;
                    break;
            }

            x = Math.Clamp(x, 0, _context.game.gameComponentsGameBoard.columns - 1);
            y = Math.Clamp(y, 0, _context.game.gameComponentsGameBoard.rows - 1);

            return new CustomVector2(x, y);
        }
    }
}