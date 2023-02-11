using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandEffect : MonoBehaviour
{
    public GameObject effect;
    public GameObject effectPos;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ssen"){
            Instantiate(effect, effectPos.transform.position, Quaternion.identity);
        }
    }
}
