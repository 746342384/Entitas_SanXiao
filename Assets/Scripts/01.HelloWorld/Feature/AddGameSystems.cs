using _01.HelloWorld.Systems;
using Entitas;

public class AddGameSystems : Feature
{
    public AddGameSystems(Contexts contexts) : base("AddGameSystems")
    {
        Add(new LogSystem(contexts.game));
        Add(new InitSystem(contexts));
    }

    public sealed override Systems Add(ISystem system)
    {
        return base.Add(system);
    }
}