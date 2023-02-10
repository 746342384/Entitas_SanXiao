using System.Collections.Generic;
using Entitas;

namespace Game.System.Game
{
    public class JudgeSameColorSystem : ReactiveSystem<GameEntity>
    {
        public JudgeSameColorSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentsDetectionSameItem);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameComponentsDetectionSameItem;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var isMeet = IsMeetCondition(gameEntity);
                if (isMeet)
                {
                    gameEntity.isGameComponentsJudgeFormation = true;
                }
                else
                {
                    gameEntity.ReplaceGameComponentsEliminate(false);
                }
            }
        }

        private bool IsMeetCondition(GameEntity entity)
        {
            var up = entity.gameComponentsDetectionSameItem.UpEntities.Count;
            var down = entity.gameComponentsDetectionSameItem.DownEntities.Count;
            var left = entity.gameComponentsDetectionSameItem.LeftEntities.Count;
            var right = entity.gameComponentsDetectionSameItem.RightEntities.Count;
            return left + right >= 2
                   || up + down >= 2;
        }
    }
}