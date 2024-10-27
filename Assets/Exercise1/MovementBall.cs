using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBall : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float y;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        BallMovement();
    }

    private void BallMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;

        transform.Translate(movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bench"))
        {
            audioSource.Play();
        }

        if (collision.rigidbody)
        {
            collision.rigidbody.AddForce(0, y , 0, ForceMode.Impulse);
            collision.rigidbody.isKinematic = false;
        }
    }
}
