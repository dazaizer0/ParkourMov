using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject sword;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            sword.GetComponent<Animator>().Play("SwordAnimation");
        }
    }

    IEnumerator Swing()
    {
        sword.GetComponent<Animator>().Play("SwordAnimation");
        yield return new WaitForSeconds(0.1f);
        sword.GetComponent<Animator>().Play("NewState");
    }
}
