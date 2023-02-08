using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace _04.Game.Views
{
    public abstract class View : MonoBehaviour, IView
    {
        protected GameEntity _gameEntity;
        protected GameContext _gameContext;

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

            _gameContext = context as GameContext;
            gameObject.Link(entity);
        }
    }
}