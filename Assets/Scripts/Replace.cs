using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replace : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private GameObject[] platforms;
    private float maxY;
    


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Platform"))
        {
            platforms = GameObject.FindGameObjectsWithTag("Platform");
            foreach (GameObject currentPlatform in platforms)
            {
                float currentMaxY = currentPlatform.gameObject.transform.position.y;
                if (currentMaxY>maxY) {
                    maxY = currentMaxY;
                }

            }
            col.gameObject.transform.position = new Vector2(Random.Range(-2.5f, 1.8f), maxY+ Random.Range(1.0f, 1.5f));
        }
    }

    
}
