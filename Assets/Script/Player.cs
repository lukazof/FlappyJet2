using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpVelocity;
    public Rigidbody2D rb;

    public static Player Instance;

    public bool canPlay = true;

    public ParticleSystem[] particles;

    public bool isAi = false;


    private void Awake()
    {
        Instance = this;
    }
    float gravity;
    void Start()
    {
        gravity = rb.gravityScale;
        rb = GetComponent<Rigidbody2D>();
        particles = GetComponentsInChildren<ParticleSystem>();
        rb.isKinematic = true;
    }

    float jumpTime;
    float realGravity = 0;

    float closestScoreHeight = 0;

    void Update()
    {
        canPlay = Game.Instance.state == Game.GameState.playing;

        FindClosestScoreObject();

        if (isAi && canPlay)
        {
            print(closestScoreHeight);
            if (transform.position.y < closestScoreHeight - 0.25f)
            {
                print("Going up!");
                rb.velocity = new Vector2(0, jumpVelocity);
                particles[1].enableEmission = true;
            }
            else
            {
                print("Going Down!");
                particles[1].enableEmission = false;

            }
        }

        if (realGravity <= gravity && canPlay)
        {
            realGravity += Time.deltaTime;
            rb.gravityScale = realGravity;
        }

        if (canPlay && !isAi)
        {
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);

            if (Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                jumpTime = 0.1f;
                rb.velocity = new Vector2(0, jumpVelocity * 0.5f);
            }

            if (Input.GetButton("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary))
            {
                jumpTime -= Time.deltaTime;

                if (jumpTime <= 0)
                {
                    rb.velocity = new Vector2(0, jumpVelocity);
                }

                particles[1].enableEmission = true;
            }

            if (Input.GetButtonUp("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                particles[1].enableEmission = false;
            }
        }

        float ang = Mathf.Atan2(rb.velocity.y, 10) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, ang);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") && canPlay)
        {
            Game.Instance.StopAllCoroutines();
            Game.Instance.GameOver();
        }

        if (collision.gameObject.CompareTag("Score") && canPlay)
        {
            Game.Instance.runScore++;
            GameUI.Instance.scoreText.gameObject.GetComponent<Animator>().SetTrigger("PopUp");
            AudioManager.Instance.PlaySound(AudioManager.Instance.scoreSound);
        }

        if (collision.gameObject.CompareTag("Coin") && Game.Instance.state == Game.GameState.playing)
        {
            Destroy(collision.gameObject);
            Game.Instance.coins++;

            PlayerPrefs.SetInt("Coins", Game.Instance.coins);
            PlayerPrefs.Save();

            AudioManager.Instance.PlaySound(AudioManager.Instance.coinSound);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") && canPlay && !isAi)
        {
            Game.Instance.StopAllCoroutines();
            Game.Instance.GameOver();
        }

        if (collision.gameObject.CompareTag("Score") && canPlay && !isAi)
        {
            Game.Instance.runScore++;
            GameUI.Instance.scoreText.gameObject.GetComponent<Animator>().SetTrigger("PopUp");
            AudioManager.Instance.PlaySound(AudioManager.Instance.scoreSound);
            Destroy(collision.gameObject, 0.15f);
        }
    }

    void FindClosestScoreObject()
    {
        GameObject[] scoreObjects = GameObject.FindGameObjectsWithTag("Score");
        float minDistance = Mathf.Infinity;
        GameObject closestScoreObject = null;

        foreach (GameObject scoreObject in scoreObjects)
        {
            float distance = Vector3.Distance(transform.position, scoreObject.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestScoreObject = scoreObject;
            }
        }

        if (closestScoreObject != null)
        {
            closestScoreHeight = closestScoreObject.transform.position.y;
        }
    }


}
