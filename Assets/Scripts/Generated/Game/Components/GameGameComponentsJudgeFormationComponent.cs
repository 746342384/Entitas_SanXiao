//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Game.Components.JudgeFormation gameComponentsJudgeFormationComponent = new Game.Components.JudgeFormation();

    public bool isGameComponentsJudgeFormation {
        get { return HasComponent(GameComponentsLookup.GameComponentsJudgeFormation); }
        set {
            if (value != isGameComponentsJudgeFormation) {
                var index = GameComponentsLookup.GameComponentsJudgeFormation;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : gameComponentsJudgeFormationComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherGameComponentsJudgeFormation;

    public static Entitas.IMatcher<GameEntity> GameComponentsJudgeFormation {
        get {
            if (_matcherGameComponentsJudgeFormation == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameComponentsJudgeFormation);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameComponentsJudgeFormation = matcher;
            }

            return _matcherGameComponentsJudgeFormation;
        }
    }
}