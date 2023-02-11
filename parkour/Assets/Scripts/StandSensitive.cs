using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandSensitive : MonoBehaviour
{
    public int hp = 100;
    public int damage;
    void Start()
    {
        
    }
    void Update()
    {
        if(hp <= 0){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerStand"){
            hp -= damage;
        }
    }
}
