using Entitas;
using UnityEngine;

namespace _01.HelloWorld.Systems
{
    public class InitSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;

        public InitSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
        }

        public void Initialize()
        {
            Debug.Log("InitSystem.Initialize");
            _gameContext.CreateEntity().AddLog("Hello World");
        }
    }
}