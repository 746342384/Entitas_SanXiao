using System;
using System.IO;
using UnityEngine;

namespace _04.Game.Service
{
    public class LoadConfigService
    {
        private static LoadConfigService _instance;
        public static LoadConfigService Instance = _instance ?? new LoadConfigService();

        public T Load<T>(string path) where T : class
        {
            try
            {
                var json = File.ReadAllText(path);
                var fromJson = JsonUtility.FromJson<T>(json);
                return fromJson;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}