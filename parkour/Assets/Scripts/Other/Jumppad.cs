using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public GameObject player;
    public float jump_force = 10f;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == player)
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            playerRigidbody.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
        }
    }
}