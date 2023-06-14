using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;
    public GameState state;

    public GameObject coin;
    public GameObject pipe;
    public float pipeSpawnInterval;
    public float pipeSpeed;

    public Player player;
    public int coins;
    public int maxScore;
    public int runScore;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        UpdateHighscore();
        state = GameState.waiting;
        StartCoroutine(SpawnPipe());
        StartCoroutine(SpawnCoin());
    }

    // Update is called once per frame
    void Update()
    {

    }

    float pipeSpawnDelay;
    public IEnumerator SpawnPipe()
    {
        if (state == GameState.playing)
        {
            pipeSpawnDelay = Random.Range(pipeSpawnInterval / 2, pipeSpawnInterval);
            yield return new WaitForSeconds(pipeSpawnDelay);

            Instantiate(pipe, new Vector3(15, 0, 0), Quaternion.identity);
            StartCoroutine(SpawnPipe());
        }
    }

    public IEnumerator SpawnCoin()
    {
        if (state == GameState.playing)
        {
            yield return new WaitForSeconds(Random.Range(3, 10));

            Instantiate(coin, new Vector3(12, 0, 0), Quaternion.identity);
            StartCoroutine(SpawnCoin());
        }
    }

    public void GameOver()
    {
        state = GameState.gameover;
        Player.Instance.canPlay = false;
        Player.Instance.rb.AddTorque(1000);
        Player.Instance.rb.AddForce(Vector2.right * 100);
        AudioManager.Instance.PlayRandomSound(AudioManager.Instance.explosionSounds);
        Player.Instance.particles[2].Play();

        Camera.main.transform.position = new Vector3(0, 0, -10);
        CameraShake.Instance.ShakeCamera(0.20f, 0.35f);

        GameUI.Instance.gameOverPanel.GetComponent<Animator>().SetTrigger("FadeIn");

        if(runScore > maxScore)
        {
            PlayerPrefs.SetInt("Highscore", runScore);
            PlayerPrefs.Save();

            UpdateHighscore();
        }
    }

    public void StartGame()
    {
        Player.Instance.gameObject.transform.position = Vector3.zero;
        state = GameState.playing;
        Player.Instance.canPlay = true;
        Player.Instance.rb.isKinematic = false;

        StartCoroutine(SpawnPipe());
        StartCoroutine(SpawnCoin());

    }

    public void UpdateHighscore()
    {
        maxScore = PlayerPrefs.GetInt("Highscore");

    }
    public void Replay()
    {
        if(state != GameState.gameover) { return; }
        GameUI.Instance.gameOverPanel.GetComponent<Animator>().SetTrigger("Hide");
        Pipe[] pipes;

        pipes = FindObjectsOfType<Pipe>();

        foreach (Pipe pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }

        ResetScore();
        StartGame();
    }

    public void ResetScore()
    {
        runScore = 0;
    }

    [System.Serializable]
    public enum GameState{
        waiting, playing, gameover
    }
}
