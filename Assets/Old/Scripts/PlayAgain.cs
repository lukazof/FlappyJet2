using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Game");
        }
    }
}
