using DG.Tweening;
using Entitas;
using UnityEngine;

namespace _04.Game.Views
{
    public class GameItemView : View, IGameComponentsItemIndexListener
    {
        public float time = 0.5f;

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);
            _gameEntity.AddGameComponentsItemIndexListener(this);
        }

        public void OnGameComponentsItemIndex(GameEntity entity, CustomVector2 vector2)
        {
            transform.DOMove(new Vector3(vector2.x, vector2.y, 0), 0.5f).OnComplete(() =>
            {
                _gameEntity.isGameComponentsExchangeComplete = true;
            });
        }

        public override void OnGameComponentsDestroy(GameEntity entity)
        {
            base.OnGameComponentsDestroy(entity);
            transform.DOScale(Vector3.one * 1.5f, time);
            transform.GetComponent<SpriteRenderer>().DOColor(Color.clear, time).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
    }
}