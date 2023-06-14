using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb.gravityScale = 0;

        //transform.position = new Vector2(transform.position.x, Random.Range(-2, -4f));

        transform.position = new Vector2(transform.position.x, Random.Range(-0.5f, -6f));


        Destroy(gameObject, 7);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * speed;
    }

    
}
