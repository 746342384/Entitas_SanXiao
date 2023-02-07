using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class LogSystem : ReactiveSystem<GameEntity>
{
    public LogSystem(IContext<GameEntity> context) : base(context)
    {
    }

    public LogSystem(ICollector<GameEntity> collector) : base(collector)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Log);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasLog;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var gameEntity in entities)
        {
            Debug.Log(gameEntity.log.message);
        }
    }
}