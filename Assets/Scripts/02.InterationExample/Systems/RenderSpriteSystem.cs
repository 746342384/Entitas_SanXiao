using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _02.InterationExample.Systems
{
    public class RenderSpriteSystem : ReactiveSystem<GameEntity>
    {
        public RenderSpriteSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InterationExampleSprite);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInterationExampleSprite && entity.hasInterationExampleView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var trans = entity.interationExampleView.viewTrans;
                var sr = trans.GetComponent<SpriteRenderer>();
                if (null == sr)
                {
                    sr = trans.gameObject.AddComponent<SpriteRenderer>();
                }

                sr.sprite = Resources.Load<Sprite>(entity.interationExampleSprite.spriteName);
            }
        }
    }
}