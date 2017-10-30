using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    static int coinCount = 0;


    private Text coinCountText;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        coinCountText = GameObject.Find("CoinCountText").GetComponent<Text>();
        coinCountText.text = "Coin Count: " + coinCount;
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            coinCount++;
            coinCountText.text = "Coin Count: " + coinCount;
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            //Destroy(gameObject);
        }
    }
}
