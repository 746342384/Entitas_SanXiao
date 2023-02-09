using UnityEngine;

namespace _04.Game.Service
{
    public class Services
    {
        public Services(Contexts contexts, Transform parent)
        {
            LoadPrefabService.Instance.Init(contexts, parent);
            CreateService.Instance.Init(contexts);
            GetEmptyItemService.Instance.Init(contexts);
        }
    }
}