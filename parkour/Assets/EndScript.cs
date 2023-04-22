using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    
    public Canvas EndCanvas;
    

    void Start()
    {
        
        EndCanvas.enabled = false;
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.P))
        {

            Application.Quit();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "End")
        {

            EndCanvas.enabled = true;
            Time.timeScale = 0f;
        }
    }
}
