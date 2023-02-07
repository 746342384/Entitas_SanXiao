using UnityEngine;

namespace _03.MultiReactive.Views
{
    public class TestView : MonoBehaviour, IMultiReactiveAnyNameListener
    {
        public void OnMultiReactiveAnyName(GameEntity entity, string name)
        {
            Debug.Log($"TestView.OnMultiReactiveAnyName:{entity.contextInfo.name} {name}");
        }
    }
}