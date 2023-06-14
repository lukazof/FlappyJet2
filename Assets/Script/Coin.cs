using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(12, Random.Range(-1, -3));
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-5, 0);
    }
}
