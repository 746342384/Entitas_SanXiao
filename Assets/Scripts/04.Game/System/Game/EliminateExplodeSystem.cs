using System.Collections.Generic;
using System.Linq;
using Entitas;
using Game.Const;

namespace _04.Game.System.Game
{
    public class EliminateExplodeSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;

        public EliminateExplodeSystem(Contexts context) : base(context.game)
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
                   entity.gameComponentsItemEffectState.State == ItemEffectName.EXPLODE;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var pos in entities.Select(gameEntity => gameEntity.gameComponentsItemIndex.Vector2))
            {
                for (var x = pos.x - 1; x < pos.x + 1; x++)
                {
                    for (var y = pos.y - 1; y < pos.y + 1; y++)
                    {
                        if (x < 0 || y < 0)
                        {
                            continue;
                        }

                        var temp = _context.game.GetEntitiesWithGameComponentsItemIndex(new CustomVector2(x, y))
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
}