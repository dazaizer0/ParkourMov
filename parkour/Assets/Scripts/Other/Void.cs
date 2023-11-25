using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    public GameObject void_;
    public bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == void_)
        {
            triggered = true;
        }
    }
    
    public void Update()
    {
        if(triggered == true)
        {
            int current_scene_index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(current_scene_index);
        }
    }
}
