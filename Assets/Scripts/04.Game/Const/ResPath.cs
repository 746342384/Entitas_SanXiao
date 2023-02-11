
namespace Game.Const
{
    public abstract class ResPath
    {
        private const string PrefabPath = "Prefabs/";
        public const string Blocker = PrefabPath + "Blocker";
        public const string Item = PrefabPath + "Item";
        public const string AllPostfix = "_1";
        public const string HorizontalPostfix = "_1";
        public const string VerticalPostfix = "_1";
        public const string ExplodePostfix = "_1";
        public const string SpritesPath = "Sprites/";
        public static readonly string ConfigPath = UnityEngine.Application.streamingAssetsPath + "/Config/";
        public static readonly string DataPath = ConfigPath + "Data.json";
        public const string AudioPath = "Audio/";
    }
}