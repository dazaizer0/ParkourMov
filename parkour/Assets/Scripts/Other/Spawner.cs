using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int number_of_objects;
    public GameObject object_;

    void Start()
    {
        for(int i = 0; i < number_of_objects; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(75, -75), 1, Random.Range(75, -75));
            Instantiate(object_, randomPosition, Quaternion.identity);
        }
    }
}
