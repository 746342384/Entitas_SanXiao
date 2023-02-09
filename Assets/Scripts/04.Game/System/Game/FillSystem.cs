using System.Collections.Generic;
using _04.Game.Service;
using Entitas;

namespace _04.Game.System.Game
{
    public class FillSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;

        public FillSystem(Contexts context) : base(context.game)
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
                var pos = new CustomVector2(column, gameBoard.rows + 1);
                var rowPosMin = GetEmptyItemService.Instance.GetNextEmptyRow(pos);
                for (var row = rowPosMin; row < gameBoard.rows; row++)
                {
                    CreateService.Instance.CreateBall(new CustomVector2(column, row));
                }
            }
        }
    }
}