using System.Collections.Generic;
using Entitas;
using Game.Components;
using Game.Const;

namespace Game.System.Game
{
    public class JudgeFormationSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;

        public JudgeFormationSystem(Contexts context) : base(context.game)
        {
            _context = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentsJudgeFormation);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isGameComponentsJudgeFormation;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                if (gameEntity.gameComponentsItemEffectState.State == ItemEffectName.NONE)
                {
                    JudgeItem(gameEntity);
                }
                else
                {
                    gameEntity.isGameComponentsJudgeFormation = false;
                }

                gameEntity.ReplaceGameComponentsEliminate(true);
            }
        }

        private void JudgeItem(GameEntity gameEntity)
        {
            var component = gameEntity.gameComponentsDetectionSameItem;
            if (JudgeEliminateAll(component))
                gameEntity.ReplaceGameComponentsItemEffectState(ItemEffectName.ELIMINATE_SAME_COLOR);
            else if (JudgeEliminateHorizontal(component))
                gameEntity.ReplaceGameComponentsItemEffectState(ItemEffectName.ELIMINATE_HORIZONTAL);
            else if (JudgeEliminateVertical(component))
                gameEntity.ReplaceGameComponentsItemEffectState(ItemEffectName.ELIMINATE_VERTICAL);
            else if (JudgeExplode(component))
                gameEntity.ReplaceGameComponentsItemEffectState(ItemEffectName.EXPLODE);
            else gameEntity.isGameComponentsJudgeFormation = false;
        }

        private bool JudgeEliminateAll(DetectionSameItem listComponent)
        {
            if (listComponent.LeftEntities.Count + listComponent.RightEntities.Count >= 4)
            {
                return true;
            }

            return listComponent.UpEntities.Count + listComponent.DownEntities.Count >= 4;
        }

        private bool JudgeEliminateHorizontal(DetectionSameItem listComponent)
        {
            return listComponent.LeftEntities.Count + listComponent.RightEntities.Count == 3;
        }

        private bool JudgeEliminateVertical(DetectionSameItem listComponent)
        {
            return listComponent.UpEntities.Count + listComponent.DownEntities.Count == 3;
        }

        private bool JudgeExplode(DetectionSameItem listComponent)
        {
            return listComponent.LeftEntities.Count + listComponent.RightEntities.Count >= 2 &&
                   listComponent.UpEntities.Count + listComponent.DownEntities.Count >= 2;
        }
    }
}