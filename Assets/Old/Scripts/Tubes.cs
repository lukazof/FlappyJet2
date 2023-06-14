using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tubes : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("GameOver");

    }
}
