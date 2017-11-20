using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour {

  

    
    public void Respawn()
    {
            if (Checkpoint.currentlyActiveCheckpoint == null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Tokens.totalToken = 0;
            }
            else
            {
                transform.position =
                    Checkpoint.currentlyActiveCheckpoint.transform.position;
            
            }      
    }
}
