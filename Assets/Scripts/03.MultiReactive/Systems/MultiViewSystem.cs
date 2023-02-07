using System.Collections.Generic;
using _03.MultiReactive.Systems;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace _03.MultiReactive.Systems
{
    public class MultiViewSystem : MultiReactiveSystem<IViewSystem, Contexts>
    {
        private readonly Dictionary<string, Transform> _parentDic = new();

        public MultiViewSystem(Contexts contexts) : base(contexts)
        {
            foreach (var context in contexts.allContexts)
            {
                var contextInfoName = context.contextInfo.name;
                _parentDic[contextInfoName] = new GameObject(contextInfoName).transform;
            }
        }

        protected override ICollector[] GetTrigger(Contexts contexts)
        {
            return new ICollector[]
            {
                contexts.game.CreateCollector(GameMatcher.MultiReactiveView),
                contexts.input.CreateCollector(InputMatcher.MultiReactiveView),
                contexts.ui.CreateCollector(UiMatcher.MultiReactiveView)
            };
        }

        protected override bool Filter(IViewSystem entity)
        {
            return !entity.hasMultiReactiveView;
        }

        protected override void Execute(List<IViewSystem> entities)
        {
            foreach (var entity in entities)
            {
                var name = entity.contextInfo.name;
                var go = new GameObject(name);
                go.transform.SetParent(_parentDic[name]);
                go.Link(entity);
                entity.AddMultiReactiveView(go.transform as RectTransform);
            }
        }
    }

    public interface IViewSystem : IEntity, IMultiReactiveViewEntity
    {
    }
}

public partial class GameEntity : IViewSystem
{
}

public partial class InputEntity : IViewSystem
{
}

public partial class UiEntity : IViewSystem
{
}