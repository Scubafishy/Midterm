using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocationShifter : MonoBehaviour {

    [SerializeField]
    float shiftRigiht;

    [SerializeField]
    float shiftLeft;

    [SerializeField]
    GameObject camerGameObject;

    
   private  CameraController cameraControllerScript;

    private void Awake()
    {
        cameraControllerScript = camerGameObject.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "ShiftRight")
        {
            cameraControllerScript.xOffset = shiftRigiht;
        }
        else if (gameObject.tag == "ShiftLeft")
        {
            cameraControllerScript.xOffset = shiftLeft;
        }
    }
   
}
