using System.Collections.Generic;
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
                for (var row = 0; row < gameBoard.rows; row++)
                {
                    
                }
            }
        }
    }
}