using System.Collections.Generic;
using _03.MultiReactive.Systems;
using Entitas;
using UnityEngine;

namespace _03.MultiReactive.Systems
{
    public class MultiDestroySystem : MultiReactiveSystem<IDestroySystem, Contexts>
    {
        public MultiDestroySystem(Contexts contexts) : base(contexts)
        {
        }

        protected override ICollector[] GetTrigger(Contexts contexts)
        {
            return new ICollector[]
            {
                contexts.game.CreateCollector(GameMatcher.MultiReactiveDestroy),
                contexts.input.CreateCollector(InputMatcher.MultiReactiveDestroy),
                contexts.ui.CreateCollector(UiMatcher.MultiReactiveDestroy)
            };
        }

        protected override bool Filter(IDestroySystem entity)
        {
            return entity.isMultiReactiveDestroy;
        }

        protected override void Execute(List<IDestroySystem> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.hasMultiReactiveView)
                {
                    Object.Destroy(entity.multiReactiveView.trans.gameObject);
                }

                Debug.Log($"{entity.contextInfo.name}:MultiDestroySystem.Execute");
            }
        }
    }

    public interface IDestroySystem : IEntity, IMultiReactiveDestroyEntity, IMultiReactiveViewEntity
    {
    }
}

public partial class GameEntity : IDestroySystem
{
}

public partial class InputEntity : IDestroySystem
{
}

public partial class UiEntity : IDestroySystem
{
}