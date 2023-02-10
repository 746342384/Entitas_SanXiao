using System.Collections.Generic;
using Entitas;
using Game.Const;

namespace Game.System.Game
{
    public class ChangeItemSpriteSystem : ReactiveSystem<GameEntity>
    {
        public ChangeItemSpriteSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentsItemEffectState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameComponentsItemEffectState &&
                   entity.gameComponentsItemEffectState.State != ItemEffectName.NONE;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var path = gameEntity.gameComponentsLoadPrefab.path.Split("/")[1];
                switch (gameEntity.gameComponentsItemEffectState.State)
                {
                    case ItemEffectName.ELIMINATE_SAME_COLOR:
                        path += ResPath.AllPostfix;
                        break;
                    case ItemEffectName.ELIMINATE_HORIZONTAL:
                        path += ResPath.HorizontalPostfix;
                        break;
                    case ItemEffectName.ELIMINATE_VERTICAL:
                        path += ResPath.VerticalPostfix;
                        break;
                    case ItemEffectName.EXPLODE:
                        path += ResPath.ExplodePostfix;
                        break;
                }
                gameEntity.ReplaceGameComponentsLoadSprite(path);
            }
        }
    }
}