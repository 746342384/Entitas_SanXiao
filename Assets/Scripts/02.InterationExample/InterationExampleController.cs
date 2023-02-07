using System;
using UnityEngine;

namespace _02.InterationExample
{
    public class InterationExampleController : MonoBehaviour
    {
        private Contexts _contexts;
        private Entitas.Systems _systems;

        private void Start()
        {
            _contexts = Contexts.sharedInstance;
            _systems = new Feature("System")
                .Add(new GameFeature(_contexts))
                .Add(new InputFeature(_contexts));
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}