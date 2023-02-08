using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace _04.Game.Views
{
    public abstract class View : MonoBehaviour, IView, IGameComponentsDestroyListener
    {
        protected GameEntity _gameEntity;

        public virtual void Link(IEntity entity, IContext context)
        {
            if (entity is GameEntity gameEntity)
            {
                _gameEntity = gameEntity;
            }
            else
            {
                Debug.LogError("实体类型错误");
            }

            _gameEntity.AddGameComponentsDestroyListener(this);
            gameObject.Link(entity);
        }

        public virtual void OnGameComponentsDestroy(GameEntity entity)
        {
            gameObject.Unlink();
        }
    }
}