using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundJet : MonoBehaviour
{


    public Rigidbody2D rb;
    public float speed;
    private AudioSource sound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
        rb.velocity = new Vector2(speed, 0.7f);
   
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 0.7f);
    }
}
