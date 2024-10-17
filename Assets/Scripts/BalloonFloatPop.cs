using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonFloatPop: MonoBehaviour
{
    public float upfloat = 0.5f; // Strength of the floating effect
    public float floatSpeed = 1.0f; // Speed of the up and down motion
    public AudioClip popSound; //pop sound of balloon

    private Vector3 originalPosition;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position; // Save the initial position
        audioSource = GetComponent<audioSource>();
        audioSource.clip = popSound;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new y position based on a sine wave for oscillation
        float newY = originalPosition.y + Mathf.Sin(Time.time * floatSpeed) * upfloat;
        transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
    }

    // Detecing Collision with object
    private void OnCollisionEnter(Collision collision)
    {
        if (audioSource != null)
        {
            //play sound
            audioSource.Play();
        }
            // destory the balloon after the sound is played
            Destroy(this.gameObject, audioSource.clip.length);
        
    }
}