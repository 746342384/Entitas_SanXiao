using System.IO;
using Game.Const;
using UnityEngine;

namespace _04.Game.Service
{
    public class LoadConfigService
    {
        private static LoadConfigService _instance;
        public static LoadConfigService Instance = _instance ?? new LoadConfigService();

        public T Load<T>() where T : class
        {
            if (!File.Exists(ResPath.DataPath)) return null;
            var json = File.ReadAllText(ResPath.DataPath);
            return JsonUtility.FromJson<T>(json);

        }
    }
}