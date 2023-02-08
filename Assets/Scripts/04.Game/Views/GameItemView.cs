using DG.Tweening;
using Entitas;
using UnityEngine;

namespace _04.Game.Views
{
    public class GameItemView : View, IGameComponentsItemIndexListener
    {
        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);
            _gameEntity.AddGameComponentsItemIndexListener(this);
        }

        public void OnGameComponentsItemIndex(GameEntity entity, CustomVector2 vector2)
        {
            transform.DOKill();
            transform.DOMove(new Vector3(vector2.x, vector2.y, 0), 3f);
        }
    }
}