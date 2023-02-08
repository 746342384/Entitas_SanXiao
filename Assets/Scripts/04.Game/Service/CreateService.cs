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

        public void CreateBall()
        {
        }

        public void CreateBloker()
        {
        }
    }
}