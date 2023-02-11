using UnityEngine;
using UnityEngine.UI;

public class ScoreViewController : MonoBehaviour, IGameComponentsAnyScroeListener
{
    private Text scoreTxt;
    void Awake()
    {
        scoreTxt = transform.GetComponent<Text>();
    }

    private void Start()
    {
        var gameEntity = Contexts.sharedInstance.game.CreateEntity();
        gameEntity.AddGameComponentsAnyScroeListener(this);
    }


    public void OnGameComponentsAnyScroe(GameEntity entity, int score)
    {
        scoreTxt.text = score.ToString();
    }
}