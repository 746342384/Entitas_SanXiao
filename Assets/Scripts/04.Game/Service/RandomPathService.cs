using Game.Const;
using UnityEngine;

namespace _04.Game.Service
{
    public class RandomPathService
    {
        private static RandomPathService _instance;
        public static RandomPathService Instance => _instance ??= new RandomPathService();

        public string RandomPath()
        {
            var index = Random.Range(0, 6);
            return $"{ResPath.Item}{index}";
        }
    }
}