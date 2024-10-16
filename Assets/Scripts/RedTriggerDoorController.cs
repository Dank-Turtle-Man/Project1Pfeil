using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("RedKeyCard")){
            if(openTrigger){
                myDoor.Play("Door open", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
