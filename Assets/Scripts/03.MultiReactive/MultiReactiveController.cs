using System.Collections.Generic;
using UnityEngine;

namespace _03.MultiReactive
{
    public class MultiReactiveController : MonoBehaviour
    {
        private Contexts _contexts;
        private Entitas.Systems _systems;

        private void Start()
        {
            _contexts = Contexts.sharedInstance;
            _systems = new Feature("System").Add(new MultiReactiveFeature(_contexts));
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
            _systems.Cleanup();

            if (Input.GetMouseButtonDown(0))
            {
                var gameEntity = _contexts.game.CreateEntity();
                gameEntity.isMultiReactiveDestroy = true;
                gameEntity.AddMultiReactiveName("Name");
            }

            if (Input.GetMouseButtonDown(1))
            {
                var inputEntity = _contexts.input.CreateEntity();
                inputEntity.isMultiReactiveDestroy = true;
            }
        }
    }
}