using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private float horizontalInput;
    public float speed = 5.0f;
    [SerializeField]
    private Text text;
    private float  maxHeight = 0.0f;
    public GameObject player;
    private bool isFall=false;
    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }

    private void Update()
    {
        if (player.transform.position.y > maxHeight)
        {
            maxHeight = player.transform.position.y;
            changeScore();
        }
        else if (player.transform.position.y <  maxHeight - 20.0f && isFall==false)
        {
            isFall = true;
            Debug.Log("sa");
        }
        edgeMove();

    }

    private void changeScore()
    {
        text.text = "Score: " + Mathf.RoundToInt(maxHeight*10.0f); 
    }


    private void edgeMove()
    {
        if (player.transform.position.x < -2.8f)
        {
            player.transform.position = new Vector2(2.8f, player.transform.position.y);
        }
        if (player.transform.position.x > 2.8f)
        {
            player.transform.position = new Vector2(-2.8f, player.transform.position.y);
        }

    }


}
