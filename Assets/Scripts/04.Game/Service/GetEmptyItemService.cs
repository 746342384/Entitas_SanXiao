using System.Linq;

namespace _04.Game.Service
{
    public class GetEmptyItemService
    {
        private static GetEmptyItemService _instance;
        private Contexts _contexts;
        public static GetEmptyItemService Instance => _instance ??= new GetEmptyItemService();

        public void Init(Contexts contexts)
        {
            _contexts = contexts;
        }

        public int GetNextEmptyRow(CustomVector2 vector2)
        {
            var row = vector2.y;
            for (var i = vector2.y - 1; i >= 0; i--)
            {
                var customVector2 = new CustomVector2(vector2.x, i);
                var entity = _contexts.game.GetEntitiesWithGameComponentsItemIndex(customVector2).ToArray();
                if (entity.Length == 0)
                {
                    row = i;
                }
                else
                {
                    if (!entity.Single().isGameComponentsMoveable)
                    {
                        continue;
                    }

                    break;
                }
            }

            return row;
        }
    }
}