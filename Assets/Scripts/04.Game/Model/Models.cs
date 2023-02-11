using _04.Game.Service;
using Game.Const;

namespace _04.Game.Model
{
    public class Models
    {
        public static Models Instance { get; private set; } = new Models();

        public DataModel DataModel => LoadConfigService.Instance.Load<DataModel>(ResPath.DataPath);
    }
}