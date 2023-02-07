using Entitas;
using InterationExample;
using UnityEngine;

namespace _02.InterationExample.Systems
{
    public class MouseSystem : IExecuteSystem, IInitializeSystem
    {
        private InputEntity _inputEntity;

        private InputContext _inputContext;

        public MouseSystem(Contexts contexts)
        {
            _inputContext = contexts.input;
        }

        public void Initialize()
        {
            _inputEntity = _inputContext.interationExampleMouseEntity;
        }

        public void Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _inputContext.ReplaceInterationExampleMouse(MouseButton.LEFT, MouseButtonEvent.DOWN);
            }

            if (Input.GetMouseButtonDown(1))
            {
                _inputContext.ReplaceInterationExampleMouse(MouseButton.RIGHT, MouseButtonEvent.DOWN);
            }
        }
    }
}