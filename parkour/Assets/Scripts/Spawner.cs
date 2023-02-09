using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int numberOfObjectsToSpan;
    public GameObject objectToSpawn;
    void Start()
    {
        for(int i = 0; i < numberOfObjectsToSpan; i++){
            Vector3 randomPosition = new Vector3(Random.Range(20, -20), 1, Random.Range(20, -20));
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        }
    }
}
