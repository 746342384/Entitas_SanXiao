using System.Collections.Generic;
using Entitas;

namespace _04.Game.System.Game
{
    public class DestroySystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new();

        public DestroySystem(Contexts context)
        {
            _group = context.game.GetGroup(GameMatcher.GameComponentsDestroy);
        }

        public void Cleanup()
        {
            foreach (var gameEntity in _group.GetEntities(_buffer))
            {
                gameEntity.Destroy();
            }
        }
    }
}