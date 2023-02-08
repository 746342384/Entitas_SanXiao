using System.Collections.Generic;
using _04.Game.Service;
using Entitas;
using UnityEngine;

namespace _04.Game.System
{
    public class GameBoardSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private IGroup<GameEntity> _itemEntity;

        public GameBoardSystem(Contexts context) : base(context.game)
        {
            _itemEntity = context.game.GetGroup(GameMatcher.GameComponentsGameBoardItem);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentsGameBoard);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameComponentsGameBoard;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var gameComponentsGameBoard = entities.SingleEntity().gameComponentsGameBoard;
            foreach (var gameEntity in _itemEntity)
            {
            }
        }

        public void Initialize()
        {
            var gameBoard = CreateService.Instance.CreateGameBoard().gameComponentsGameBoard;
            var columns = gameBoard.columns;
            var rows = gameBoard.rows;
            for (var x = 0; x < columns; x++)
            {
                for (var y = 0; y < rows; y++)
                {
                    if (RandomBlocker())
                    {
                        CreateService.Instance.CreateBloker();
                    }
                    else
                    {
                        CreateService.Instance.CreateBall();
                    }
                }
            }
        }

        /// <summary>
        /// 生成障碍的概率
        /// </summary>
        /// <returns></returns>
        private bool RandomBlocker()
        {
            var randomNum = Random.Range(0, 10);
            return randomNum < 1;
        }
    }
}