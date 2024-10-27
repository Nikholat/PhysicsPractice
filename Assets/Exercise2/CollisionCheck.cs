using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bench"))
        {
            audioSource.Play();
        }

        Rigidbody otherRigidbody = collision.rigidbody;
        if (otherRigidbody != null)
        {
            otherRigidbody.isKinematic = false;
        }
    }
}
