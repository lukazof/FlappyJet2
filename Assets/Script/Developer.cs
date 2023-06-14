using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Developer : MonoBehaviour
{
    public GameBuild build;

    public bool devMode;
    public bool infiniteCoins;
    public bool clearPrefs;


    // Start is called before the first frame update
    void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        if (clearPrefs) { PlayerPrefs.DeleteAll();  }
    }

    private void Start()
    {
        devMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKey(KeyCode.Z))
            {
                if (Input.GetKey(KeyCode.X))
                {
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        devMode = !devMode;
                        GameUI.Instance.devModeText.gameObject.SetActive(devMode);
                    }
                }
            }
        }

        if (devMode)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                Game.Instance.coins += 10;
                PlayerPrefs.SetInt("Coins", Game.Instance.coins);

            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                Game.Instance.coins -= 10;
                PlayerPrefs.SetInt("Coins", Game.Instance.coins);

            }

            if (Input.GetKeyDown(KeyCode.F3))
            {
                ClearAllPrefs();
            }

        }

        void ClearAllPrefs()
        {
            print("Deleting all Prefs!");
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("SampleScene");
        }
        
    }

    [System.Serializable]
    public enum GameBuild
    {
        pc, mobile
    }
}
