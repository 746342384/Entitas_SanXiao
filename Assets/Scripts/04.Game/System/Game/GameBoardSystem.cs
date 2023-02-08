using System.Collections.Generic;
using _04.Game.Service;
using Entitas;
using Game.Const;
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
        }

        public void Initialize()
        {
            var gameBoard = CreateService.Instance.CreateGameBoard().gameComponentsGameBoard;
            var columns = gameBoard.columns;
            var rows = gameBoard.rows;
            var customVector2 = new CustomVector2();
            for (var x = 0; x < columns; x++)
            {
                for (var y = 0; y < rows; y++)
                {
                    customVector2.x = x;
                    customVector2.y = y;
                    if (RandomBlocker())
                        CreateService.Instance.CreateBloker(customVector2, ResPath.Blocker);
                    else
                        CreateService.Instance.CreateBall(customVector2, RandomPathService.Instance.RandomPath());
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