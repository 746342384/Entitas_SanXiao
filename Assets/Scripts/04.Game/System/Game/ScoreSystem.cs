using System.Collections.Generic;
using Entitas;

namespace _04.Game.System.Game
{
    public class ScoreSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private Contexts _context;

        public ScoreSystem(Contexts context) : base(context.game)
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
            var score = _context.game.gameComponentsScroe.score;
            _context.game.ReplaceGameComponentsScroe(score + entities.Count);
        }

        public void Initialize()
        {
            _context.game.ReplaceGameComponentsScroe(0);
        }
    }
}