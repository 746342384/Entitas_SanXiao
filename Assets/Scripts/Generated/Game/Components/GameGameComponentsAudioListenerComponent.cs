//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameComponentsAudioListenerComponent gameComponentsAudioListener { get { return (GameComponentsAudioListenerComponent)GetComponent(GameComponentsLookup.GameComponentsAudioListener); } }
    public bool hasGameComponentsAudioListener { get { return HasComponent(GameComponentsLookup.GameComponentsAudioListener); } }

    public void AddGameComponentsAudioListener(System.Collections.Generic.List<IGameComponentsAudioListener> newValue) {
        var index = GameComponentsLookup.GameComponentsAudioListener;
        var component = (GameComponentsAudioListenerComponent)CreateComponent(index, typeof(GameComponentsAudioListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameComponentsAudioListener(System.Collections.Generic.List<IGameComponentsAudioListener> newValue) {
        var index = GameComponentsLookup.GameComponentsAudioListener;
        var component = (GameComponentsAudioListenerComponent)CreateComponent(index, typeof(GameComponentsAudioListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameComponentsAudioListener() {
        RemoveComponent(GameComponentsLookup.GameComponentsAudioListener);
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

    static Entitas.IMatcher<GameEntity> _matcherGameComponentsAudioListener;

    public static Entitas.IMatcher<GameEntity> GameComponentsAudioListener {
        get {
            if (_matcherGameComponentsAudioListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameComponentsAudioListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameComponentsAudioListener = matcher;
            }

            return _matcherGameComponentsAudioListener;
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

    public void AddGameComponentsAudioListener(IGameComponentsAudioListener value) {
        var listeners = hasGameComponentsAudioListener
            ? gameComponentsAudioListener.value
            : new System.Collections.Generic.List<IGameComponentsAudioListener>();
        listeners.Add(value);
        ReplaceGameComponentsAudioListener(listeners);
    }

    public void RemoveGameComponentsAudioListener(IGameComponentsAudioListener value, bool removeComponentWhenEmpty = true) {
        var listeners = gameComponentsAudioListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveGameComponentsAudioListener();
        } else {
            ReplaceGameComponentsAudioListener(listeners);
        }
    }
}
