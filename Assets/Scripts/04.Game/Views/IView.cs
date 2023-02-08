using Entitas;

namespace _04.Game.Views
{
    /// <summary>
    /// 视图层接口
    /// </summary>
    public interface IView
    {
        void Link(IEntity entity, IContext context);
    }
}