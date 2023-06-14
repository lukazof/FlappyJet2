using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingJet : MonoBehaviour
{


    public Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, -0.9f);
   
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-speed, -0.9f);
    }
}
