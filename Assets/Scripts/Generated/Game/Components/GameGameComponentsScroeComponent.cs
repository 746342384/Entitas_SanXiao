//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gameComponentsScroeEntity { get { return GetGroup(GameMatcher.GameComponentsScroe).GetSingleEntity(); } }
    public Game.Components.Scroe gameComponentsScroe { get { return gameComponentsScroeEntity.gameComponentsScroe; } }
    public bool hasGameComponentsScroe { get { return gameComponentsScroeEntity != null; } }

    public GameEntity SetGameComponentsScroe(int newScore) {
        if (hasGameComponentsScroe) {
            throw new Entitas.EntitasException("Could not set GameComponentsScroe!\n" + this + " already has an entity with Game.Components.Scroe!",
                "You should check if the context already has a gameComponentsScroeEntity before setting it or use context.ReplaceGameComponentsScroe().");
        }
        var entity = CreateEntity();
        entity.AddGameComponentsScroe(newScore);
        return entity;
    }

    public void ReplaceGameComponentsScroe(int newScore) {
        var entity = gameComponentsScroeEntity;
        if (entity == null) {
            entity = SetGameComponentsScroe(newScore);
        } else {
            entity.ReplaceGameComponentsScroe(newScore);
        }
    }

    public void RemoveGameComponentsScroe() {
        gameComponentsScroeEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.Components.Scroe gameComponentsScroe { get { return (Game.Components.Scroe)GetComponent(GameComponentsLookup.GameComponentsScroe); } }
    public bool hasGameComponentsScroe { get { return HasComponent(GameComponentsLookup.GameComponentsScroe); } }

    public void AddGameComponentsScroe(int newScore) {
        var index = GameComponentsLookup.GameComponentsScroe;
        var component = (Game.Components.Scroe)CreateComponent(index, typeof(Game.Components.Scroe));
        component.score = newScore;
        AddComponent(index, component);
    }

    public void ReplaceGameComponentsScroe(int newScore) {
        var index = GameComponentsLookup.GameComponentsScroe;
        var component = (Game.Components.Scroe)CreateComponent(index, typeof(Game.Components.Scroe));
        component.score = newScore;
        ReplaceComponent(index, component);
    }

    public void RemoveGameComponentsScroe() {
        RemoveComponent(GameComponentsLookup.GameComponentsScroe);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameComponentsScroe;

    public static Entitas.IMatcher<GameEntity> GameComponentsScroe {
        get {
            if (_matcherGameComponentsScroe == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameComponentsScroe);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameComponentsScroe = matcher;
            }

            return _matcherGameComponentsScroe;
        }
    }
}
