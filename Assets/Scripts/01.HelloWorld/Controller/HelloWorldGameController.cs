using System;
using Entitas;
using UnityEngine;

public class HelloWorldGameController : MonoBehaviour
{
    private Systems _systems;
    private Contexts _contexts;

    private void Start()
    {
        _contexts = Contexts.sharedInstance;
        _systems = new Feature("Systems").Add(new AddGameSystems(_contexts));
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}