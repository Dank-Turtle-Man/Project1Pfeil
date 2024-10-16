using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonFloat : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new y position based on a sine wave for oscillation
        float newY = originalPosition.y + Mathf.Sin(Time.time * floatSpeed) * upfloat;
        transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        audioSource.PlayOneShot(popSound);
    }
}
