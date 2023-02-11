using System.Collections.Generic;
using System.Linq;
using Entitas;
using Game.Const;

namespace _04.Game.System.Game
{
    public class EliminateHorizontalSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;

        public EliminateHorizontalSystem(Contexts context) : base(context.game)
        {
            _context = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentsDestroy);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameComponentsItemEffectState &&
                   entity.gameComponentsItemEffectState.State == ItemEffectName.ELIMINATE_HORIZONTAL;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var gameBoard = _context.game.gameComponentsGameBoard;
            var pos = new CustomVector2();
            GameEntity[] temp;
            foreach (var gameEntity in entities)
            {
                for (var column = 0; column < gameBoard.columns; column++)
                {
                    pos = new CustomVector2(column, gameEntity.gameComponentsItemIndex.Vector2.y);
                    temp = _context.game.GetEntitiesWithGameComponentsItemIndex(pos)
                        .ToArray();
                    if (temp.Length == 1)
                    {
                        temp.Single().isGameComponentsDestroy = true;
                    }
                }
            }
        }
    }
}