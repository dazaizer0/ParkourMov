using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class VoidScript : MonoBehaviour
{
    public Collider col;
    public GameObject v_void;
    public bool check = false;

    void Start()
    {
        check = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == v_void)
        {
            check = true;
        }
    }
    
    public void Update()
    {
        if(check == true){
            col = GetComponent<Collider>();
            SceneManager.LoadScene("Game");
        }
    }
}
