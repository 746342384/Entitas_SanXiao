using System.Collections.Generic;
using _04.Game.Model;
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
            var customVector2 = new CustomVector2();
            var dataList = GetDataList();
            for (var row = 0; row < gameBoard.rows; row++)
            {
                for (var index = 0; index < dataList[row].Count; index++)
                {
                    customVector2.x = index;
                    customVector2.y = row;
                    CreateService.Instance.CreateBall(dataList[row][index], customVector2);
                }
            }
        }

        private List<List<int>> GetDataList()
        {
            var instanceDataModel = Models.Instance.DataModel;
            var config = instanceDataModel.Level[0];
            var list = new List<List<int>>
            {
                config.row_0,
                config.row_1,
                config.row_2,
                config.row_3,
                config.row_4,
                config.row_5,
                config.row_6,
                config.row_7,
                config.row_8
            };
            return list;
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