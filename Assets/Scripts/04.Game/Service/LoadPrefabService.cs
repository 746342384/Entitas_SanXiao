using _04.Game.Views;
using UnityEngine;

namespace _04.Game.Service
{
    public class LoadPrefabService : IGameComponentsAnyLoadPrefabListener
    {
        private static LoadPrefabService _instance;
        public static LoadPrefabService Instance => _instance ??= new LoadPrefabService();
        private Contexts _contexts;
        private Transform _settleParent;
        private Transform _moveParent;

        public void Init(Contexts contexts, Transform parent)
        {
            _contexts = contexts;
            _contexts.game.CreateEntity().AddGameComponentsAnyLoadPrefabListener(this);
            CreateSubParent(parent);
        }

        private void CreateSubParent(Transform parent)
        {
            _settleParent = new GameObject("settle").transform;
            _settleParent.SetParent(parent);
            _moveParent = new GameObject("move").transform;
            _moveParent.SetParent(parent);
        }

        public void OnGameComponentsAnyLoadPrefab(GameEntity entity, string path)
        {
            var temp = entity.isGameComponentsMoveable ? _moveParent : _settleParent;
            var gameObject = Resources.Load<GameObject>(path);
            var instantiate = Object.Instantiate(gameObject, temp, true);
            var view = instantiate.GetComponent<IView>();
            view.Link(entity, _contexts.game);
        }
    }
}