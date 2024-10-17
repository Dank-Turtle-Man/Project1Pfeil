using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonFloat : MonoBehaviour
{
    public float upfloat = 0.3f;
    public float floatSpeed = 0.5f;

    private Vector3 originalPosition;
    private AudioSource audioSource;

    void Start()
    {
        originalPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float newY = originalPosition.y + Mathf.Sin(Time.time * floatSpeed) * upfloat;
        transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(audioSource.clip);
        Destroy(gameObject, audioSource.clip.length);
    }
}
