using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    public GameObject Player;
    Animator otherAnimator;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            audioSource.Play();
            otherAnimator = Player.GetComponent<Animator>();
           otherAnimator.SetBool("Death", true);
            collision.gameObject.GetComponent<PlayerRespawn>().Respawn();
           
        }
    }
}

