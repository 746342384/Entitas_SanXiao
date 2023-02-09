using System.Collections.Generic;
using System.Linq;
using _04.Game.Service;
using Entitas;

namespace Game.System.Game
{
    public class FallSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;

        public FallSystem(Contexts context) : base(context.game)
        {
            _context = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentsGameBoardItem.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            return !entity.isGameComponentsGameBoardItem;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var gameBoard = _context.game.gameComponentsGameBoard;
            for (var column = 0; column < gameBoard.columns; column++)
            {
                for (var row = 1; row < gameBoard.rows; row++)
                {
                    var pos = new CustomVector2(column, row);
                    var entity = _context.game.GetEntitiesWithGameComponentsItemIndex(pos)
                        .Where(e => e.isGameComponentsMoveable).ToArray();
                    for (var i = 0; i < entity.Length; i++)
                    {
                        MoveDown(entity[i]);
                    }
                }
            }
        }

        private void MoveDown(GameEntity entity)
        {
            var vector2 = entity.gameComponentsItemIndex.Vector2;
            var nextEmptyRow = GetEmptyItemService.Instance.GetNextEmptyRow(vector2);

            if (nextEmptyRow < vector2.y)
            {
                var customVector2 = new CustomVector2(vector2.x, nextEmptyRow);
                entity.ReplaceGameComponentsItemIndex(customVector2);
            }
        }
    }
}