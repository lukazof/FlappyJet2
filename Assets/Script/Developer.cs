using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Developer : MonoBehaviour
{
    public GameBuild build;

    // Start is called before the first frame update
    void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
    }

    private void Start()
    {
        if(build == GameBuild.mobile)
        {
            Screen.SetResolution(1080, 1920, true);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public enum GameBuild
    {
        pc, mobile
    }
}
