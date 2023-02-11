using DG.Tweening;
using Entitas;
using Game.Const;
using Game.Views;
using UnityEngine;

namespace _04.Game.Views
{
    public class GameItemView : View, IGameComponentsItemIndexListener, IGameComponentsLoadSpriteListener
    {
        public float time = 0.5f;
        private SpriteRenderer _spriteRenderer;

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);
            _gameEntity.AddGameComponentsItemIndexListener(this);
            _gameEntity.AddGameComponentsLoadSpriteListener(this);
            transform.position = new Vector3(_gameEntity.gameComponentsItemIndex.Vector2.x,
                Contexts.sharedInstance.game.gameComponentsGameBoard.rows);
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            IView audioView = gameObject.AddComponent<AudioView>();
            audioView.Link(entity, context);
        }

        public void OnGameComponentsItemIndex(GameEntity entity, CustomVector2 vector2)
        {
            transform.DOMove(new Vector3(vector2.x, vector2.y, 0), 0.5f).OnComplete(() =>
            {
                _gameEntity.isGameComponentsExchangeComplete = true;
                _gameEntity.ReplaceGameComponentsFall(FallState.STEADY);
            });
        }

        public override void OnGameComponentsDestroy(GameEntity entity)
        {
            base.OnGameComponentsDestroy(entity);
            transform.DOScale(Vector3.one * 1.5f, time);
            _spriteRenderer.DOColor(Color.clear, time).OnComplete(() => { Destroy(gameObject); });
        }

        public void OnGameComponentsLoadSprite(GameEntity entity, string name)
        {
            var sprite = Resources.Load<Sprite>(ResPath.SpritesPath + name);
            _spriteRenderer.sprite = sprite;
        }
    }
}