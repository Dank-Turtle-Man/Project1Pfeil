using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonFloatPop : MonoBehaviour
{
    public float upfloat = 0.5f; // Strength of the floating effect
    public float floatSpeed = 1.0f; // Speed of the up and down motion

    private Vector3 originalPosition;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position; // Save the initial position
        audioSource = GetComponent<AudioSource>(); // Corrected case
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new y position based on a sine wave for oscillation
        float newY = originalPosition.y + Mathf.Sin(Time.time * floatSpeed) * upfloat;
        transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
    }

    // Detecting collision with an object
    private void OnCollisionEnter(Collision collision)
    {
        // Play the pop sound
        audioSource.Play();

        // Destroy the balloon after the sound has played
        Destroy(this.gameObject, audioSource.clip.length);
    }
}