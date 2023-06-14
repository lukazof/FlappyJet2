using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
public class Options : MonoBehaviour
{
    public Text botText;
    public Text graphicsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        botText.text = "Bot: " + Player.Instance.isAi;
        graphicsText.text = "Graphics: " + Camera.main.GetComponent<PostProcessVolume>().enabled;
    }

    public void TurnGraphics()
    {
        Camera.main.GetComponent<PostProcessVolume>().enabled = !Camera.main.GetComponent<PostProcessVolume>().enabled;
    }

    public void TurnBot()
    {
        Player.Instance.isAi = !Player.Instance.isAi;
    }
}
