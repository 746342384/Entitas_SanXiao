using System.Collections.Generic;
using System.Linq;
using Entitas;
using Game.Const;

namespace _04.Game.System.Game
{
    public class EliminateVerticalSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;

        public EliminateVerticalSystem(Contexts context) : base(context.game)
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
                   entity.gameComponentsItemEffectState.State == ItemEffectName.ELIMINATE_VERTICAL;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var gameBoard = _context.game.gameComponentsGameBoard;
            var pos = new CustomVector2();
            GameEntity[] temp;
            foreach (var gameEntity in entities)
            {
                for (var row = 0; row < gameBoard.rows; row++)
                {
                    pos = new CustomVector2(gameEntity.gameComponentsItemIndex.Vector2.x, row);
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