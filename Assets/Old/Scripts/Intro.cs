using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{


    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("MainMenu");
   
    }


}
