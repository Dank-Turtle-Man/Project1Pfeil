using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private AudioSource doorOpenSound = null;
    [SerializeField] private float delay = 0;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("RedKeyCard")){
            if(openTrigger){
                myDoor.Play("Door open", 0, 0.0f);
                doorOpenSound.PlayDelayed(delay);
                gameObject.SetActive(false);
            }
        }
    }
}
