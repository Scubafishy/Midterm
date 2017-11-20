using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tokens : MonoBehaviour {
    public static  int totalToken = 0;
    [SerializeField]
    private  int amountofTokensInLevel;

    private Text TotalTokenText;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D boxCollider2D;

    private void Start()
    {
        TotalTokenText = GameObject.Find("TokenText").GetComponent<Text>();
        
        boxCollider2D = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        TotalTokenText.text = totalToken + " / " + amountofTokensInLevel;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            totalToken++;
            
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            //Destroy(gameObject);
        }
    }
}
