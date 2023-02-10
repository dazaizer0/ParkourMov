using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public GameObject destroyEffect;
    public GameObject effectPosition;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerTrigger"){
            Destroy(gameObject);
            Instantiate(destroyEffect, effectPosition.transform.position, Quaternion.identity);
        }
    }
}
