using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(x, y, z, ForceMode.Impulse);
    }
}
