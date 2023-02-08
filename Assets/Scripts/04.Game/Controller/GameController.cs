using System;
using _04.Game.Service;
using Entitas;
using UnityEngine;

namespace _04.Game.Controller
{
    public class GameController : MonoBehaviour
    {
        private Contexts _contexts;
        private Systems _systems;
        private Services _services;

        private void Start()
        {
            _contexts = Contexts.sharedInstance;
            _services = new Services(_contexts, transform);
            _systems = GetSystems();
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        private Systems GetSystems()
        {
            return new GameFeature(_contexts)
                .Add(new GameEventSystems(_contexts))
                .Add(new InputFeature(_contexts));
        }
    }
}