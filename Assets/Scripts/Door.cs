using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField]
    string sceneToLoad;

    [SerializeField]
    private Color activatedColor;

    [SerializeField]
    private Color deactivatedColor;

    [SerializeField]
    private int tokensNeeded;

    private bool isActive = true;

    private Text DoorText;
    private SpriteRenderer spriteRenderer;
    


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        DoorText = GameObject.Find("DoorText").GetComponent<Text>();
        Tokens.totalToken = 0;


    }
    private void Update()
    {
        if (Tokens.totalToken < tokensNeeded)
        {

            DoorText.text = "The Door is closed";
            spriteRenderer.color = deactivatedColor;
        }
        else if (Tokens.totalToken >= tokensNeeded)
        {

            isActive = true;
            DoorText.text = "The Door is Open";
           spriteRenderer.color = activatedColor;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isActive)
        {
            if (Input.GetButtonDown("Action"))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}

