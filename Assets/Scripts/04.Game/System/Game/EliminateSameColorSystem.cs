using System.Collections.Generic;
using System.Linq;
using Entitas;
using Game.Const;

namespace _04.Game.System.Game
{
    public class EliminateSameColorSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;

        public EliminateSameColorSystem(Contexts context) : base(context.game)
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
                   entity.gameComponentsItemEffectState.State == ItemEffectName.ELIMINATE_SAME_COLOR;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var gameBoard = _context.game.gameComponentsGameBoard;
            var pos = new CustomVector2();
            GameEntity temp;
            foreach (var gameEntity in entities)
            {
                for (var column = 0; column < gameBoard.columns; column++)
                {
                    for (var row = 0; row < gameBoard.rows; row++)
                    {
                        pos = new CustomVector2(column, row);
                        temp = _context.game.GetEntitiesWithGameComponentsItemIndex(pos)
                            .FirstOrDefault(u =>
                                u.gameComponentsLoadPrefab.path == gameEntity.gameComponentsLoadPrefab.path);
                        if (temp != null)
                        {
                            temp.isGameComponentsDestroy = true;
                        }
                    }
                }
            }
        }
    }
}