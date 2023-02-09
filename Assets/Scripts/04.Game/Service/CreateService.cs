using Game.Const;

namespace _04.Game.Service
{
    public class CreateService
    {
        private Contexts _contexts;
        private static CreateService _instance;
        public static CreateService Instance => _instance ??= new CreateService();

        public void Init(Contexts contexts)
        {
            _contexts = contexts;
        }

        /// <summary>
        /// 创建游戏面板
        /// </summary>
        /// <returns></returns>
        public GameEntity CreateGameBoard()
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddGameComponentsGameBoard(8, 9);
            return entity;
        }

        public GameEntity CreateBall(CustomVector2 vector2)
        {
            var entity = _contexts.game.CreateEntity();
            entity.isGameComponentsGameBoardItem = true;
            entity.isGameComponentsMoveable = true;
            entity.AddGameComponentsItemIndex(vector2);
            entity.AddGameComponentsLoadPrefab(RandomPathService.Instance.RandomPath());
            return entity;
        }

        public GameEntity CreateBloker(CustomVector2 vector2)
        {
            var entity = _contexts.game.CreateEntity();
            entity.isGameComponentsGameBoardItem = true;
            entity.isGameComponentsMoveable = false;
            entity.AddGameComponentsItemIndex(vector2);
            entity.AddGameComponentsLoadPrefab(ResPath.Blocker);
            return entity;
        }
    }
}