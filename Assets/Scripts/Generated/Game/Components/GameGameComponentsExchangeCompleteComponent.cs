//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Game.Components.ExchangeComplete gameComponentsExchangeCompleteComponent = new Game.Components.ExchangeComplete();

    public bool isGameComponentsExchangeComplete {
        get { return HasComponent(GameComponentsLookup.GameComponentsExchangeComplete); }
        set {
            if (value != isGameComponentsExchangeComplete) {
                var index = GameComponentsLookup.GameComponentsExchangeComplete;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : gameComponentsExchangeCompleteComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherGameComponentsExchangeComplete;

    public static Entitas.IMatcher<GameEntity> GameComponentsExchangeComplete {
        get {
            if (_matcherGameComponentsExchangeComplete == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameComponentsExchangeComplete);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameComponentsExchangeComplete = matcher;
            }

            return _matcherGameComponentsExchangeComplete;
        }
    }
}
