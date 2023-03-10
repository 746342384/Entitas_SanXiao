//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameComponentsItemIndexListenerComponent gameComponentsItemIndexListener { get { return (GameComponentsItemIndexListenerComponent)GetComponent(GameComponentsLookup.GameComponentsItemIndexListener); } }
    public bool hasGameComponentsItemIndexListener { get { return HasComponent(GameComponentsLookup.GameComponentsItemIndexListener); } }

    public void AddGameComponentsItemIndexListener(System.Collections.Generic.List<IGameComponentsItemIndexListener> newValue) {
        var index = GameComponentsLookup.GameComponentsItemIndexListener;
        var component = (GameComponentsItemIndexListenerComponent)CreateComponent(index, typeof(GameComponentsItemIndexListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameComponentsItemIndexListener(System.Collections.Generic.List<IGameComponentsItemIndexListener> newValue) {
        var index = GameComponentsLookup.GameComponentsItemIndexListener;
        var component = (GameComponentsItemIndexListenerComponent)CreateComponent(index, typeof(GameComponentsItemIndexListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameComponentsItemIndexListener() {
        RemoveComponent(GameComponentsLookup.GameComponentsItemIndexListener);
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

    static Entitas.IMatcher<GameEntity> _matcherGameComponentsItemIndexListener;

    public static Entitas.IMatcher<GameEntity> GameComponentsItemIndexListener {
        get {
            if (_matcherGameComponentsItemIndexListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameComponentsItemIndexListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameComponentsItemIndexListener = matcher;
            }

            return _matcherGameComponentsItemIndexListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddGameComponentsItemIndexListener(IGameComponentsItemIndexListener value) {
        var listeners = hasGameComponentsItemIndexListener
            ? gameComponentsItemIndexListener.value
            : new System.Collections.Generic.List<IGameComponentsItemIndexListener>();
        listeners.Add(value);
        ReplaceGameComponentsItemIndexListener(listeners);
    }

    public void RemoveGameComponentsItemIndexListener(IGameComponentsItemIndexListener value, bool removeComponentWhenEmpty = true) {
        var listeners = gameComponentsItemIndexListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveGameComponentsItemIndexListener();
        } else {
            ReplaceGameComponentsItemIndexListener(listeners);
        }
    }
}
