using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject GameStuff;
    public GameObject GameOverMenu;
    public GameObject OptionsMenu;
    public GameObject ShopMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
        GameStuff.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        PlayerPrefs.SetInt("Coins", Game.Instance.coins);
        PlayerPrefs.SetInt("Highscore", Game.Instance.maxScore);

        Application.Quit();
    }

    public void PlayGame()
    {
        Game.Instance.StartGame();
        MainMenu.SetActive(false);
        GameStuff.SetActive(true);
    }

    public void GoToMenu()
    {
        Game.Instance.state = Game.GameState.waiting;
        MainMenu.SetActive(true);
        GameStuff.SetActive(false);
        GameOverMenu.GetComponent<Animator>().SetTrigger("Hide");
        ShopMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    public void GoToMenuSafe()
    {
        MainMenu.SetActive(true);
        GameStuff.SetActive(false);
        ShopMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    public void GoToShop()
    {
        MainMenu.SetActive(false);
        GameStuff.SetActive(false);
        ShopMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    public void GoToOptions()
    {
        MainMenu.SetActive(false);
        GameStuff.SetActive(false);
        ShopMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
}
