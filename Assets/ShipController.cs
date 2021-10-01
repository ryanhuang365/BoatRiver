using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    
    Rigidbody2D rb;
    float dirX;
    float dirY;
    public static float moveSpeed;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetFloat("MoveSpeed") != 0.0f)
        {
            moveSpeed = PlayerPrefs.GetFloat("MoveSpeed");
        }else {
            moveSpeed = 20f;

        }
        rb = GetComponent<Rigidbody2D>();
        dirY = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.acceleration.x) < 0.01)
        {
            dirX = 0;
        }
        else
        {
            dirX = Input.acceleration.x * moveSpeed;
        }
        
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -5f, 5f), transform.position.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ChunkSpawner.chunkIdx - 2 > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", ChunkSpawner.chunkIdx - 2);
        }
        ChunkSpawner.prevScore = ChunkSpawner.chunkIdx - 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }

}
