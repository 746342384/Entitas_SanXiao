using System.Collections.Generic;
using Entitas;
using Game.Const;

namespace Game.System.Game
{
    /// <summary>
    /// 消除系统
    /// </summary>
    public class EliminateSystem : ReactiveSystem<GameEntity>
    {
        public EliminateSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentsEliminate);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameComponentsEliminate
                   && entity.gameComponentsEliminate.canEliminate;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var sameEntities = GetSameEntities(entities);
            foreach (var sameEntity in sameEntities)
            {
                if (sameEntity is GameEntity temp)
                {
                    temp.isGameComponentsDestroy = true;
                }
            }
        }

        private IEnumerable<IEntity> GetSameEntities(List<GameEntity> entities)
        {
            var sameEntities = new List<IEntity>();
            foreach (var gameEntity in entities)
            {
                if (!gameEntity.isGameComponentsJudgeFormation)
                {
                    sameEntities.Add(gameEntity);
                }
                else
                {
                    gameEntity.isGameComponentsJudgeFormation = false;
                }

                var up = gameEntity.gameComponentsDetectionSameItem.UpEntities.Count;
                var down = gameEntity.gameComponentsDetectionSameItem.DownEntities.Count;
                var left = gameEntity.gameComponentsDetectionSameItem.LeftEntities.Count;
                var right = gameEntity.gameComponentsDetectionSameItem.RightEntities.Count;
                if (left + right >= 2)
                {
                    sameEntities.AddRange(gameEntity.gameComponentsDetectionSameItem.LeftEntities);
                    sameEntities.AddRange(gameEntity.gameComponentsDetectionSameItem.RightEntities);
                }

                if (up + down < 2) continue;
                sameEntities.AddRange(gameEntity.gameComponentsDetectionSameItem.UpEntities);
                sameEntities.AddRange(gameEntity.gameComponentsDetectionSameItem.DownEntities);
            }

            return sameEntities;
        }
    }
}