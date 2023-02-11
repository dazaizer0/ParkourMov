using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand_right : MonoBehaviour
{
    Animator anim;
    public GameObject effect;
    public GameObject effectpos;
    public bool collision = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ssen"){
            Instantiate(effect, effectpos.transform.position, Quaternion.identity);
            collision = true;
        }
    }
}
