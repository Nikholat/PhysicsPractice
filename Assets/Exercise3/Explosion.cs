using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float TimeToExplosion;
    [SerializeField] private float Power;
    [SerializeField] private float Radius;
    private Rigidbody[] objects;

    private void Start()
    {
        objects = FindObjectsOfType<Rigidbody>();
    }

    void Update()
    {
        ExplosionTime();
    }

    private void Explode()
    {
        foreach (Rigidbody B in objects)
        {
            if(Vector3.Distance(transform.position, B.transform.position) < Radius)
            {
                Vector3 direction = B.transform.position - transform.position;

                Vector3 normalizedDirection = direction.normalized;

                float distanceToObject = Vector3.Distance(transform.position, B.transform.position);
    
                float forceMagnitude = Power * (Radius - distanceToObject);

                B.AddForce(normalizedDirection * forceMagnitude, ForceMode.Impulse);
            }
        }
    }

    private void ExplosionTime()
    {
        TimeToExplosion -= Time.deltaTime;

        if (TimeToExplosion <= 0)
        {
            Explode();
            TimeToExplosion = 3;
        }
    }
}
