using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance;
    public Text scoreText;
    public Text coinsText;

    public Text highScoreText;

    public GameObject gameOverPanel;

    public Text devModeText;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ""+Game.Instance.runScore.ToString();
        coinsText.text = "Coins: " + Game.Instance.coins.ToString();
        highScoreText.text = $"Highscore: {Game.Instance.maxScore.ToString()}";

    }

    public void GenerateRandomText()
    {

    }
}
