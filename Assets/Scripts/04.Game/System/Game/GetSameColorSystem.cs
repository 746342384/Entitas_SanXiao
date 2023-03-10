using System;
using System.Collections.Generic;
using Entitas;

namespace Game.System
{
    public class GetSameColorSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;

        public GetSameColorSystem(Contexts context) : base(context.game)
        {
            _context = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentsGetSameColor);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isGameComponentsGetSameColor;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var judgeUp = JudgeUp(gameEntity);
                var judgeDown = JudgeDown(gameEntity);
                var judgeLeft = JudgeLeft(gameEntity);
                var judgeRight = JudgeRight(gameEntity);
                gameEntity.ReplaceGameComponentsDetectionSameItem(judgeUp, judgeDown, judgeLeft, judgeRight);
                gameEntity.isGameComponentsGetSameColor = false;
            }
        }

        private List<IEntity> JudgeLeft(GameEntity entity)
        {
            var pos = entity.gameComponentsItemIndex.Vector2;
            var sameEntities = new List<IEntity>();
            for (var i = pos.x - 1; i >= 0; i--)
            {
                if (!AddSameColorItem(entity, i, pos.y, sameEntities)) break;
            }

            return sameEntities;
        }

        private List<IEntity> JudgeRight(GameEntity entity)
        {
            var pos = entity.gameComponentsItemIndex.Vector2;
            var sameEntities = new List<IEntity>();
            for (var i = pos.x + 1; i < _context.game.gameComponentsGameBoard.columns; i++)
            {
                if (!AddSameColorItem(entity, i, pos.y, sameEntities)) break;
            }

            return sameEntities;
        }

        private List<IEntity> JudgeUp(GameEntity entity)
        {
            var pos = entity.gameComponentsItemIndex.Vector2;
            var sameEntities = new List<IEntity>();
            for (var i = pos.y + 1; i < _context.game.gameComponentsGameBoard.rows; i++)
            {
                if (!AddSameColorItem(entity, pos.x, i, sameEntities)) break;
            }

            return sameEntities;
        }

        private List<IEntity> JudgeDown(GameEntity entity)
        {
            var pos = entity.gameComponentsItemIndex.Vector2;
            var sameEntities = new List<IEntity>();
            for (var i = pos.y - 1; i >= 0; i--)
            {
                if (!AddSameColorItem(entity, pos.x, i, sameEntities)) break;
            }

            return sameEntities;
        }

        private bool AddSameColorItem(GameEntity entity, int x, int y, List<IEntity> entities)
        {
            var colorName = entity.gameComponentsLoadPrefab.path;
            var tuple = JudgeAddSameColorItem(colorName, x, y);
            if (!tuple.Item1) return false;
            entities.Add(tuple.Item2);
            return true;
        }

        private Tuple<bool, GameEntity> JudgeAddSameColorItem(string colorName, int x, int y)
        {
            var gameEntities = _context.game.GetEntitiesWithGameComponentsItemIndex(new CustomVector2(x, y));

            if (gameEntities.Count != 1)
            {
                return new Tuple<bool, GameEntity>(false, null);
            }

            var singleEntity = gameEntities.SingleEntity();
            var isSame = singleEntity.isGameComponentsMoveable &&
                         singleEntity.gameComponentsLoadPrefab.path.Equals(colorName);
            return new Tuple<bool, GameEntity>(isSame, singleEntity);
        }
    }
}