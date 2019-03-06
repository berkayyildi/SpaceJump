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
        float playerHeight = player.transform.position.y;   //Oyuncunun Yüksekliği

        if (playerHeight > maxHeight)   //Oyuncu Yüksekliği oyuncunun oyun içinde ulaştığı max yükseklikten büyükse
        {
            maxHeight = playerHeight;
            text.text = "Score: " + Mathf.RoundToInt(maxHeight * 10.0f);    //Sağ üst kösedeki skoru güncelle
        }
        else if (playerHeight <  maxHeight - 20.0f && isFall==false)    //Oyuncu Max height den 20 birim aşağı düştüyse
        {
            isFall = true;

           
            float MaxScore = maxHeight * 10;

            if (MaxScore > PlayerPrefs.GetFloat("MaxScore",0)) {    //Skor Kırıldıysa
                Debug.Log("MaxScore:" + MaxScore + " Saved");
                PlayerPrefs.SetFloat("MaxScore", MaxScore);
            }
            else
            {
                Debug.Log("MaxScore Kırılamadı Max Skor:" + PlayerPrefs.GetFloat("MaxScore", 0) + " , Sizin Skor:" + MaxScore);
            }

            int[] testarray = new int[] { 1, 3, 5, 7, 9 };
            PlayerPrefsX.SetIntArray("Numbers", testarray);

        }
        edgeMove();

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
