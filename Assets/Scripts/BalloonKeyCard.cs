using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonKeyCard : MonoBehaviour
{
    public float upfloat = 0.5f; // Strength of the floating effect
    public float floatSpeed = 1.0f; // Speed of the up and down motion

    private Vector3 originalPosition;
    private AudioSource audioSource;
    [SerializeField] ParticleSystem popParticle = null;
    [SerializeField] GameObject redkeycard;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position; // Save the initial position
        audioSource = GetComponent<AudioSource>();
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

        // Destroy the dart upon collision
        Destroy(collision.gameObject);

        // Spawn the red keycard after the sound plays and balloon is destroyed
        StartCoroutine(HandleBalloonPop());
    }

    // Coroutine to handle sound playing and spawning the keycard
    private IEnumerator HandleBalloonPop()
    {
        // Wait for the audio clip to finish
        yield return new WaitForSeconds(audioSource.clip.length);

        // Play the particle effect before destroying the balloon
        if (popParticle != null)
        {
            popParticle.Play();
        }

        // Spawn the red keycard at balloon
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(redkeycard, spawnPosition, Quaternion.identity);

        // Destroy the balloon after the sound has finished playing
        Destroy(this.gameObject);
    }
}